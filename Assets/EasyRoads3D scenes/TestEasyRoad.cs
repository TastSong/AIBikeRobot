using EasyRoads3Dv3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEasyRoad : MonoBehaviour
{
    public ERRoad[] markers;
    public ERRoadNetwork roadNetwork;

    private void Start() {
        BuildAllRoute();
    }
    private void BuildAllRoute() {
        markers = roadNetwork.GetRoads();
        for (int i = 0; i < markers.Length; i++) {
            Debug.Log( i + "  GetMarkerPositions  = " + markers[i].GetMarkerPositions());
            Debug.Log( i + "  GetSplinePointsCenter  = " + markers[i].GetSplinePointsCenter());
        }
    }
}
