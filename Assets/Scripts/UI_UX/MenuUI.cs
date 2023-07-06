using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void BtnJugar()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BtnQuit()
    {
        Application.Quit();
    }
}
