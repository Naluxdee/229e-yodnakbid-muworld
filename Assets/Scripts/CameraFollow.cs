using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ��� Transform �ͧ�����蹷���ͧ��������ͧ���
    public float smoothSpeed = 0.125f; // �����Һ���º�ͧ�������͹���ͧ���ͧ

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
