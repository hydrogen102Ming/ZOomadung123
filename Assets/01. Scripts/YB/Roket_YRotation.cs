using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roket_YRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // ȸ�� �ӵ�
    public float minYRotation = 0f;   // �ּ� y �� ȸ�� ��
    public float maxYRotation = 360f; // �ִ� y �� ȸ�� ��

    private Quaternion initialRotation;   // �ʱ� ȸ�� ��

    void Start()
    {
        // �ʱ� ȸ�� ���� ����
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // ������Ʈ ȸ��
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // y �� ȸ�� ���� min�� max ���� ����� �ʵ��� ����
        float currentYRotation = transform.rotation.eulerAngles.y;
        if (currentYRotation < minYRotation)
        {
            currentYRotation = minYRotation;
        }
        else if (currentYRotation > maxYRotation)
        {
            currentYRotation = maxYRotation;
        }

        // ������Ʈ�� �ʱ� y ȸ�� ���� �����ϸ鼭 ȸ��
        transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, currentYRotation, initialRotation.eulerAngles.z);
    }
}

