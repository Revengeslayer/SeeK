using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//��script�����ŧi�i�H�Q�ݨ�
public class AIData
{
    public float m_fRadius;
    [HideInInspector]
    public Vector3 vTarget;
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
