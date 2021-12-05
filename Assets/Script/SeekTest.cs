using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("¶}±ÒSEEKTEST");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(this.transform.position, this.transform.forward * 10.0f);
    }
}
