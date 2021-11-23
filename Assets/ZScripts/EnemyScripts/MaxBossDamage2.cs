using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxBossDamage2 : MonoBehaviour
{
    public GameObject Player;
    HP pc;
    MaxBossHP HP;
    private float timer = 0;
    private void Start()
    {
        pc = Player.GetComponent<HP>();
        HP = this.GetComponent<MaxBossHP>();
    }
    private void FixedUpdate()
    {

    }
    private void Update()
    {
        if ((this.transform.position - Player.transform.position).magnitude < 1 && timer <= Time.time && HP.CurrentHP > 0)
        {
            pc.ReduceHP(2);
            timer = Time.time + 1;
        }
    }
}
