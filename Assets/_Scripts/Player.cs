using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float timeBtwShoot;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPosition;
    
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float shootTimer;

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private GameObject gun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootTimer = timeBtwShoot;
    }
    
    void Update()
    {
        Shoot();
        Flip();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetBool("walk", moveinput != Vector2.zero);
        moveVelocity = moveinput.normalized * speed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void Flip()
    {
        float z = gun.transform.eulerAngles.z;
        if (z > 90 && z < 270 ) playerSprite.flipX = true;
        else playerSprite.flipX = false;
    }

    void Shoot()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && shootTimer >= timeBtwShoot)
        { 
            Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
            shootTimer = 0;
        }
    }
}
