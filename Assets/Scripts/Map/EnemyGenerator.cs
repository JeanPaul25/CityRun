using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    private GameObject[] enemies;
    private int[] probs;
    private int actualProb, enemy;

    private void Start()
    {
        enemies = Resources.LoadAll<GameObject>("Prefabs/Entities/Enemies");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        probs = globalValues.GetProbs();
        if (collision.tag == "Terrain")
        {
            actualProb = Random.Range(0, 101);
            if (actualProb < probs[0])
            {
                enemy = Random.Range(0, 2);
                Instantiate(enemies[enemy], new Vector2(-20, Random.Range(-4f, 1.5f)), Quaternion.identity);
            }
        }
    }
}
