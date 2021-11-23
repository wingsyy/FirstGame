using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 占旗子
/// </summary>
public class Flag : MonoBehaviour
{
    Animator Anim;

    public GameObject EnemyBullet;//获取敌人子弹物体

    EnemyBulletScript eb;//定义敌人子弹脚本

    public GameObject Player;//获取玩家物体

    public Slider slider;//获取旗帜变量

    bl_ControllerExample bl;//控制人物脚本

    private bool isFlag = false;//设置开旗开关

    private bool StillOnTrigger = false;//设置触碰开关

    HP hp;

    Ammo am;

    public void Start()
    {
        eb = EnemyBullet.GetComponent<EnemyBulletScript>();//获取脚本
        bl = Player.GetComponent<bl_ControllerExample>();//获取脚本
        hp = Player.GetComponent<HP>();
        am = Player.GetComponent<Ammo>();
        Anim = GetComponent<Animator>();
    }
    public void Update()
    {
        IfOcuppyFlag();
    }

    //开旗成功
    public void OccupyFlag()
    {
        Anim.enabled = true;//开关成功标志
    }

    //开旗判定
    public void IfOcuppyFlag()
    {

        //受伤打断开旗
        if (bl.IsHurting == true && isFlag == false)
        {
            slider.value = 0;//进度条归零
            StillOnTrigger = false;
        }

        //根据距离判断是否开旗成功
        if ((Player.transform.position - this.transform.position).magnitude <= 0.8f && isFlag == false)
        {
            slider.value += Time.deltaTime / 5;//以五秒间隙填充进度条
            if (slider.value == 1)
                StillOnTrigger = true;
        }
        if ((Player.transform.position - this.transform.position).magnitude > 0.8f && isFlag == false)
        {
            slider.value = 0;//进度条归零
            StillOnTrigger = false;
        }

        //如果满足时间、旗子开关、碰撞开关
        if (isFlag == false && StillOnTrigger == true)
        {
            OccupyFlag();//占领旗子成功
            isFlag = true;//开旗成功
            am.ChangeAmmo(100);
            hp.ChangeHP(10);
        }
    }
}
