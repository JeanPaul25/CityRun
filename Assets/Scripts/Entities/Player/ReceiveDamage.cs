using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        switch (collision.tag)
        {
            case "Enemy":
                player.ChangeHealth(-1);
                StartCoroutine(GetDamage());
                break;
            case "Bullet":
                if (collision.GetComponent<Bullet>().GetShooterTag() == "Enemy")
                {
                    player.ChangeHealth(-1);
                    Destroy(collision.gameObject);
                    StartCoroutine(GetDamage());
                }
                break;
            case "Goal":
                gameObject.GetComponent<Player>().globalValues.GameOver("Has llegado a la meta");
                break;
        }

        if (player.GetHealth() == 0)
        {
            gameObject.GetComponent<Player>().globalValues.GameOver("Tu choche ha sido destruido");
        }
    }

    private IEnumerator GetDamage()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = Color.white;
    }
}
