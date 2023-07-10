using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;

    public void BtnJugar()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BtnQuit()
    {
        Application.Quit();
    }

    //Enemy, ammo, turbo, fix
    public void BtnFacil()
    {
        globalValues.SetProbs(5, 3, 1.5f, 2);
    }
    public void BtnMedio()
    {
        globalValues.SetProbs(7.5f, 2.5f, 1, 1);
    }
    public void BtnDificil()
    {
        globalValues.SetProbs(10, 2, 0.5f, 0.5f);
    }
}
