using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private GlobalValues globalValues;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject bullet;
    [SerializeField] private float shootInterval = 2f;
    [SerializeField] GameObject[] hearths;

    private bool verticalDirection;
    private Vector3 verticalMovement;
    private SpriteRenderer spriteRenderer;
    private int health;
    private Animator animator;
    private AudioSystem audioSystem;

    private void Awake()
    {
        audioSystem = FindObjectOfType<AudioSystem>();
    }

    void Start()
    {
        health = globalValues.EnemyHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ShootBullet());
        ColorHearths();
        animator = gameObject.GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        animator.speed = globalValues.GetPlayerSpeed / 10;
        if (globalValues.IsPlaying)
        {
            if (transform.position.x < 11)
            {
                transform.Translate(Vector3.right * globalValues.EnemySpeed * Time.deltaTime);
            }
            else
            {
                verticalMovement = verticalDirection ? Vector3.up : Vector3.down;
                transform.Translate(verticalMovement * globalValues.EnemyVerticalSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Walls":
                verticalDirection = !verticalDirection;
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
                        globalValues.CountEnemy2();
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

    private IEnumerator ShootBullet()
    {
        while (globalValues.IsPlaying)
        {
            audioSystem.EnemyShoot();

            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            newBullet.GetComponent<Bullet>().SetTarget(globalValues.PlayerPosition, tag);

            yield return new WaitForSeconds(shootInterval);
        }
    }
    private IEnumerator GetDamage()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = Color.white;
    }
}
