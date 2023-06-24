using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GlobalValues globalValues;
    private float horizontal, vertical, speed = 5;
    protected int health = 10;

    void Start()
    {
        StartCoroutine(globalValues.AddSpeed());
    }

    private void Awake()
    {
        globalValues.Reset();
    }

    private void FixedUpdate()
    {
        Movement();
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeHealth(int change)
    {
        health += change;
    }

    public int GetHealth()
    {
        return health;
    }

    private void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime));
        globalValues.SetPlayerPosition(transform.position);
    }
}