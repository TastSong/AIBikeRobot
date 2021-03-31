using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    public float dist = 10.0f;//摄像机距离cube的距离
    public float height = 3.0f;//摄像机的高度
    public float dampTrace = 20.0f;//摄像机跟随的移动速度

    void LateUpdate() {
        transform.position = Vector3.Lerp(transform.position, 
            playerTransform.position + (playerTransform.forward * dist) + Vector3.up * height, 
            dampTrace * Time.deltaTime);
        transform.LookAt(playerTransform.position);
    }
}
