using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    [SerializeField] AudioClip[] audios;
    private float horizontal, vertical, speed = 5;
    private int health = 10, ammo = 10;
    private Animator animator;
    private AudioSource audio;

    void Start()
    {
        StartCoroutine(globalValues.ContinousSpeed());
        StartCoroutine(globalValues.AddTime());
        animator = gameObject.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.volume = 0.25f;
        audio.PlayOneShot(audios[0]);
    }

    private void Awake()
    {
        globalValues.Reset();
    }

    private void FixedUpdate()
    {
        animator.speed = globalValues.Speed / 10;
        Movement();
        if (health == 0)
        {
            Destroy(gameObject);
        }
        switch (globalValues.Speed)
        {
            case < 10:
                audio.clip = audios[1];
                break;
            case < 20:
                audio.clip = audios[2];
                break;
            case < 30:
                audio.clip = audios[3];
                break;
        }
        audio.Play();
    }

    public void ChangeHealth(int change)
    {
        health += change;
    }

    public int GetHealth()
    {
        return health;
    }

    public void ChangeAmmo(int change)
    {
        ammo += change;
    }

    public int GetAmmo()
    {
        return ammo;
    }

    private void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime));
        globalValues.SetPlayerPosition(transform.position);
    }
}