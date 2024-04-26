using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab ของกระสุน
    public Transform firePoint; // จุดที่จะยิงจาก
    public float projectileSpeed = 10f; // ความเร็วของกระสุน
    public float shootDelay = 0.5f; // ระยะเวลารอระหว่างการยิง

    private bool canShoot = true; // ตัวแปรเพื่อตรวจสอบว่าสามารถยิงได้หรือไม่

    void Update()
    {
        // ถ้าผู้เล่นกดคลิกซ้ายและสามารถยิงได้
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    IEnumerator ShootWithDelay()
    {
        // ตั้งค่าให้ไม่สามารถยิงได้อีกชั่วคราว
        canShoot = false;

        // หาทิศทางของเม้าส์
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // คำนวณความเร็วของกระสุนที่จะยิง
        Vector2 velocity = CalculateProjectileVelocity(firePoint.position, target, projectileSpeed);

        // ยิงกระสุนในทิศทางที่ผู้เล่นหันหน้าไป
        ShootProjectile(velocity);

        // รอเวลาตามระยะเวลาที่กำหนด
        yield return new WaitForSeconds(shootDelay);

        // ตั้งค่าให้สามารถยิงได้อีกครั้ง
        canShoot = true;
    }

    void ShootProjectile(Vector2 velocity)
    {
        // สร้างและยิงกระสุน
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float speed)
    {
        Vector2 distance = target - origin;

        // คำนวณความเร็วของกระสุน
        float velocityX = distance.x * speed;
        float velocityY = distance.y * speed + 0.5f * Mathf.Abs(Physics2D.gravity.y) * speed;

        Vector2 result = new Vector2(velocityX, velocityY);
        return result;
    }
}
