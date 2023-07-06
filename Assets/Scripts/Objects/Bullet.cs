using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float velocity = 10f;
    [SerializeField] GlobalValues globalValues;
    private Vector3 direction;
    private string shooterTag;

    public void SetTarget(Vector3 targetPosition, string tag)
    {
        direction = (targetPosition - transform.position).normalized;
        shooterTag = tag;
    }

    void FixedUpdate()
    {
        transform.up = direction.normalized;
        transform.position += direction * (globalValues.GetPlayerSpeed + velocity) * Time.fixedDeltaTime;
    }

    public string GetShooterTag()
    {
        return shooterTag;
    }
}
