using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text[] texts;
    [SerializeField] private GlobalValues globalValues;
    [SerializeField] private GameObject stickController;
    [SerializeField] private Slider turboSlider;
    [SerializeField] private Slider goalSlider;

    void Update()
    {
        texts[0].text = globalValues.GetTime.ToString();
        texts[1].text = globalValues.GetAmmo.ToString();
        texts[2].text = globalValues.GetPlayerHealth.ToString();
        texts[3].text = Mathf.Round((globalValues.GetPlayerSpeed * 10)).ToString() + " Km/h";
        stickController.transform.localRotation = Quaternion.Euler(0f, 0f, (globalValues.GetPlayerSpeed / 26) * -185f);
        turboSlider.value = globalValues.GetTurbo;
        goalSlider.value = globalValues.GetTotalDistance;
    }
}
