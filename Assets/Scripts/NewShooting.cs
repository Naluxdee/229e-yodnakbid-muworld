using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab �ͧ����ع
    public Transform firePoint; // �ش�����ԧ�ҡ
    public float projectileSpeed = 10f; // �������Ǣͧ����ع
    public float shootDelay = 0.5f; // ���������������ҧ����ԧ

    private bool canShoot = true; // ��������͵�Ǩ�ͺ�������ö�ԧ���������

    void Update()
    {
        // ��Ҽ����蹡���ԡ�����������ö�ԧ��
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    IEnumerator ShootWithDelay()
    {
        // ��駤������������ö�ԧ���ա���Ǥ���
        canShoot = false;

        // �ҷ�ȷҧ�ͧ������
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // �ӹǳ�������Ǣͧ����ع�����ԧ
        Vector2 velocity = CalculateProjectileVelocity(firePoint.position, target, projectileSpeed);

        // �ԧ����ع㹷�ȷҧ���������ѹ˹���
        ShootProjectile(velocity);

        // �����ҵ���������ҷ���˹�
        yield return new WaitForSeconds(shootDelay);

        // ��駤���������ö�ԧ���ա����
        canShoot = true;
    }

    void ShootProjectile(Vector2 velocity)
    {
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
