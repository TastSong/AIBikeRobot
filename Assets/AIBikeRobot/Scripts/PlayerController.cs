using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyRoads3Dv3;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
   
    private Rigidbody rig;
    private float length;
    private enum PosType{
        LEFT = 0,
        CENTER = 1,
        RIGHT = 2
    }

    private PosType posType = PosType.CENTER;

    private void Start() {
        rig = GetComponent<Rigidbody>();
        GameController.instance.routeManger.InitPoint(GameController.instance.routeNet.allRoutes[0].positions.ToArray());
    }

    private void Update() {     
        if (Input.GetKeyDown(KeyCode.A)) {
            posType = PosType.LEFT;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            posType = PosType.CENTER;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            posType = PosType.RIGHT;
        }

        length += Time.deltaTime * speed;
        if (length >= GameController.instance.routeManger.centerPoints.Count - 1) {
            length = GameController.instance.routeManger.centerPoints.Count - 1;
        }

        if (posType == PosType.LEFT) {
            rig.transform.localPosition = GameController.instance.routeManger.leftPoints[(int)(length)];
        } else if (posType == PosType.CENTER) {
            rig.transform.localPosition = GameController.instance.routeManger.centerPoints[(int)(length)];
        } else {
            rig.transform.localPosition = GameController.instance.routeManger.rightPoints[(int)(length)];
        }
        
    }
}
