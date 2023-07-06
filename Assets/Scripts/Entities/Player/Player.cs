using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public GlobalValues globalValues;
    [SerializeField] AudioClip[] audios;
    private float horizontal, vertical, speed = 5, turbo;
    private int health = 10;
    private Animator animator;
    private AudioSource audio;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        StartCoroutine(globalValues.ContinousSpeed());
        StartCoroutine(globalValues.ReduceTime());
        StartCoroutine(globalValues.CountDistance());
        animator = gameObject.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.volume = 0.15f;
        audio.PlayOneShot(audios[0]);   
    }

    private void Awake()
    {
        globalValues.Reset();
    }

    private void FixedUpdate()
    {
        animator.speed = globalValues.GetPlayerSpeed / 10;
        Movement();
        switch (globalValues.GetPlayerSpeed)
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
        globalValues.ChangePlayerHealth(change);
    }

    public int GetHealth()
    {
        return globalValues.GetPlayerHealth;
    }

    public void ChangeAmmo(int change)
    {
        globalValues.ChangeAmmo(change);
    }

    public int GetAmmo()
    {
        return globalValues.GetAmmo;
    }

    private void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            turbo = (globalValues.GetTurbo > 0) ? 5 : 0;
            globalValues.ReduceTurbo();
        }
        transform.Translate(new Vector2(horizontal * (speed + turbo) * Time.deltaTime, vertical * (speed + turbo) * Time.deltaTime));
        globalValues.SetPlayerPosition(transform.position);
    }
}