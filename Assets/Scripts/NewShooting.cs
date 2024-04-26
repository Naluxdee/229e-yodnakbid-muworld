using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab �ͧ����ع
    public Transform firePoint; // �ش�����ԧ�ҡ
    public float projectileSpeed = 10f; // �������Ǣͧ����ع

    void Update()
    {
        // ��Ҽ����蹡���ԡ����
        if (Input.GetMouseButtonDown(0))
        {
            // �ҵ��˹�������� ���㹷�����͵��˹觢ͧ������
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // �ԧ����ع
            ShootProjectile(target);
        }
    }

    void ShootProjectile(Vector2 target)
    {
        // �ӹǳ�������Ǣͧ����ع�����ԧ
        Vector2 velocity = CalculateProjectileVelocity(firePoint.position, target, projectileSpeed);

        // ���ҧ����ԧ����ع
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float speed)
    {
        Vector2 distance = target - origin;

        // �ӹǳ�������Ǣͧ����ع
        float velocityX = distance.x * speed;
        float velocityY = distance.y * speed + 0.5f * Mathf.Abs(Physics2D.gravity.y) * speed;

        Vector2 result = new Vector2(velocityX, velocityY);
        return result;
    }
}
