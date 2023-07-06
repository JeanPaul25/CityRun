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
    private Vector3 playerPosition;
    private int time, ammo, playerHealth;
    private float totalDistance, turbo;
    private bool playing;

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
        while (playing)
        {
            playerSpeed += 0.1f;
            playerSpeed = Mathf.Clamp(playerSpeed, 0, 26);
            yield return new WaitForSeconds(0.1f);
        }
    }
    public IEnumerator ReduceTime()
    {
        while (playing)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
    }

    public IEnumerator CountDistance()
    {
        while (playing)
        {
            yield return new WaitForSeconds(0.1f);
            totalDistance += playerSpeed * 0.277778f; //3500
        }
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

    public void Reset()
    {
        playerSpeed = 0;
        time = 60;
        enemySpeed = 10;
        enemyVerticalSpeed = 5;
        enemyHealth = 5;
        enemySpawnProb = 5;
        ammoSpawnProb = 3.5f;
        turboSpawnProb = 2.5f;
        fixSpawnProb = 2.5f;
        ammo = 15;
        playerHealth = 5;
        totalDistance = 0;
        playing = true;
        turbo = 0;
    }
}