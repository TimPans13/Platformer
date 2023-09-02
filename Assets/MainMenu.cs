using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject LevelPanel;
    public Button[] buttons;
    public static int unlockedLevel = 1;

    private void Awake()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;

            //if (!buttons[i].interactable)
            //{
            //    Transform emptyObject = buttons[i].transform.GetChild(1);
            //    emptyObject.gameObject.SetActive(false);
            //}
        }

    }

    public void OpenLevel(int LevelId)
    {
        SceneManager.LoadScene(LevelId);
    }

    public void PlayGame()
    {
        LevelPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("game over");
        Application.Quit();
    }

    public void ExitToMenu()
    { 
        LevelPanel.SetActive(false);
    }
}
