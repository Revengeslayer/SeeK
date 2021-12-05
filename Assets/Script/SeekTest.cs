using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTest : MonoBehaviour
{
    public GameObject m_Target;
    public AIData m_Data;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�}��SEEKTEST");
    }

    // Update is called once per frame
    void Update()
    {
        m_Data.vTarget = m_Target.transform.position;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(this.transform.position, this.transform.forward * 10.0f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, m_Data.vTarget);

    }
}
