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
    public static bool Seek(AIData data)
    {

        Vector3 current_pos = data.chaser.transform.position;
        Vector3 target_pos = data.target_Pos;

        Vector3 vec_target = target_pos - current_pos;
        var twopoint_dis=vec_target.magnitude;
        if (twopoint_dis < data.objectSpeed + 0.001f)
        {
            Vector3 vFinal = data.target_Pos;
            vFinal.y = current_pos.y;
            data.chaser.transform.position = vFinal;
            data.accSpeed = 0.0f;
            data.turnFreq = 0.0f;
            data.objectSpeed = 0.0f;
            data.isMove = false;
            return false;
        }

        Vector3 vec_forward = data.chaser.transform.forward;
        data.vec_Current = vec_forward;
        Vector3 vec_right = data.chaser.transform.right;      
        Vector3 vec_seek = vec_target - vec_forward;
        data.brforce_seek= Vector3.Dot(vec_seek, vec_forward)/100;
        vec_seek.Normalize();  
        float force_seek_dic = Vector3.Dot(vec_seek, data.chaser.transform.right);
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
            data.turnFreq = 0.0f;
        }
        else
        {
            if(force_seek_target<-1.0f)
            {
                force_seek_target = -1.0f;
            }
            data.turnFreq = force_seek_dic/100;
        }
        if(twopoint_dis <2.0f)
        {
            if(data.objectSpeed>0.2f)
            {
                data.accSpeed = -(1.0f - twopoint_dis / 2.0f) * 5.0f;
            }
            else
            {
                data.accSpeed = twopoint_dis;
            }
        }
        else
        {
            data.accSpeed = 0.1f;
        }

        data.isMove = true;
        return true;

    }

    public static void Move(AIData data)
    {
        if (!data.isMove)
        {
            return;
        }
        else
        {
            Transform t = data.chaser.transform;
            Vector3 cur_pos = data.chaser.transform.position;
            Vector3 vec_right = data.chaser.transform.right;
            Vector3 vec_ori_forward = data.chaser.transform.forward;
            Vector3 vec_forward = data.vec_Current;

            if (data.turnFreq > 10.0f)
            {
                data.turnFreq = 10.0f;
            }
            else if (data.turnFreq < -10.0f)
            {
                data.turnFreq = -10.0f;
            }

            vec_forward = vec_forward + vec_right * data.turnFreq;
            vec_forward.Normalize();
            t.forward = vec_forward;


            data.objectSpeed = data.objectSpeed + data.accSpeed * Time.deltaTime;
            if (data.objectSpeed < 0.01f)
            {
                data.objectSpeed = 0.0f;
            }
            else if (data.objectSpeed > 9.0f)
            {
                data.objectSpeed = data.accSpeed;
            }

            cur_pos = cur_pos + t.forward * data.objectSpeed;
            t.position = cur_pos;
        }
    }

}
