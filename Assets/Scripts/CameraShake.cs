using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float cameraShakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;


    void Start()
    {
        initialPosition = transform.position;

    }

    public void ShakeCamera()
    {
        StartCoroutine(Shake());
    }


    IEnumerator Shake()
    {
        // lắc camera khi bằng Random.insideUnitCircle(2D) nếu dùng 3D thì là insideUnitSphere(3D), r * với shakeMagnitude tạo sẵn

        // biến lưu tgian để loop hàm lắc cam
        float elapsedTime = 0;

        while (elapsedTime < cameraShakeDuration) 
        {
            // transform.position là Vector 3, insideUnitCircle là Vector2 vì v mình phải quy đổi
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            // cộng thời gian thực vào biến elapsedTime
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        // chỉnh lại vị trí của cam
        transform.position = initialPosition;

    }

}
