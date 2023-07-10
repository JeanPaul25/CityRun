using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] AudioClip[] audios;
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    public void PlayerShoot()
    {
        audio.PlayOneShot(audios[0], 0.5f);
    }

    public void EnemyShoot()
    {
        audio.PlayOneShot(audios[1], 0.05f);
    }

    public void PowerUp()
    {
        audio.PlayOneShot(audios[2], 0.25f);
    }
}
