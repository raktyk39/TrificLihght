using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    [SerializeField]
    public Text timeText; // Ссылка на компонент UI Text, куда будет выводиться время
    public Text timeText1;
    public Text timeText2;
    TrafficLight trisificProces;

    public void Start ()
    {
        trisificProces = FindObjectOfType<TrafficLight>();
    }

    public void UpdateTime(float currentTime)
    {
        // Форматируем время в формат "минуты:секунды"
        string formattedTime = FormatTime(currentTime);

        // Обновляем текст UI Text
        timeText.text = "Time: " + formattedTime;
        timeText1.text = "Time: " + formattedTime;
        timeText2.text = "Time: " + formattedTime;
        ChanceText();
    }

    public void ChanceText ()
    {
        switch(trisificProces.currentColor)
        {
             case TrafficLight.LightColor.Red:
                timeText.enabled = true;
               timeText1.enabled = false;
               timeText2.enabled = false;
               Debug.Log("GGG0");
                break;

            case TrafficLight.LightColor.Yellow:
                timeText.enabled = false;
               timeText1.enabled = true;
               timeText2.enabled = false;
                break;

            case TrafficLight.LightColor.Green:
                 timeText.enabled = false;
               timeText1.enabled = false;
               timeText2.enabled = true;
                break;
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds); // Форматирование времени в виде "мм:сс"
    }
}
