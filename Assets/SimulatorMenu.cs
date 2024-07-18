using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulatorMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Cambia "MainMenu" por el nombre de tu escena de menú principal si es diferente.
    }
}
