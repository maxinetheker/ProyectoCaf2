using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulatorControl : MonoBehaviour
{
    public void RestartSimulation()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
