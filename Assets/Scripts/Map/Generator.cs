using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] Values globalValues;
    private GameObject[] builds;
    private GameObject[] roads;
    private GameObject[] terrains;
    bool created = false;

    private void Awake() {
        created = false;      
    }

    private void Start()
    {
        builds = Resources.LoadAll<GameObject>("Prefabs/Map/Builds");
        roads = Resources.LoadAll<GameObject>("Prefabs/Map/Roads");
        terrains = Resources.LoadAll<GameObject>("Prefabs/Map/Terrains");
    }

    //Al detectar un trigger genera un nuevo bloque de terreno
    private void OnTriggerEnter2D(Collider2D other) {
        //Condicional para que cada bloque genere un nuevo terreno una única vez
        if (!created)
        { 
            float actualPosX = globalValues.PoxS;
            Instantiate(builds[Random.Range(0, 9)], new Vector2 (actualPosX, 0f), Quaternion.identity);
            Instantiate(roads[0], new Vector2 (actualPosX, -1.5f), Quaternion.identity);
            Instantiate(terrains[0], new Vector2 (actualPosX, 5f), Quaternion.identity);
            globalValues.AddPos();    
            created = true;     
        }
    }
}
