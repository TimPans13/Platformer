using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("first level");
    }

    public void ExitGame()
    {
        Debug.Log("game over");
        Application.Quit();
    }
}
