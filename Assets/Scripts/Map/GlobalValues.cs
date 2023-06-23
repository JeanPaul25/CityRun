using UnityEngine;

/// <summary>
/// Almacen de variables globales
/// </summary>
[CreateAssetMenu]
public class GlobalValues : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private bool day = true;
   
    public float Speed { get => speed; }

    public bool Day { get => day; }

    public void AlterDay()
    {
        day = !day;
    }

    public void addSpeed()
    {
        speed += 0.5f;
        speed = Mathf.Clamp(speed, 0, 25);
    }

    public void Reset()
    {
        speed = 0f;
    }
}
