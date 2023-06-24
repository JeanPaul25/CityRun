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
    [SerializeField] private float speed;
    [SerializeField] private float enemyVerticalSpeed;
    [SerializeField] private bool day = true;

    //Variables para los enemigos
    [SerializeField] private float enemySpeed;
    [SerializeField] private int enemyHealth;

    //Probabilidades de generacion
    [SerializeField] private float enemySpawnProb;
    [SerializeField] private float ammoSpawnProb;
    [SerializeField] private float turboSpawnProb;
    [SerializeField] private float fixSpawnProb;

    private Vector3 playerPosition;

    public float Speed { get => speed; }
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
            speed += 0.5f;
            speed = Mathf.Clamp(speed, 0, 25);
            yield return new WaitForSeconds(1);
        }
    }

    public void AddSpeed(int turbo)
    {
        speed += turbo;
        speed = Mathf.Clamp(speed, 0, 25);
    }

    public void ReduceSpeed(float reduce)
    {
        speed -= reduce;
        speed = Mathf.Clamp(speed, 0, 25);
    }

    public void Reset()
    {
        speed = 0;
        enemySpeed = 10;
        enemyVerticalSpeed = 5;
        enemyHealth = 5;
        enemySpawnProb = 5;
        ammoSpawnProb = 2.5f;
        turboSpawnProb = 2.5f;
        fixSpawnProb = 2.5f;
    }
}
