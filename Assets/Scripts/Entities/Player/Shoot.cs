using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.GetComponent<Player>().GetAmmo() > 0)
            {
                GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;

                newBullet.GetComponent<Bullet>().SetTarget(mousePosition, tag);
                gameObject.GetComponent<Player>().ChangeAmmo(-1);
            }
        }
    }
}
