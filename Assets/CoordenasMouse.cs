using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    
    public Text textoPosicionMouse;
    public Text mostrarDistancia;
    //PARA PRIMER OBJETO
    public InputField primerInut;
    public Text textoObjetoSeleccionado;
    public Text mostrarVelocidad;
    
    public GameObject aroVerde;

    //PARA SEGUNDO OBJETO
    public InputField segundoInput;
    public Text textoObjetoSeleccionado2;
    public Text mostrarVelocidad2;
    public GameObject aroRojo;










    public GameObject flechasDireccion;
    public GameObject quitPrefab;

    private int contadorObjetos = 1;
    private float radioCirculo = 0.2f;




    //CIRCULO VERDE
    private GameObject circuloVerdeActual;
    private GameObject objetoSeleccionado;
    private GameObject objetoSeleccionadoAnterior;

    //CIRCULO ROJO
    private GameObject circuloRojoActual;
    private GameObject objetoSeleccionado2;
    private GameObject objetoSeleccionadoAnterior2;



    void Update()
    {
        Ray rayoDesdeCamara = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Vector3 posicionGolpe = Vector3.zero; // Declarar la variable fuera del bloque if


        //PARA OBJETO 1
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
                                    mostrarVelocidad.text = velocidad.magnitude.ToString("F2") + " m/s";
                                    propiedades.Carga = cargaActual;
                                }
                            }
                }

            }



        //PARA OBJETO 2
        if (objetoSeleccionado2 != null)
            {
                // Obtener el componente PropiedadesObjetos del objeto seleccionado

                if (objetoSeleccionado2.TryGetComponent<PropiedadesObjetos>(out PropiedadesObjetos propiedades))
                {

                            if (objetoSeleccionado2 != objetoSeleccionadoAnterior2)
                            {
                                string objetoNombre = objetoSeleccionado2.name;
                                float mayorEscala = Mathf.Max(objetoSeleccionado2.transform.localScale.x, objetoSeleccionado2.transform.localScale.y, objetoSeleccionado2.transform.localScale.z);

                                float nuevaCarga = propiedades.Carga;    

                                // Convertir el valor de la carga a texto y asignarlo a primerInut.text
                                segundoInput.text = nuevaCarga.ToString();
                                objetoSeleccionadoAnterior2 = objetoSeleccionado2;
                            }
                            else
                            {
                                if (float.TryParse(segundoInput.text, out float cargaActual))
                                {

                                    Rigidbody rb = objetoSeleccionado2.GetComponent<Rigidbody>();
                                    Vector3 velocidad = rb.GetPointVelocity(objetoSeleccionado2.transform.position);
                                    // Asignar la nueva carga al componente PropiedadesObjetos
                                    mostrarVelocidad2.text = velocidad.magnitude.ToString("F2") + " m/s";
                                    propiedades.Carga = cargaActual;

                                }
                            }
                }

            }


            



        if (Physics.Raycast(rayoDesdeCamara, out hitInfo)) 
        {
            posicionGolpe = hitInfo.point;
            textoPosicionMouse.text = "Posición del Mouse: " + posicionGolpe.ToString();



        //CLICK IZQUIERDO
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


        //CLICK DERECHO
        if (Input.GetMouseButtonDown(1)) {
            if (hitInfo.transform.gameObject.name != "Piso") {
                objetoSeleccionado2 = hitInfo.transform.gameObject;
                }

                string nombreObjeto = objetoSeleccionado2.name;
            
                // Asignar el texto solo si textoObjetoSeleccionado está asignado
                textoObjetoSeleccionado2.text = nombreObjeto;

                if (circuloRojoActual != null)
                {
                    Destroy(circuloRojoActual);
                }



            // Obtener el tamaño real del objeto seleccionado
            Renderer renderer = objetoSeleccionado2.GetComponent<Renderer>();
            Vector3 size = renderer.bounds.size;

            // Calcular el máximo tamaño para ajustar el círculo verde
            float maxSize = Mathf.Max(size.x, size.y, size.z);

            // Ajustar la escala del círculo verde para que rodee al objeto seleccionado
            float escala = size.x * radioCirculo;

            // Instanciar el círculo verde y almacenar una referencia a él
            circuloRojoActual = Instantiate(aroRojo, objetoSeleccionado2.transform.position, Quaternion.identity);

            // Ajustar la escala del círculo verde
            circuloRojoActual.transform.localScale = new Vector3(escala, escala, 1f);
            circuloRojoActual.transform.Rotate(new Vector3(90f, 0, 0));

        }


        if (Input.GetKeyDown(KeyCode.A) && (contadorObjetos <= 6))
        {
            // Crear una nueva posición 10 unidades sobre el eje Z
            Vector3 nuevaPosicion = posicionGolpe + new Vector3(0, 2, 0);

            // Instanciar un nuevo objeto en la nueva posición
            GameObject nuevoObjeto = Instantiate(quitPrefab, nuevaPosicion, Quaternion.identity);

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


        if (circuloRojoActual != null)
        {

        // Obtener el tamaño real del objeto seleccionado
        Renderer renderer = objetoSeleccionado2.GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size;

        // Calcular el máximo tamaño para ajustar el círculo verde
        float maxSize = Mathf.Max(size.x, size.y, size.z);

        // Ajustar la escala del círculo verde para que rodee al objeto seleccionado
        float escala = size.x * radioCirculo;
        circuloRojoActual.transform.position = objetoSeleccionado2.transform.position;
        circuloRojoActual.transform.localScale = new Vector3(escala, escala, 1f);
        }

        if(objetoSeleccionado != null && objetoSeleccionado2 != null) {


        }

        
        if (objetoSeleccionado != null && objetoSeleccionado2 != null)
        {
            // Calcula la distancia entre los dos objetos
            float distancia = (Vector3.Distance(objetoSeleccionado.transform.position, objetoSeleccionado2.transform.position))-1f;
            
            // Muestra la distancia en la UI, formateada a 2 decimales
            mostrarDistancia.text = distancia.ToString("F2") + " metros";
        }



    }


}