using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float velocity = 10f;
    [SerializeField] Values velocityCars;

    private Vector3 targetPosition;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetTarget(Vector3 mousePosition)
    {
        targetPosition = mousePosition;

        direction = (targetPosition - transform.position).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += direction * (velocityCars.VelocityCars + velocity) * Time.fixedDeltaTime;
    }
}
