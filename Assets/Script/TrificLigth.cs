using System.Collections;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public enum LightColor
    {
        Red,
        Yellow,
        Green
    }

    public LightColor currentColor;
    private float secondsRemaining; // Переменная для хранения оставшихся секунд до смены цвета

    public GameObject redLightObject;
    public GameObject yellowLightObject;
    public GameObject greenLightObject;

    private Material redMaterial;
    private Material yellowMaterial;
    private Material greenMaterial;

    private ShowText timeDisplay; // Ссылка на компонент TimeDisplay

    void Start()
    {
        redMaterial = redLightObject.GetComponent<Renderer>().material;
        yellowMaterial = yellowLightObject.GetComponent<Renderer>().material;
        greenMaterial = greenLightObject.GetComponent<Renderer>().material;

        timeDisplay = FindObjectOfType<ShowText>(); // Находим объект TimeDisplay в сцене

        StartCoroutine(ChangeColorCoroutine());
    }

    private IEnumerator ChangeColorCoroutine()
    {
        currentColor = LightColor.Red;
        secondsRemaining = 60f;

        while (true)
        {
            UpdateLights();
            timeDisplay.UpdateTime(secondsRemaining); // Обновляем отображение времени в TimeDisplay
            yield return new WaitForSeconds(1f);
            secondsRemaining -= 1f;

            if (secondsRemaining <= 0f)
            {
                ChangeToNextColor();
            }
        }
    }

    private void UpdateLights()
    {
        switch (currentColor)
        {
            case LightColor.Red:
                SetMaterialColor(redMaterial, Color.red);
                SetMaterialColor(yellowMaterial, Color.black);
                SetMaterialColor(greenMaterial, Color.black);
                break;

            case LightColor.Yellow:
                SetMaterialColor(redMaterial, Color.black);
                SetMaterialColor(yellowMaterial, Color.yellow);
                SetMaterialColor(greenMaterial, Color.black);
                break;

            case LightColor.Green:
                SetMaterialColor(redMaterial, Color.black);
                SetMaterialColor(yellowMaterial, Color.black);
                SetMaterialColor(greenMaterial, Color.green);
                break;
        }
    }

    private void SetMaterialColor(Material material, Color color)
    {
        material.color = color;
    }

    private void ChangeToNextColor()
    {
        switch (currentColor)
        {
            case LightColor.Red:
                currentColor = LightColor.Yellow;
                secondsRemaining = 2f;
                break;

            case LightColor.Yellow:
                currentColor = LightColor.Green;
                secondsRemaining = 4f;
                break;

            case LightColor.Green:
                currentColor = LightColor.Red;
                secondsRemaining = 6f;
                break;
        }
    }
}
