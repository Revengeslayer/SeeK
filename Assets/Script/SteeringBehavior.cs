using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //·s¼W
        Debug.Log("¶}±Ò Steering");
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
     
        Vector3 force_seek = vec_target - vec_forward;
        Debug.Log("force_seek " + force_seek);
        float force_seek_target = Vector3.Dot(force_seek, vec_forward);
        //force_seek.Normalize();
        float force_seek_dic = Vector3.Dot(force_seek, vec_right);
        Debug.Log("force_seek_target " + force_seek_target);
        Debug.Log("force_seek_dic " + force_seek_dic);
        
    }
}
