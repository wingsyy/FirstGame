using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 拾取弹药
/// </summary>
public class AmmoPlus : MonoBehaviour
{
    bl_ControllerExample bc;//获取玩家控制脚本

    Ammo am;//取得子弹

    private int amount = 5;//初始化获得子弹数量

    //触发器（碰到即得到子弹）
    private void OnTriggerEnter2D(Collider2D other)
    {
        //给bc获取一个控制脚本组件
        bc = other.GetComponent<bl_ControllerExample>();
        //给am一个子弹数量脚本
        am = other.GetComponent<Ammo>();
        //如果获取成功则player!=null,玩家碰到弹药。
        if (bc != null)
        {
            //如果弹药量小于最大弹药量
            if (am.MyCurrentAmmo < am.MyMaxAmmo)
            {
                //Ammo+?
                am.ChangeAmmo(amount);
            }
            Destroy(this.gameObject);//销毁物体
        }
    }
    }
