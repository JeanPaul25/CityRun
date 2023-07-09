using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GlobalValues globalValues;
    private AudioSystem audioSystem;

    private void Awake()
    {
        audioSystem = FindObjectOfType<AudioSystem>();
    }

    void Update()
    {
        if (globalValues.IsPlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (gameObject.GetComponent<Player>().GetAmmo() > 0)
                {
                    audioSystem.PlayerShoot();

                    GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePosition.z = 0f;

                    newBullet.GetComponent<Bullet>().SetTarget(mousePosition, tag);
                    gameObject.GetComponent<Player>().ChangeAmmo(-1);
                }
            }
        }
    }
}
