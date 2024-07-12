using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneRestart : MonoBehaviour
{
    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
