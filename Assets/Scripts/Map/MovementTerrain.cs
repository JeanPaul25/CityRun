using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTerrain : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left * globalValues.Speed * Time.deltaTime;
    }
}