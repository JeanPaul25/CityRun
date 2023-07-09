using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject[] hearths;
    private Vector3 direction;
    private int health;
    private SpriteRenderer spriteRenderer;
    private bool attackMode = true;
    private Animator animator;

    private void Start()
    {
        health = globalValues.EnemyHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ColorHearths();
        animator = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (globalValues.IsPlaying)
        {
            Behaviour();
            animator.speed = globalValues.GetPlayerSpeed / 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                StartCoroutine(MakeDamage());
                globalValues.ReduceSpeed(5);
                break;
            case "Bullet":
                if (collision.GetComponent<Bullet>().GetShooterTag() == "Player")
                {
                    StartCoroutine(GetDamage());
                    health--;
                    ColorHearths();
                    Destroy(collision.gameObject);
                    if (health == 0)
                    {
                        globalValues.CountEnemy1();
                        Destroy(enemy);
                    }
                }
                break;
        }
    }

    private void ColorHearths()
    {
        Color color;
        int i = 1;
        foreach (GameObject hearth in hearths)
        {
            color = (i <= health) ? Color.red : Color.gray;
            hearth.GetComponent<SpriteRenderer>().color = color;
            i++;
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
