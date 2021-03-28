using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyRoads3Dv3;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public ERModularBase modularBase;

    private Rigidbody rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        //控制移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rigidbody.MovePosition(transform.position + new Vector3(-h, 0, -v * 1.6f) * speed * Time.deltaTime);
        rigidbody.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, h * 2.4f, 0) * speed * Time.deltaTime));
    }
        
}
