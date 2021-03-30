using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManger : MonoBehaviour
{
    public static List<Vector3> lsPoint = new List<Vector3>();
    public int baseCount = 50;  //两个基础点之间的取点数量   值越大曲线就越平滑  但同时计算量也也越大
    public LineRenderer lineRender;

    //初始化算出所有的点的信息
    public List<Vector3> InitPoint(Vector3[] basePoint) {
        //获取指定的点的信息
        Vector3[] pointPos = new Vector3[basePoint.Length];
        for (int i = 0; i < basePoint.Length; i++) {
            pointPos[i].x = basePoint[i].x;
            pointPos[i].y = basePoint[i].y + 0.8f;
            pointPos[i].z = basePoint[i].z;
        }
        GetTrackPoint(pointPos);
        return lsPoint;
    }

    /// <summary>
    /// 根据设定节点 绘制指定的曲线
    /// </summary>
    /// <param name="track">所有指定节点的信息</param>
    private void GetTrackPoint(Vector3[] track) {
        Vector3[] vector3s = PathControlPointGenerator(track);
        int SmoothAmount = track.Length * baseCount;
        lineRender.positionCount = SmoothAmount;
        for (int i = 1; i < SmoothAmount; i++) {
            float pm = (float)i / SmoothAmount;
            Vector3 currPt = Interp(vector3s, pm);
            lineRender.SetPosition(i, currPt);
            lsPoint.Add(currPt);
        }
    }

    /// <summary>
    /// 计算所有节点以及控制点坐标
    /// </summary>
    /// <param name="path">所有节点的存储数组</param>
    /// <returns></returns>
    private Vector3[] PathControlPointGenerator(Vector3[] path) {
        Vector3[] suppliedPath;
        Vector3[] vector3s;

        suppliedPath = path;
        int offset = 2;
        vector3s = new Vector3[suppliedPath.Length + offset];
        Array.Copy(suppliedPath, 0, vector3s, 1, suppliedPath.Length);
        if (vector3s.Length > 3) {
            vector3s[0] = vector3s[1] + (vector3s[1] - vector3s[2]);
        }
        if ((vector3s.Length - 2) > 0) {
            vector3s[vector3s.Length - 1] = vector3s[vector3s.Length - 2] + (vector3s[vector3s.Length - 2] - vector3s[vector3s.Length - 3]);
            if (vector3s[1] == vector3s[vector3s.Length - 2]) {
                Vector3[] tmpLoopSpline = new Vector3[vector3s.Length];
                Array.Copy(vector3s, tmpLoopSpline, vector3s.Length);
                tmpLoopSpline[0] = tmpLoopSpline[tmpLoopSpline.Length - 3];
                tmpLoopSpline[tmpLoopSpline.Length - 1] = tmpLoopSpline[2];
                vector3s = new Vector3[tmpLoopSpline.Length];
                Array.Copy(tmpLoopSpline, vector3s, tmpLoopSpline.Length);
            }
        }

        return (vector3s);
    }


    /// <summary>
    /// 计算曲线的任意点的位置
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    private Vector3 Interp(Vector3[] pos, float t) {
        int length = pos.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * length), length - 1);
        float u = t * (float)length - (float)currPt;
        Vector3 a = pos[currPt];
        Vector3 b = pos[currPt + 1];
        Vector3 c = pos[currPt + 2];
        Vector3 d = pos[currPt + 3];
        return .5f * (
           (-a + 3f * b - 3f * c + d) * (u * u * u)
           + (2f * a - 5f * b + 4f * c - d) * (u * u)
           + (-a + c) * u
           + 2f * b
       );
    }
}
