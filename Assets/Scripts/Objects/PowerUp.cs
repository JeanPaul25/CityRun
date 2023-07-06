using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    [SerializeField] float speed = 7.5f;
    private AudioSystem audioSystem;

    private void Awake()
    {
        audioSystem = FindObjectOfType<AudioSystem>();
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSystem.PowerUp();
            gameObject.GetComponent<AudioSource>().Play();
            switch (tag)
            {
                case "Ammo":
                    collision.GetComponent<Player>().ChangeAmmo(5);
                    break;
                case "Turbo":
                    //globalValues.AddSpeed(5);
                    globalValues.AddTurbo(5);
                    break;
                case "Fix":
                    collision.GetComponent<Player>().ChangeHealth(1);
                    break;
            }
            Destroy(gameObject);
        }
    }
}
