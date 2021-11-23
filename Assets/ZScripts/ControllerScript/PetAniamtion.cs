using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAniamtion : MonoBehaviour
{
    [SerializeField] private bl_Joystick Joystick;//Joystick reference for assign in inspector
    //private bl_ControllerExample bl;
    public float Horizontal { get { return Joystick.Horizontal; } }//封装horizontal数据
    public float Vertical { get { return Joystick.Vertical; } }//封装vertical数据
    Animator animator;//定义动作
    private void Awake()
    {
      //bl = GetComponentInParent<bl_ControllerExample>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));//更改动作面板中Speed值以实现动作切换    
       // animator.SetFloat("Speed", Mathf.Abs(bl.ComHorizontal));//更改动作面板中Speed值以实现动作切换    
    }
}
