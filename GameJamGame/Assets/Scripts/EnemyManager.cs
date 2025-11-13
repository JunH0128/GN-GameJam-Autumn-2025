using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager main;
    public Transform startPoint;
    public Transform[] checkPoints;
    

    void Awake()
    {
        main = this;
    }
}
