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

    private void SetScoreText()
    {
        txtMessage.text = globalValues.GetGameOver;
        txtScore.text = globalValues.GetTotalScore.ToString();
        float score = globalValues.GetTotalScore;
        if (score < 1000) { }
        else if (score < 2500f)
        {
            stars[0].GetComponent<Image>().color = Color.yellow;
        }
        else if (score < 3750f)
        {
            stars[0].GetComponent<Image>().color = Color.yellow;
            stars[1].GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            stars[0].GetComponent<Image>().color = Color.yellow;
            stars[1].GetComponent<Image>().color = Color.yellow;
            stars[2].GetComponent<Image>().color = Color.yellow;
        }
    }

    private void ResetStars()
    {
        stars[0].GetComponent<Image>().color = Color.white;
        stars[1].GetComponent<Image>().color = Color.white;
        stars[2].GetComponent<Image>().color = Color.white;
    }

    private void CatchVariableChanged()
    {
        SetScoreText();
        gameObject.transform.Find("ScoreTable").gameObject.SetActive(true);
    }

    private void Start()
    {
        globalValues.VariableChanged += CatchVariableChanged;
        ResetStars();
    }

    public void BtnMenu()
    {
        ResetStars();
        SceneManager.LoadScene("Menu");
    }
    public void BtnJugar()
    {
        ResetStars();
        SceneManager.LoadScene("GameScene");
    }
}
