using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float deathTime;

    void Start()
    {
        Invoke(nameof(Death), deathTime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall") Death();
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
