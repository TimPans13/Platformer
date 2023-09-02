using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerScript : MonoBehaviour
{
    public GameObject WinnerPanel,PauseButton;
    public GameObject Star1, Star2, Star3;
    public GameObject Lives;

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")//если попадает объект с тэгом игрок останавливаем
        {  
            WinnerPanel.SetActive(true);
            Time.timeScale = 0f;
            PauseButton.SetActive(false);
            Lives.SetActive(false);
            StarsCounter();
            MainMenu.unlockedLevel++;
        }
    }

    public void ContinueButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//переход к следующему уровню
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");//выход в меню
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//переход на текущий уровень
    }

    void StarsCounter()
    {
        switch (HealthSystem.health)//количество звёзд берём из алмазов
        {
            case 3:
                Star1.SetActive(true);
                Star2.SetActive(true);
                Star3.SetActive(true);
                break;
            case 2:
                Star1.SetActive(true);
                Star2.SetActive(true);
                Star3.SetActive(false);
                break;
            case 1:
                Star1.SetActive(true);
                Star2.SetActive(false);
                Star3.SetActive(false);
                break;
        }
    }
}









