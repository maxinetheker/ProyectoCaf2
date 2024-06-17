using UnityEngine;
using UnityEngine.UI;

public class BotonDesactivar : MonoBehaviour
{
    public DesactivarObjetosConPropiedad desactivador;
    private Button btn;
    private Text buttonText;

    private bool objetosActivados = true; // Estado inicial de los objetos

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(AlternarActivacion);
        buttonText = btn.GetComponentInChildren<Text>(); // Obtener el componente Text del botón

        ActualizarTextoBoton();
    }

    void AlternarActivacion()
    {
        objetosActivados = !objetosActivados; // Alternar el estado

        if (objetosActivados)
        {
            desactivador.ActivarObjetos();
        }
        else
        {
            desactivador.DesactivarObjetos();
        }

        ActualizarTextoBoton();
    }

    void ActualizarTextoBoton()
    {
        if (objetosActivados)
        {
            buttonText.text = "Desactivar Vectores";
        }
        else
        {
            buttonText.text = "Activar Vectores";
        }
    }
}