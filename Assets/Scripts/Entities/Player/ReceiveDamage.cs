using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamage : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Player player;
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            player.ChangeHealth(-1);
            StartCoroutine(GetDamage());
        }
        if (collision.tag == "Bullet")
        {
            if (collision.GetComponent<Bullet>().GetShooterTag() == "Enemy")
            {
                player.ChangeHealth(-1);
                Destroy(collision.gameObject);
                StartCoroutine(GetDamage());
            }
        }
        if (player.GetHealth() == 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator GetDamage()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = Color.white;
    }
}
