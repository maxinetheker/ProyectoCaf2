using UnityEngine;

public class CreateOnClick : MonoBehaviour
{
    public GameObject objetoPrefab; // Prefab del objeto que deseas crear

    void Update()
    {
        // Detectar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Obtener la posición en el mundo donde se hizo clic
            Vector3 posicionClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicionClick.z = 0; // Asegurar que la posición Z sea la misma que la cámara

            // Instanciar un nuevo objeto en la posición del clic
            Instantiate(objetoPrefab, posicionClick, Quaternion.identity);
        }
    }
}
