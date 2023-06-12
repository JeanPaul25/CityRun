using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    [SerializeField] float offsetX;
    [SerializeField] float positionZ;
    private float positionX;
    private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = objectToFollow.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        positionX = objectToFollow.transform.position.x;
        if (positionX > previousPosition.x)
        {
            transform.position = new Vector3(positionX + offsetX, 0, positionZ);
            previousPosition = objectToFollow.transform.position;
        }
    }
}
