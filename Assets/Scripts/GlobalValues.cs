using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Almacen de variables globales
/// </summary>
[CreateAssetMenu]
public class GlobalValues : ScriptableObject
{
    //Variables globales
    [SerializeField] private float playerSpeed;
    [SerializeField] private float enemyVerticalSpeed;
    private Vector3 playerPosition;
    private int time, ammo, playerHealth, countEnemy1, countEnemy2;
    private float totalDistance, turbo, totalScore;
    private bool playing, generateGoal;
    private String gameOver;

    //Variables para los enemigos
    [SerializeField] private float enemySpeed;
    [SerializeField] private int enemyHealth;

    //Probabilidades de generacion
    [SerializeField] private float enemySpawnProb;
    [SerializeField] private float ammoSpawnProb;
    [SerializeField] private float turboSpawnProb;
    [SerializeField] private float fixSpawnProb;

    public float GetPlayerSpeed { get => playerSpeed; }
    public float GetTime { get => time; }
    public float EnemySpeed { get => enemySpeed; }
    public float EnemyVerticalSpeed { get => enemyVerticalSpeed; }
    public int EnemyHealth { get => enemyHealth; }
    public int GetAmmo { get => ammo; }
    public int GetPlayerHealth { get => playerHealth; }
    public Vector3 PlayerPosition { get => playerPosition; }
    public float GetTotalDistance { get => totalDistance; }
    public float GetTurbo { get => turbo; }
    public bool IsGenerateGoal { get => generateGoal; }
    public String GetGameOver { get => gameOver; }
    public float GetTotalScore { get => totalScore; } 

    public void ChangePlaying()
    {
        playing = !playing;
    }

    public void SetPlayerPosition(Vector3 playerPosition)
    {
        this.playerPosition = playerPosition;
    }

    public float[] GetProbs()
    {
        float[] probs = { enemySpawnProb, ammoSpawnProb, turboSpawnProb, fixSpawnProb };
        return probs;
    }

    public IEnumerator ContinousSpeed()
    {
        while (true)
        {
            playerSpeed += 0.1f;
            playerSpeed = Mathf.Clamp(playerSpeed, 0, 26);
            yield return new WaitForSeconds(0.1f);
        }
    }
    public IEnumerator ReduceTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time--;
            if(time == 0)
            {
                GameOver("Se acabó el tiempo");
            }
        }
    }
    public IEnumerator CountDistance()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            totalDistance += playerSpeed * 0.277778f;
            if (totalDistance >= 3000)
            {
                GenerateGoal();
            }
        }
    }

    public void GenerateGoal()
    {
        generateGoal = true;
    }

    public void GameOver(String reason)
    {
        this.gameOver = reason;
        totalScore = (totalDistance * 1.5f) + (countEnemy1 * 0.5f) + (countEnemy2 * 0.7f) + ((time - 60) * 0.5f);
        Debug.Log(totalScore);
        SceneManager.LoadScene("Score");
    }

    public void AddTurbo(int change)
    {
        turbo += change;
        turbo = Mathf.Clamp(turbo, 0, 10);
    }

    public void ReduceTurbo()
    {
        turbo -= Time.deltaTime * 2;
        turbo = Mathf.Clamp(turbo, 0, 10);
    }

    public void AddSpeed(int turbo)
    {
        playerSpeed += turbo;
        playerSpeed = Mathf.Clamp(playerSpeed, 0, 26);
    }

    public void ReduceSpeed(float reduce)
    {
        playerSpeed -= reduce;
        playerSpeed = Mathf.Clamp(playerSpeed, 0, 26);
    }

    public void ChangeAmmo(int change)
    {
        ammo += change;
    }

    public void ChangePlayerHealth(int change)
    {
        playerHealth += change;
    }

    public void CountEnemy1()
    {
        countEnemy1++;
    }

    public void CountEnemy2()
    {
        countEnemy2++;
    }

    public void Reset()
    {
        playerSpeed = 0;
        time = 60;
        enemySpeed = 10;
        enemyVerticalSpeed = 5;
        enemyHealth = 5;
        enemySpawnProb = 5;
        ammoSpawnProb = 3f;
        turboSpawnProb = 2.5f;
        fixSpawnProb = 2f;
        ammo = 15;
        playerHealth = 5;
        totalDistance = 0;
        playing = true;
        turbo = 5;
        countEnemy1 = 0;
        countEnemy2 = 0;
        generateGoal = false;
    }
}