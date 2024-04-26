using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ใส่ Transform ของผู้เล่นที่ต้องการให้กล้องตาม
    public float smoothSpeed = 0.125f; // ความราบเรียบของการเคลื่อนที่ของกล้อง

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
