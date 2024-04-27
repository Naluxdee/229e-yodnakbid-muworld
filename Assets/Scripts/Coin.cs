using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 1; // เพิ่มคะแนนทีละ 1 ทุกครั้งที่ Player รับเหรียญ

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ตรวจสอบว่า Player ชนกับเหรียญหรือไม่
        {
            GameManager.instance.AddScore(scoreValue); // เรียกใช้ฟังก์ชันใน GameManager เพื่อเพิ่มคะแนน
            Destroy(gameObject); // ทำลายเหรียญหลังจาก Player เก็บไปแล้ว
        }
    }
}
