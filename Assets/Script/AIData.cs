using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//��script�����ŧi�i�H�Q�ݨ�
public class AIData
{
    public GameObject chaser;
    public float objectSpeed;
    public float max_ObjectSpeed;
    public float max_TurnFreq;

    [HideInInspector]
    public Vector3 target_Pos;
    [HideInInspector]
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
