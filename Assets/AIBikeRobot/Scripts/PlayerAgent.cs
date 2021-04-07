using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class PlayerAgent : Agent
{
    public float speed = 400;
    public bool isTouch = false;
    public Transform[] playerAgents;

    private Rigidbody rig;
    private float length;

    private enum PosType
    {
        LEFT = 0,
        CENTER = 1,
        RIGHT = 2
    }
    private PosType posType = PosType.CENTER;
    private PosType prePosType = PosType.CENTER;

    private void Start() {
        Debug.Log("start");
        rig = GetComponent<Rigidbody>();
        GameController.instance.routeManger.InitPoint(GameController.instance.routeNet.allRoutes[0].positions.ToArray());
        StartCoroutine(SetPosLine());
    }

    private IEnumerator SetPosLine() {
        while (true) {
            length += Time.deltaTime * speed;
            if (length >= GameController.instance.routeManger.centerPoints.Count - 1) {
                length = 0;
            }

            if (posType == PosType.LEFT) {
                rig.transform.localPosition = GameController.instance.routeManger.leftPoints[(int)(length)];
            } else if (posType == PosType.CENTER) {
                rig.transform.localPosition = GameController.instance.routeManger.centerPoints[(int)(length)];
            } else {
                rig.transform.localPosition = GameController.instance.routeManger.rightPoints[(int)(length)];
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public override void OnEpisodeBegin() {

    }

    public override void CollectObservations(VectorSensor sensor) {
        sensor.AddObservation(transform.position);
        for (int i = 0; i < playerAgents.Length; i++) {
            sensor.AddObservation(playerAgents[i].position);
        }
    }


    public override void OnActionReceived(ActionBuffers actionBuffers) {
        posType = (PosType)actionBuffers.DiscreteActions[0];
        if (prePosType != posType) {
            Debug.Log("+++++++++++++actionBuffers.DiscreteActions[0] " + actionBuffers.DiscreteActions[0]);
            SetReward(0.1f);
            prePosType = posType;
        }

        // Reached target
        if (isTouch) {
            SetReward(-1.0f);
            isTouch = false;
        } 

        if (length == 0) {
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut) {
        var discreteActions = actionsOut.DiscreteActions;
        if (Input.GetKeyDown(KeyCode.A)) {
            discreteActions[0] = (int)PosType.LEFT;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            discreteActions[0] = (int)PosType.CENTER;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            discreteActions[0] = (int)PosType.RIGHT;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            isTouch = true;
        }
    }
}
