using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject m_Target;
    public AIData Data;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("¶}±ÒSEEKTEST");
    }

    // Update is called once per frame
    void Update()
    {
        Data.target_Pos = m_Target.transform.position;
        SteeringBehavior.Seek(Data);
        SteeringBehavior.Move(Data);
    }
    private void OnDrawGizmos()
    {
        Debug.Log(Data.accSpeed);
        if (Data != null)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawLine(this.transform.position, Data.target_Pos);
            if (Data.accSpeed > 0.0f)
            {
                Gizmos.color = Color.blue;
            }
            else
            {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * Data.accSpeed * 5.0f);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * 3.0f);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.right * 3.0f);

            
        }
    }
}
