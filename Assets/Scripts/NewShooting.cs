using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab ของกระสุน
    public Transform firePoint; // จุดที่จะยิงจาก
    public float projectileSpeed = 10f; // ความเร็วของกระสุน

    void Update()
    {
        // ถ้าผู้เล่นกดคลิกซ้าย
        if (Input.GetMouseButtonDown(0))
        {
            // หาตำแหน่งเป้าหมาย ซึ่งในที่นี้คือตำแหน่งของเม้าส์
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ยิงกระสุน
            ShootProjectile(target);
        }
    }

    void ShootProjectile(Vector2 target)
    {
        // คำนวณความเร็วของกระสุนที่จะยิง
        Vector2 velocity = CalculateProjectileVelocity(firePoint.position, target, projectileSpeed);

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
