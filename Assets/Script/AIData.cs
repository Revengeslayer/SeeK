using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//讓script內的宣告可以被看到
public class AIData
{
    public GameObject chaser;
    [HideInInspector]
    public Vector3 vTarget;
    [HideInInspector]
    public float seek_Force;
    [HideInInspector]
    public float turnForce;
    [HideInInspector]
    public Vector3 vec_Current;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("開啟AIDATA");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
