using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�s�W
        Debug.Log("�}�� Steering");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Seek(AIData data)
    {
        Vector3 current_pos = data.chaser.transform.position;
        Vector3 target_pos = data.vTarget;

        Vector3 vec_target = target_pos - current_pos;
        var twopoint_dis=vec_target.magnitude;

        Vector3 vec_forward = data.chaser.transform.forward;
        Vector3 vec_right = data.chaser.transform.right;

        vec_target.Normalize();
        float vec_seek = Vector3.Dot(vec_forward, vec_target);
        float vec_dir = Vector3.Dot(vec_right, vec_target);


        Debug.Log("���I�Z��"+ twopoint_dis);
        Debug.Log("�O����V"+ vec_seek);
        Debug.Log("�઺��V"+ vec_dir);
    }
}
