using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiOptimize : MonoBehaviour
{
    public GameObject Player;
    EnemyAI ai;
    LostAi la;
    private void Start()
    {
        la = GetComponent<LostAi>();
        ai = GetComponent<EnemyAI>();
    }
    public void Update()
    {
        if((this.transform.position-Player.transform.position).magnitude>30)
        {
            this.enabled = false;
            la.enabled = false;
            ai.enabled = false;
        }
        else
        {
            this.enabled = true;
            la.enabled = true;
            ai.enabled = true;
        }
    }

}
