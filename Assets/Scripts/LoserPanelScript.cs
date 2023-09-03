using UnityEngine;
using UnityEngine.SceneManagement;

public class LoserPanelScript : MonoBehaviour
{   
    public void ContinueButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
