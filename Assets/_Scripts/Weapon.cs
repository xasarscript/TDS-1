using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;
    [SerializeField] private SpriteRenderer GunSprite;

    void Update()
    {
        GunRotation();
        GunFlip();
    }

    void GunRotation()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void GunFlip()
    {
        float x = transform.eulerAngles.z;
        bool isFlipped = (x > 90 && x < 270);
        transform.localScale = new Vector3(1, isFlipped ? -1 : 1, 1);
    }
}