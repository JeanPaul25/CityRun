using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsGenerator : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject ammo;
    [SerializeField] private GameObject turbo;
    [SerializeField] private GameObject fix;
    private float[] probs;
    private int actualProb, enemy;

    void OnTriggerExit2D(Collider2D collision)
    {
        probs = globalValues.GetProbs();
        if (collision.tag == "Terrain" && globalValues.IsPlaying)
        {
            GenerateEnemy();
            GenerateAmmo();
            if (!GenerateAmmo())
            {
                GenerateTurbo();
                if (!GenerateTurbo())
                {
                    GenerateFix();
                }
            }
        }
    }

    private void GenerateEnemy()
    {
        actualProb = Random.Range(0, 101);
        if (actualProb < probs[0])
        {
            enemy = Random.Range(0, 2);
            Instantiate(enemies[enemy], new Vector2(-20, Random.Range(-4f, 1.5f)), Quaternion.identity);
        }
    }
    private bool GenerateAmmo()
    {
        actualProb = Random.Range(0, 101);
        if (actualProb < probs[1])
        {
            Instantiate(ammo, new Vector2(18.5f, Random.Range(-4f, 1f)), Quaternion.identity);
            return true;
        }
        return false;
    }

    private bool GenerateTurbo()
    {
        actualProb = Random.Range(0, 101);
        if (actualProb < probs[2])
        {
            Instantiate(turbo, new Vector2(18.5f, Random.Range(-4f, 1f)), Quaternion.identity);
            return true;
        }
        return false;
    }

    private bool GenerateFix()
    {
        actualProb = Random.Range(0, 101);
        if (actualProb < probs[3])
        {
            Instantiate(fix, new Vector2(18.5f, Random.Range(-4f, 1f)), Quaternion.identity);
            return true;
        }
        return false;
    }
}
