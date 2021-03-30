using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyRoads3Dv3;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public RouteNet routeNet;
   
    private Rigidbody rig;
    private float length;
    private static List<Vector3> lsPoint = new List<Vector3>();

    private void Start() {
        rig = GetComponent<Rigidbody>();

        lsPoint = GameController.instance.routeManger.InitPoint(routeNet.allRoutes[1].positions.ToArray());
    }

    private void Update() {
        length += Time.deltaTime * speed;
        if (length >= lsPoint.Count - 1) {
            length = lsPoint.Count - 1;
        }
        rig.transform.localPosition = lsPoint[(int)(length)];

        //控制移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rig.MovePosition(transform.position + new Vector3(-h, 0, -v * 1.6f) * speed * Time.deltaTime);
        rig.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, h * 2.4f, 0) * speed * Time.deltaTime));
    }

   
}
