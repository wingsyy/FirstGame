using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxBossAI : MonoBehaviour
{
    MaxBoss co;
    MaxBossHP HP;
    public Transform Player;
    public GameObject FLAG;
    private bool IsDied = false;
    private bool IsTrigger = false;
    private void Start()
    {
        HP = GetComponent<MaxBossHP>();
    }
    private void Update()
    {
        if (HP.CurrentHP > 0)
            this.transform.position = Vector3.MoveTowards(this.transform.position, Player.position, 2*Time.deltaTime);
        if (HP.CurrentHP <= 0 && IsTrigger == false)
        {
            IsDied = true;
            IsTrigger = true;
        }
        if (IsDied == true)
        {
            Generate();
            IsDied = false;
        }
    }
    private void Generate()
    {
        Instantiate(FLAG, this.transform.position, Quaternion.identity);
    }
}
