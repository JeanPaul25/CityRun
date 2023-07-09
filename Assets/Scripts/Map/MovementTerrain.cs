using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTerrain : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;

    void FixedUpdate()
    {
        if (globalValues.IsPlaying)
        {
            transform.position += Vector3.left * globalValues.GetPlayerSpeed * Time.deltaTime;
        }
    }
}
