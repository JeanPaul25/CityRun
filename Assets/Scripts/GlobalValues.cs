using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Almacen de variables globales
/// </summary>
[CreateAssetMenu]
public class GlobalValues : ScriptableObject
{
    //Variables globales
    [SerializeField] private float playerSpeed;
    [SerializeField] private float enemyVerticalSpeed;
    [SerializeField] private bool day = true;
    private Vector3 playerPosition;
    private int time;

    //Variables para los enemigos
    [SerializeField] private float enemySpeed;
    [SerializeField] private int enemyHealth;

    //Probabilidades de generacion
    [SerializeField] private float enemySpawnProb;
    [SerializeField] private float ammoSpawnProb;
    [SerializeField] private float turboSpawnProb;
    [SerializeField] private float fixSpawnProb;

    public float Speed { get => playerSpeed; }
    public float Time { get => time; }
    public float EnemySpeed { get => enemySpeed; }
    public float EnemyVerticalSpeed { get => enemyVerticalSpeed; }
    public bool Day { get => day; }
    public int EnemyHealth { get => enemyHealth; }
    public Vector3 PlayerPosition { get => playerPosition; }

    public void SetPlayerPosition(Vector3 playerPosition)
    {
        this.playerPosition = playerPosition;
    }

    public float[] GetProbs()
    {
        float[] probs = { enemySpawnProb, ammoSpawnProb, turboSpawnProb, fixSpawnProb };
        return probs;
    }

    public void AlterDay()
    {
        day = !day;
    }

    public IEnumerator ContinousSpeed()
    {
        while (true)
        {
            playerSpeed += 0.5f;
            playerSpeed = Mathf.Clamp(playerSpeed, 0, 25);
            yield return new WaitForSeconds(1);
        }
    }
    public IEnumerator AddTime()
    {
        while (true)
        {
            time++;
            yield return new WaitForSeconds(1);
        }
    }

    public void AddSpeed(int turbo)
    {
        playerSpeed += turbo;
        playerSpeed = Mathf.Clamp(playerSpeed, 0, 25);
    }

    public void ReduceSpeed(float reduce)
    {
        playerSpeed -= reduce;
        playerSpeed = Mathf.Clamp(playerSpeed, 0, 25);
    }

    public void Reset()
    {
        playerSpeed = 0;
        time = 0;
        enemySpeed = 10;
        enemyVerticalSpeed = 5;
        enemyHealth = 5;
        enemySpawnProb = 5;
        ammoSpawnProb = 2.5f;
        turboSpawnProb = 2.5f;
        fixSpawnProb = 2.5f;
    }

}
