using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (tag)
            {
                case "Ammo":
                    collision.GetComponent<Player>().ChangeAmmo(5);
                    break;
                case "Turbo":
                    globalValues.AddSpeed(5);
                    break;
                case "Fix":
                    collision.GetComponent<Player>().ChangeHealth(1);
                    break;
            }
        }
    }
}
