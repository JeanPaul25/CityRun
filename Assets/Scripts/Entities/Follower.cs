using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    private Transform toFollow;

    void Start()
    {
        toFollow = objectToFollow.transform;
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(toFollow.position.x, toFollow.position.y);
    }
}
