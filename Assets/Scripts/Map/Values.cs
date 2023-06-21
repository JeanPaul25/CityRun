using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Almacen de variable global para considerar la posición de generación de los nuevos terrenos
/// </summary>
[CreateAssetMenu]
public class Values : ScriptableObject
{
    [SerializeField] private float posX;
    [SerializeField] private bool day = true;
    public float PoxS { get => posX; }
    public bool Day { get => day; }

    public void AlterDay()
    {
        day = !day;
    }

    public void AddPos()
    {
        posX += 4f;
    }

    public void Reset()
    {
        posX = 14.75f;
    }
}
