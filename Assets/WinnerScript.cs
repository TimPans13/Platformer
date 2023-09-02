using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerScript : MonoBehaviour
{
    public GameObject WinnerPanel,PauseButton;
    public GameObject Star1, Star2, Star3;
    public GameObject Lives;

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")//���� �������� ������ � ����� ����� �������������
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//������� � ���������� ������
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");//����� � ����
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//������� �� ������� �������
    }

    void StarsCounter()
    {
        switch (HealthSystem.health)//���������� ���� ���� �� �������
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









