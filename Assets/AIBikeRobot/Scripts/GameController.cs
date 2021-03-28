using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    private void Awake() {    //防止存在多个单例
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}
