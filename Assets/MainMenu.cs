using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject LevelPanel;
    public Button[] buttons;
    public GameObject[] starsPerLevel;

    private void Awake()
    {
        openButtons();
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

    void openButtons()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");
        if (!(Convert.ToBoolean(unlockedLevel))) { unlockedLevel = 1; PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel); }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            starsPerLevel[i].SetActive(false);
            for (int j = 0; j < 3; j++)
            {
                starsPerLevel[i].transform.GetChild(j).gameObject.SetActive(false);
            }
        }
        //Debug.Log(unlockedLevel);
        for (int i = 0; i < unlockedLevel; i++)
        {
            if (buttons[i]) { buttons[i].interactable = true; }
            if (PlayerPrefs.HasKey("Level" + (i + 1) + " stars"))
            {
                int starsCounter = PlayerPrefs.GetInt("Level" + (i + 1) + " stars");
                for (int j = 0; j < starsCounter; j++)
                {
                    starsPerLevel[i].SetActive(true);
                    starsPerLevel[i].transform.GetChild(j).gameObject.SetActive(true);
                }
            }

        }
    }

    public void Restart()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("UnlockedLevel", 1);
        PlayerPrefs.SetInt("Cherry", 0);
        // Debug.Log("UnlockedLevel = " + PlayerPrefs.GetInt("UnlockedLevel"));
        for (int i = 1; i <= 4; i++)
        {
            PlayerPrefs.SetInt("Level" + (i) + " stars",0);
            //Debug.Log("Level" + (i) + " stars = " + PlayerPrefs.GetInt("Level" + (i) + " stars"));
        }
        SceneManager.LoadScene("Menu");
    }
}
