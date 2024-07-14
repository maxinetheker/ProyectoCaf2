using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PropiedadesObjetos : MonoBehaviour
{
    public float Carga;
    public float fuerza;
    public float radioDeteccion = 10f;
    public float fuerzaBase = 1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {


        // Detectar objetos cercanos en un radio especificado

        Collider[] colliders = Physics.OverlapSphere(transform.position, 100);

            foreach (Collider collider in colliders)
                {

                    
                    // Verificar si el objeto detectado tiene el componente PropiedadesObjetos adjunto
                    PropiedadesObjetos propiedades = collider.GetComponent<PropiedadesObjetos>();
                    if (propiedades != null)
                    {   

                        float distancia = Vector3.Distance(transform.position, collider.transform.position);

                        
                        // Acceder a la carga del objeto detectado
                        float carga = propiedades.Carga;
                        
                        // Realizar acciones basadas en la carga del objeto
                        Vector3 direccion = (transform.position - collider.transform.position).normalized;
                        
                        if (distancia > 0)
                            {
                                const float k = 8.99e9f;
                                float convertedCarga1 = carga * 1e-4f;
                                float convertedCarga2 = Carga * 1e-4f;

                                fuerza = (k * convertedCarga1 * convertedCarga2) / (float)Math.Pow(distancia, 2);

                                // Aplicar la fuerza al objeto actual en sentido contrario
                                rb.AddForce(direccion.normalized * fuerza, ForceMode.Force);
                            }

                    }

                }
    }

   /* void OnDrawGizmosSelected()
    {
        // Dibujar una esfera de detección en el editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);
    }
*/


}
