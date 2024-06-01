using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text textoPosicionMouse;
    public InputField primerInut;
    public Text textoObjetoSeleccionado;
    public Text mostrarVelocidad;
    public GameObject quitPrefab;
    public GameObject aroVerde;


    private int contadorObjetos = 1;
    private float radioCirculo = 0.2f;
    private GameObject circuloVerdeActual;
    private GameObject objetoSeleccionado;
    private GameObject objetoSeleccionadoAnterior;

    void Update()
    {
        Ray rayoDesdeCamara = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Vector3 posicionGolpe = Vector3.zero; // Declarar la variable fuera del bloque if

        if (objetoSeleccionado != null)
            {
                // Obtener el componente PropiedadesObjetos del objeto seleccionado

                if (objetoSeleccionado.TryGetComponent<PropiedadesObjetos>(out PropiedadesObjetos propiedades))
                {

                            if (objetoSeleccionado != objetoSeleccionadoAnterior)
                            {
                                string objetoNombre = objetoSeleccionado.name;
                                float mayorEscala = Mathf.Max(objetoSeleccionado.transform.localScale.x, objetoSeleccionado.transform.localScale.y, objetoSeleccionado.transform.localScale.z);

                                float nuevaCarga = propiedades.Carga;    

                                // Convertir el valor de la carga a texto y asignarlo a primerInut.text
                                primerInut.text = nuevaCarga.ToString();
                                objetoSeleccionadoAnterior = objetoSeleccionado;
                            }
                            else
                            {
                                if (float.TryParse(primerInut.text, out float cargaActual))
                                {

                                    Rigidbody rb = objetoSeleccionado.GetComponent<Rigidbody>();
                                    Vector3 velocidad = rb.GetPointVelocity(objetoSeleccionado.transform.position);
                                    // Asignar la nueva carga al componente PropiedadesObjetos
                                    mostrarVelocidad.text = velocidad.magnitude.ToString() + " m/s";
                                    propiedades.Carga = cargaActual;
                                }
                            }
                }

            }



        if (Physics.Raycast(rayoDesdeCamara, out hitInfo)) 
        {
            posicionGolpe = hitInfo.point;
            textoPosicionMouse.text = "Posición del Mouse: " + posicionGolpe.ToString();




        if (Input.GetMouseButtonDown(0))
        {
            if (hitInfo.transform.gameObject.name != "Piso") {
                objetoSeleccionado = hitInfo.transform.gameObject;
                }

                string nombreObjeto = objetoSeleccionado.name;
            
                // Asignar el texto solo si textoObjetoSeleccionado está asignado
                textoObjetoSeleccionado.text = nombreObjeto;

                if (circuloVerdeActual != null)
                {
                    Destroy(circuloVerdeActual);
                }



        // Obtener el tamaño real del objeto seleccionado
        Renderer renderer = objetoSeleccionado.GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size;

        // Calcular el máximo tamaño para ajustar el círculo verde
        float maxSize = Mathf.Max(size.x, size.y, size.z);

        // Ajustar la escala del círculo verde para que rodee al objeto seleccionado
        float escala = size.x * radioCirculo;

        // Instanciar el círculo verde y almacenar una referencia a él
        circuloVerdeActual = Instantiate(aroVerde, objetoSeleccionado.transform.position, Quaternion.identity);

        // Ajustar la escala del círculo verde
        circuloVerdeActual.transform.localScale = new Vector3(escala, escala, 1f);
        circuloVerdeActual.transform.Rotate(new Vector3(90f, 0, 0));
        

        }



        if (Input.GetKeyDown(KeyCode.A) && (contadorObjetos <= 6))
        {
            // Instanciar un nuevo objeto
            GameObject nuevoObjeto = Instantiate(quitPrefab, posicionGolpe, Quaternion.identity);

            // Asignar un nombre al objeto con el número de objeto creado
            nuevoObjeto.name = "Esfera(" + contadorObjetos.ToString() + ")";

            // Incrementar el contador de objetos
            contadorObjetos++;


        }
        



        }

        if (circuloVerdeActual != null)
        {

        // Obtener el tamaño real del objeto seleccionado
        Renderer renderer = objetoSeleccionado.GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size;

        // Calcular el máximo tamaño para ajustar el círculo verde
        float maxSize = Mathf.Max(size.x, size.y, size.z);

        // Ajustar la escala del círculo verde para que rodee al objeto seleccionado
        float escala = size.x * radioCirculo;
        circuloVerdeActual.transform.position = objetoSeleccionado.transform.position;
        circuloVerdeActual.transform.localScale = new Vector3(escala, escala, 1f);
        }


    }
}