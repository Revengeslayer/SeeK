using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//讓script內的宣告可以被看到
public class AIData
{
    public GameObject chaser;
    public float objectSpeed;
    

    [HideInInspector]
    public Vector3 target_Pos;
    [HideInInspector]
    public float brforce_seek;
    public float accSpeed;
    [HideInInspector]
    public float turnFreq;
    [HideInInspector]
    public Vector3 vec_Current;
    [HideInInspector]
    public bool isMove;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
