using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    [SerializeField] Text txtMessage, txtScore;
    [SerializeField] GameObject[] stars;
    private void Awake()
    {
        txtMessage.text = globalValues.GetGameOver;
        txtScore.text = globalValues.GetTotalScore.ToString();
        switch (globalValues.GetTotalScore)
        {
            case < 4000:
                stars[0].GetComponent<Image>().color = Color.yellow;
                break;
            case < 8000:
                stars[0].GetComponent<Image>().color = Color.yellow;
                stars[1].GetComponent<Image>().color = Color.yellow;
                break;
            case < 12000:
                stars[0].GetComponent<Image>().color = Color.yellow;
                stars[1].GetComponent<Image>().color = Color.yellow;
                stars[2].GetComponent<Image>().color = Color.yellow;
                break;
        }
    }

    private void CatchVariableChanged()
    {
        gameObject.transform.Find("ScoreTable").gameObject.SetActive(true);
    }

    private void Start()
    {
        globalValues.VariableChanged += CatchVariableChanged;
    }

    public void BtnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void BtnJugar()
    {
        SceneManager.LoadScene("GameScene");
    }

}
