using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    private Vector3 direction;
    private int health;
    private SpriteRenderer spriteRenderer;
    private bool attackMode = true;

    private Transform playerTransform;
    private void Start()
    {
        health = globalValues.EnemyHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Behaviour();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(MakeDamage());
            globalValues.ReduceSpeed(5);
        }
        if (collision.tag == "Bullet")
        {
            health--;
            if (health == 0)
            {
                Destroy(gameObject);
            }
            StartCoroutine(GetDamage());
        }
    }

    private void Behaviour()
    {
        direction = (globalValues.PlayerPosition - transform.position).normalized;
        if (attackMode)
        {
            transform.position += direction * (globalValues.EnemySpeed) * Time.fixedDeltaTime;
        }
        else
        {
            if (transform.position.x > -12f && transform.position.x < 12f && transform.position.y > -4f && transform.position.y < 1.5f)
            {
                transform.position -= direction * (globalValues.EnemySpeed) * Time.fixedDeltaTime;
            }
        }
    }

    private IEnumerator MakeDamage()
    {
        attackMode = false;
        yield return new WaitForSeconds(1);
        attackMode = true;
    }

    private IEnumerator GetDamage()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = Color.white;
    }
}
