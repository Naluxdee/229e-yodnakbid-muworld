using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 1; // ������ṹ���� 1 �ء���駷�� Player �Ѻ����­

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ��Ǩ�ͺ��� Player ���Ѻ����­�������
        {
            GameManager.instance.AddScore(scoreValue); // ���¡��ѧ��ѹ� GameManager ����������ṹ
            Destroy(gameObject); // ���������­��ѧ�ҡ Player �������
        }
    }
}
