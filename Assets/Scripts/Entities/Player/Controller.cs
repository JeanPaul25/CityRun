using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Values globalValues;
    [SerializeField] float verticalVelocity = 0, horizontalVelocity = 0;

    private void Awake()
    {
        //Reinicia la posición en x del primer bloque de terreno a generar y la velocidad del carro
        globalValues.Reset();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (verticalVelocity >= 0)
        {
            verticalVelocity = (Input.GetKey(KeyCode.W)) ? verticalVelocity += 1f : verticalVelocity -= 0.5f;
            verticalVelocity = (Input.GetKey(KeyCode.S)) ? verticalVelocity -= 0.5f : verticalVelocity;
        }
        else
        {
            verticalVelocity = (Input.GetKey(KeyCode.S)) ? verticalVelocity -= 1f : verticalVelocity += 0.5f;
            verticalVelocity = (Input.GetKey(KeyCode.W)) ? verticalVelocity += 0.5f : verticalVelocity;

        }
        //if (horizontalVelocity >= 0)
        //{
        //    horizontalVelocity = (Input.GetKey(KeyCode.D)) ? horizontalVelocity += 0.1f : horizontalVelocity -= 0.05f;
        //    horizontalVelocity = (Input.GetKey(KeyCode.A)) ? horizontalVelocity -= 0.5f : horizontalVelocity;
        //}
        //else
        //{
        //    horizontalVelocity = (Input.GetKey(KeyCode.A)) ? horizontalVelocity -= 0.1f : horizontalVelocity += 0.05f;
        //    horizontalVelocity = (Input.GetKey(KeyCode.D)) ? horizontalVelocity += 0.5f : horizontalVelocity;
        //}
        verticalVelocity = Mathf.Clamp(verticalVelocity, -10f, 10);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(globalValues.VelocityCars + horizontalVelocity, verticalVelocity);
        globalValues.AlterVelocityCars();
    }
}