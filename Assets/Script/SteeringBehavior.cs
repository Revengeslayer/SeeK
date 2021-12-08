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
        vec_seek.Normalize();        
        float force_seek = Vector3.Dot(vec_seek, vec_forward);
        if (force_seek > 0.96f)
        {
            force_seek = 1.0f;
            data.vec_Current = vec_target;
            data.turnFreq = 0.0f;
        }
        else
        {
            if (force_seek < -1.0f)
            {
                force_seek = -1.0f;
            }

            float force_seek_dic = Vector3.Dot(vec_seek, data.chaser.transform.right);
            if (force_seek < 0.0f)
            {
                if (force_seek_dic < 0.0f)
                {
                    force_seek_dic = -1.0f;
                }
                else
                {
                    force_seek_dic = 1.0f;
                }
                if (twopoint_dis < 3.0f)
                {
                    force_seek_dic *= (force_seek_dic / 3.0f + 1.0f);
                }
                data.turnFreq = force_seek_dic;
            }
            data.turnFreq = force_seek_dic/2;
        }   

        if(twopoint_dis<3.0f)
        {
            if(data.objectSpeed>0.1f)
            {
                data.accSpeed = -(1.0f - twopoint_dis / 3.0f) * 5.0f;
            }
            else
            {
                data.accSpeed = force_seek ;
            }
        }
        else
        {
            data.accSpeed = force_seek ;
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

            if (data.turnFreq > 0.2f)
            {
                data.turnFreq = 0.2f;
            }
            else if (data.turnFreq < 0.2f)
            {
                data.turnFreq = 0.2f;
            }

            vec_forward = vec_forward + vec_right * data.turnFreq;
            vec_forward.Normalize();
            t.forward = vec_forward;


            data.objectSpeed = data.objectSpeed + data.accSpeed * Time.deltaTime*10;
            if (data.objectSpeed < 0.01f)
            {
                data.objectSpeed = 0.01f;
            }
            else if(data.objectSpeed>5.0f)
            {
                data.objectSpeed = 5.0f;
            }
            cur_pos = cur_pos + t.forward * data.objectSpeed;
            t.position = cur_pos;
        }
    }

}
