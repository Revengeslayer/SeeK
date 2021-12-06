using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTest : MonoBehaviour
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
        Data.vTarget = m_Target.transform.position;
        SteeringBehavior.Seek(Data);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(this.transform.position, this.transform.forward * 10.0f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, this.transform.right * 10.0f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, Data.vTarget);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Data.vTarget, this.transform.forward * 10.0f);

    }
}
