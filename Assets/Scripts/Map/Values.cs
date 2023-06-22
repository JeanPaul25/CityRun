using UnityEngine;

/// <summary>
/// Almacen de variable global para considerar la posición de generación de los nuevos terrenos
/// </summary>
[CreateAssetMenu]
public class Values : ScriptableObject
{
    [SerializeField] private float posX;
    [SerializeField] private float velocityCars;
    [SerializeField] private bool day = true;
    public float PoxS { get => posX; }

    public float VelocityCars { get => velocityCars; }

    public bool Day { get => day; }

    public void AlterDay()
    {
        day = !day;
    }

    public void AddPos()
    {
        posX += 4f;
    }

    public void AlterVelocityCars()
    {
        velocityCars += 0.5f;
        velocityCars = Mathf.Clamp(velocityCars, 0f, 50f);
    }

    public void Reset()
    {
        posX = 14.75f;
        velocityCars = 0f;
    }
}
