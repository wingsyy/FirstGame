using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    EnemyHP HP;
    public Transform Player;
    Vector3 Current;
    private SpriteRenderer sp;
    private void Start()
    {
        Current = this.transform.position;
        HP = GetComponent<EnemyHP>();
        sp = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        AI();
    }
    public void AI()
    {
        if ((this.transform.position - Player.position).magnitude <= 5 && HP.CurrentHP > 0)
            this.transform.position = Vector3.MoveTowards(this.transform.position, Player.position, Time.deltaTime);
        else if ((this.transform.position - Player.position).magnitude > 5 && (this.transform.position - Current).magnitude != 0 && HP.CurrentHP > 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, Current, 1.5f * Time.deltaTime);
        }
        if (transform.position.x > Player.position.x)
        {
            sp.flipX = false;
        }
        else
        {
            sp.flipX = true;
        }
    }

}
