using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private GlobalValues globalValues;
    [SerializeField] private GameObject carPlayer;

    [SerializeField] GameObject bullet;

    [SerializeField] private float shootInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootBullet());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (transform.position.x < targetPosition.x)
        {
            transform.Translate(Vector3.right * globalValues.Speed * Time.deltaTime);
        }
    }

    private IEnumerator ShootBullet()
    {
        while (true)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            newBullet.GetComponent<Bullet>().SetTarget(carPlayer.transform.position);

            yield return new WaitForSeconds(shootInterval);
        }
    }
}
