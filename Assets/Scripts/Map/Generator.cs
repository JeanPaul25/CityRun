using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] Values posX;
    [SerializeField] GameObject[] builds;
    [SerializeField] GameObject[] roads;
    [SerializeField] GameObject[] terrains;
    bool triggered = false;

    private void Awake() {
        triggered = false;   
    }    

    //Al detectar un trigger genera un nuevo bloque de terreno
    private void OnTriggerEnter2D(Collider2D other) {
        //Condicional para que cada bloque genere un nuevo terreno una única vez
        if (!triggered)
        {
            float actualPosX = posX.PoxS;
            Instantiate(builds[0], new Vector2 (actualPosX, 0f), Quaternion.identity);
            Instantiate(roads[0], new Vector2 (actualPosX, -1.5f), Quaternion.identity);
            Instantiate(terrains[0], new Vector2 (actualPosX, 5f), Quaternion.identity);
            posX.AddPos();    
            triggered = true;     
        }
    }
}
