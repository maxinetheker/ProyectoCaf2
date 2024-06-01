using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 2.0f;
    public float velocidadZoom = 5.0f;

    private Camera mainCamera;
    private Vector3 lastMousePosition;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Movimiento de la cámara con click derecho
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 desplazamiento = new Vector3(-mouseX, -mouseY, 0) * velocidadMovimiento * Time.deltaTime;
            transform.Translate(desplazamiento, Space.Self);
        }

        // Rotación de la cámara con botón central
        if (Input.GetMouseButton(2))
        {
            float mouseX = Input.GetAxis("Mouse X") * velocidadRotacion;
            float mouseY = Input.GetAxis("Mouse Y") * velocidadRotacion;

            transform.Rotate(Vector3.up, mouseX);
            transform.Rotate(Vector3.right, -mouseY);
        }

        // Zoom de la cámara con rueda del ratón
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        mainCamera.transform.Translate(Vector3.forward * scroll * velocidadZoom, Space.Self);



        // POSICION ARRIBA DE LA CAMARA
        if (Input.GetKeyDown(KeyCode.Z)) {
                // Acción a realizar cuando se presiona la tecla "1" del teclado numérico
                Vector3 posicionArriba = new Vector3(1.614901f, 52.804f, -3.626064f);
                Vector3 rotacionArriba = new Vector3(89.405f, 88.726f, -1.499f);
                  transform.position = posicionArriba;

             // Aplica la rotación al objeto en el espacio global
             transform.rotation = Quaternion.Euler(rotacionArriba);


            }

        // VISTA DE UN LADO
        if (Input.GetKeyDown(KeyCode.X)) {
                // Acción a realizar cuando se presiona la tecla "1" del teclado numérico
                Vector3 posicionArriba = new Vector3(-1.886f, 19.042f, -57.185f);
                Vector3 rotacionArriba = new Vector3(39.105f, -0.688f, 0.028f);
                  transform.position = posicionArriba;

             // Aplica la rotación al objeto en el espacio global
             transform.rotation = Quaternion.Euler(rotacionArriba);


            }


    }
}

