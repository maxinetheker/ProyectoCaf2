using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); // Cambia "NombreDeTuEscena" por el nombre de tu escena de juego.
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego"); // Esto es solo para probar en el editor.
        Application.Quit(); // Esto cerrará el juego en una build.
    }
}
