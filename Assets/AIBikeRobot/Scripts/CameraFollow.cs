using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // 移动的物体

    private Vector3 deviation; // 偏移量
    private Vector3 rotationDeviation; // 偏移量

    void Start() {
        transform.LookAt(playerTransform);
        deviation = transform.position - playerTransform.position; // 初始物体与相机的偏移量=相机的位置 - 移动物体的偏移量  
        rotationDeviation = transform.rotation.eulerAngles - playerTransform.rotation.eulerAngles;
    }

    void Update() {
        transform.position = playerTransform.position + deviation; // 相机的位置 = 移动物体的位置 + 偏移量
        transform.rotation = Quaternion.Euler(playerTransform.rotation.eulerAngles + rotationDeviation); // 相机的位置 = 移动物体的位置 + 偏移量
    }
}
