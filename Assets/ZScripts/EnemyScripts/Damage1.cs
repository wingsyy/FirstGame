using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage1 : MonoBehaviour
{
    Animator anim;
    public GameObject Player;
    HP pc;
    EnemyHP HP;
    private float timer=0;
    private bool IsAttacking=false;
    private void Start()
    {
         pc= Player.GetComponent<HP>();
        HP = this.GetComponent<EnemyHP>();
        anim = this.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        anim.SetBool("IsAttack", IsAttacking);
    }
    private void Update()
    {
        if ((this.transform.position - Player.transform.position).magnitude < 0.8f && timer <= Time.time && HP.CurrentHP > 0)
        {
            pc.ReduceHP(1);
            timer = Time.time + 1;
        }
        if ((this.transform.position - Player.transform.position).magnitude < 0.8f && HP.CurrentHP > 0)
            IsAttacking = true;
        else if(IsAttacking==true)
        {
            IsAttacking = false;
        }
    }
}