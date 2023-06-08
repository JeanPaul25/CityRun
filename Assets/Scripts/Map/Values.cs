using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Almacen de variable global para considerar la posición de generación de los nuevos terrenos
[CreateAssetMenu]
public class Values : ScriptableObject
{
    [SerializeField] private float posX;

    public float PoxS {get => posX;}

    public void AddPos(){
        posX += 4f;
    }
}
