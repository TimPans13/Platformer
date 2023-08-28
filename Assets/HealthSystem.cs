using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthSystem : MonoBehaviour//отвечает за здоровье и механику проигрыша(частично за запуск времени)
{
    public static int health=3;
    public GameObject heart1, heart2, heart3;
    public GameObject LoserPanel, PauseButton;

    void Start()//включает таймер и задаёт здоровье
    {
        health = 3;
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        Time.timeScale = 1f;
    }

    void Update()
    {
        switch (health)
        {
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 0://выключает таймер и включает панель проигрыша
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                LoserPanel.SetActive(true);
                PauseButton.SetActive(false);
                Time.timeScale = 0f;
                break;
        }
    }
}
