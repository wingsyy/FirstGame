using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    MaxBoss co;
    BOSSHP HP;
    public Transform Player;
    public GameObject FLAG;
    public GameObject Spwan;
    Vector3 Current;
    private bool IsDied=false;
    private bool IsTrigger = false;
    private void Start()
    {
        Current = this.transform.position;
        HP = GetComponent<BOSSHP>();
        co = Spwan.GetComponent<MaxBoss>();
    }
    private void Update()
    {
        if((this.transform.position-Player.position).magnitude<=10&&HP.CurrentHP>0)
        this.transform.position = Vector3.MoveTowards(this.transform.position, Player.position, Time.deltaTime);
        else if ((this.transform.position - Player.position).magnitude > 10 && (this.transform.position - Current).magnitude != 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, Current, 1.5f*Time.deltaTime);
        }
        if (HP.CurrentHP <= 0 && IsTrigger ==false)
        {
            IsDied = true;
            IsTrigger = true;
        }
        if (IsDied==true)
        {
            Generate();
            IsDied = false;
        }
    }
    private void Generate()
    {
        Instantiate(FLAG, this.transform.position, Quaternion.identity);
        co.ChangeCount();
    }
}
