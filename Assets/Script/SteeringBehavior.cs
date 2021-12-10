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

        Vector3 current_Pos = data.chaser.transform.position;
        Vector3 target_Pos = data.target_Pos;

        Vector3 vec_Target = target_Pos - current_Pos;
        var twopoint_Dis=vec_Target.magnitude;
        if (twopoint_Dis < data.objectSpeed + 0.5f)
        {
            Vector3 vFinal = data.target_Pos;
            data.chaser.transform.position = vFinal;
            data.accSpeed = 0.0f;
            data.turnFreq = 0.0f;
            data.objectSpeed = 0.0f;
            data.isMove = false;
            return false;
        }

        Vector3 vec_Forward = data.chaser.transform.forward;
        data.vec_Current = vec_Forward;
        Vector3 vec_Right = data.chaser.transform.right;      
        Vector3 vec_Seek = vec_Target - vec_Forward;
        vec_Seek.Normalize();  
        
        float force_Seek_Target = Vector3.Dot(vec_Seek, vec_Forward);
        if (force_Seek_Target>0.98f)
        {
            force_Seek_Target = 1.0f;
            data.vec_Current = vec_Target;
            data.turnFreq = 0.0f;
        }
        else
        {

            if(force_Seek_Target<-1.0f)
            {
                force_Seek_Target = -1.0f;
            }
            float force_Seek_Dic = Vector3.Dot(vec_Seek, data.chaser.transform.right);
            if (force_Seek_Dic > 0.0f)
            {
                force_Seek_Dic = 1.0f;
            }
            else
            {
                force_Seek_Dic = -1.0f;
            }
            data.turnFreq = force_Seek_Dic;
        }
        if(twopoint_Dis <2.0f)
        {
            if(data.objectSpeed>0.2f)
            {
                data.accSpeed = -(1.0f - twopoint_Dis / 2.0f) * 5.0f;
            }
            else
            {
                data.accSpeed = force_Seek_Target;
            }
        }
        else
        {
            data.accSpeed = force_Seek_Target;
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
            Transform myObject = data.chaser.transform;
            Vector3 cur_Pos = data.chaser.transform.position;
            Vector3 vec_Right = data.chaser.transform.right;
            Vector3 vec_Forward = data.vec_Current;

            if (data.turnFreq > data.max_TurnFreq)
            {
                data.turnFreq = data.max_TurnFreq;
            }
            else if (data.turnFreq < -data.max_TurnFreq)
            {
                data.turnFreq = -data.max_TurnFreq;
            }

            vec_Forward = vec_Forward + vec_Right * data.turnFreq;
            vec_Forward.Normalize();
            myObject.forward = vec_Forward;


            data.objectSpeed = data.objectSpeed + data.accSpeed * Time.deltaTime;
            if (data.objectSpeed < 0.01f)
            {
                data.objectSpeed = 0.0f;
            }
            else if (data.objectSpeed > data.max_ObjectSpeed)
            {
                data.objectSpeed = data.max_ObjectSpeed;
            }

            cur_Pos = cur_Pos + myObject.forward * data.objectSpeed;
            myObject.position = cur_Pos;
        }
    }

}
