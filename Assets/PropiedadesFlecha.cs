using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropiedadesFlecha : MonoBehaviour
{
    public float radioDeteccion = 10f;
    public float fuerzaBase = 1f;

    void FixedUpdate()
    {
        Vector3 campoElectrico = Vector3.zero;

        // Detectar objetos cercanos en un radio especificado
        Collider[] colliders = Physics.OverlapSphere(transform.position, 100);

        foreach (Collider collider in colliders)
        {
            // Obtener el componente PropiedadesObjetos del objeto detectado
            PropiedadesObjetos propiedades = collider.GetComponent<PropiedadesObjetos>();
            if (propiedades != null)
            {
                // Obtener la carga y la posición del objeto detectado
                float carga = propiedades.Carga;
                Vector3 posicionObjeto = collider.transform.position;

                // Calcular dirección del campo eléctrico generado por este objeto en el plano XY (horizontal)
                Vector3 direccion = (posicionObjeto - transform.position).normalized;
                direccion.y = 0; // Ignorar el componente Y para rotación horizontal

                // Determinar la dirección según el tipo de carga
                if (carga > 0)
                {
                    // Carga positiva, apuntar en dirección opuesta
                    direccion *= -1f;
                }
                else if (carga < 0)
                {
                    // Carga negativa, apuntar en la misma dirección
                    // No se necesita modificar 'direccion'
                }

                // Calcular la magnitud del campo eléctrico generado por este objeto
                float distancia = Vector3.Distance(transform.position, posicionObjeto);
                float k = 8.85f; // Constante de Coulomb (puedes ajustarla según necesites)
                float magnitudCampo = (k * Mathf.Abs(carga)) / (distancia * distancia);

                // Sumar la contribución de este objeto al campo eléctrico total en el plano XY
                campoElectrico += magnitudCampo * direccion;
            }
        }

        // Bloquear la rotación en el eje X a 90 grados
        transform.eulerAngles = new Vector3(90f, transform.eulerAngles.y, 0f);

        // Rotar la flecha solo en el eje Y hacia la dirección del campo eléctrico resultante
        if (campoElectrico != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(campoElectrico.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Ajusta la velocidad de rotación según sea necesario
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar una esfera de detección en el editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);
    }
}
