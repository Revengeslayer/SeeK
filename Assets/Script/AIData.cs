using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//��script�����ŧi�i�H�Q�ݨ�
public class AIData
{
    public GameObject chaser;
    [HideInInspector]
    public Vector3 vTarget;
    [HideInInspector]
    public Vector3 Seek_force;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�}��AIDATA");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
