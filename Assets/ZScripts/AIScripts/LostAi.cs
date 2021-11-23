using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostAi : MonoBehaviour
{
    EnemyAI ai;
    Vector3 Current;
    private void Start()
    {
        ai = GetComponent<EnemyAI>();
        Current = this.transform.position;
    }
    private void Update()
    {
        if((this.transform.position-Current).magnitude>=10)
        {
            ai.enabled = false;
        }       
        else if((this.transform.position-Current).magnitude<=1)
        {
            ai.enabled = true;
        }
        if (ai.enabled == false)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, Current, 2.5f * Time.deltaTime);
        }
    }
}
