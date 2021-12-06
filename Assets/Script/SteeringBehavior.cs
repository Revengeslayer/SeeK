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
        data.vec_Current = vec_forward;
        Vector3 vec_right = data.chaser.transform.right;
     
        Vector3 vec_seek = vec_target - vec_forward;

        data.seek_Force= Vector3.Dot(vec_seek, vec_forward);
        vec_seek.Normalize();
        float force_seek_dic = Vector3.Dot(vec_seek, vec_right);
        if (force_seek_dic > 0.0f)
        {
            force_seek_dic = 1.0f;
        }
        else
        {
            force_seek_dic = -1.0f;
        }
        float force_seek_target = Vector3.Dot(vec_seek, vec_forward);
        if (force_seek_target>0.98f)
        {
            force_seek_target = 1.0f;
            data.vec_Current = vec_target;
        }
        else
        {
            if(force_seek_target<-1.0f)
            {
                force_seek_target = -1.0f;
            }
            if(twopoint_dis<3.0f)
            {
                //if (data.m_Speed > 0.1f)
                //{
                //    data.m_fMoveForce = -(1.0f - fDist / 3.0f) * 5.0f;
                //}
                //else
                //{
                //    data.m_fMoveForce = fDotF * 100.0f;
                //}
            }
            else
            {
                //data.m_fMoveForce = 100.0f;
            }
        }
        //data.m_bMove = true;


        //Debug.Log("force_seek_target " + force_seek_target);
        //Debug.Log("force_seek_dic " + force_seek_dic);

    }
}
