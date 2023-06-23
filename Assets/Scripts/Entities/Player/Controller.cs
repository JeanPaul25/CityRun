using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    private float horizontal, vertical, speed = 5;

    private void Awake()
    {
        //Reinicia la posición en x del primer bloque de terreno a generar y la velocidad del carro
        globalValues.Reset();
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime));
    }
}