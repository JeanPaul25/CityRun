using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float velocity = 10f;
    [SerializeField] GlobalValues globalValues;
    private Vector3 direction;

    public void SetTarget(Vector3 mousePosition)
    {
        direction = (mousePosition - transform.position).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.up = direction.normalized;
        transform.position += direction * (globalValues.Speed + velocity) * Time.fixedDeltaTime;
    }
}
