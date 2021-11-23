﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人子弹
/// </summary>
public class EnemyBulletScript : MonoBehaviour
{

    Rigidbody2D body;//定义一个刚体变量

    //起初就获取组件
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();//在游戏开始前给物体一个刚体组件
        Destroy(this.gameObject, 3);//在两秒后销毁物体
    }

    public void Move(Vector2 MoveDirection, float moveForce)
    {
        body.AddForce(MoveDirection * moveForce); //子弹受力移动
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);//若碰撞销毁物体
    }


}
