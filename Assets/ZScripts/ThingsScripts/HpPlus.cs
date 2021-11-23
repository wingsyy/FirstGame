using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 拾取物体恢复血量
/// </summary>
public class HpPlus : MonoBehaviour
{
    /// <summary>
    /// 碰撞检测相关
    /// </summary>
    /// <param name="other"></param>

    bl_ControllerExample bc;//获取任务控制脚本

    HP hp;//获取HP脚本

    private float amount=2;

    //如果碰到即回血
    private void OnTriggerEnter2D(Collider2D other)
    {
        //给bc获取一个控制脚本组件
        bc = other.GetComponent<bl_ControllerExample>();
        hp = other.GetComponent<HP>();
        //如果获取成功则player!=null,玩家碰到樱桃。
        if(bc!=null)
        {
            //如果血量小于最大生命值
            if(hp.MyCurrentHP<hp.MyMaxHP)
            {
                //Hp+？
                hp.ChangeHP(amount);
            }
            Destroy(this.gameObject);//销毁物体
        }
    }
}
