using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roket_YRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // 회전 속도
    public float minYRotation = 0f;   // 최소 y 축 회전 값
    public float maxYRotation = 360f; // 최대 y 축 회전 값

    private Quaternion initialRotation;   // 초기 회전 값

    void Start()
    {
        // 초기 회전 값을 저장
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // 오브젝트 회전
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // y 축 회전 값이 min과 max 값을 벗어나지 않도록 제한
        float currentYRotation = transform.rotation.eulerAngles.y;
        if (currentYRotation < minYRotation)
        {
            currentYRotation = minYRotation;
        }
        else if (currentYRotation > maxYRotation)
        {
            currentYRotation = maxYRotation;
        }

        // 오브젝트의 초기 y 회전 값을 유지하면서 회전
        transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, currentYRotation, initialRotation.eulerAngles.z);
    }
}

