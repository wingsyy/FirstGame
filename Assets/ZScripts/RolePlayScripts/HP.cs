using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 玩家血量
/// </summary>
public class HP : MonoBehaviour
{
    private float maxHP = 10;//定义最大生命值

    private float minHP = 0;//定义最小生命值

    private float currentHP=10;//定义目前的生命值

    bl_ControllerExample bl;//定义控制器

    EnemyBulletScript eb;//定义敌人子弹

    public GameObject TextHP;//获取生命比值文本

    Text TextHPCount;//直接获取文本

    /// <summary>
    /// 封装数据
    /// </summary>
    public float MyMaxHP { get { return maxHP; } }
    public float MyCurrentHP { get { return currentHP; } }
    public float MyMinHP { get { return minHP; } }

    private void Start()
    {
        currentHP = 10;//为初始生命值赋值
        bl = GetComponent<bl_ControllerExample>();//获取控制器组件
        TextHPCount = TextHP.GetComponent<Text>();//获取文本
    }

    private void Update()
    {
        TextHPCount.text = MyCurrentHP.ToString() + "/" + MyMaxHP.ToString();//即时更改文本
    }

    //改变生命值
    public void ChangeHP(float amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, minHP, maxHP);//限制生命值在最大与最小之间
    }

    //减少生命值
    public void ReduceHP(float amount)
    {
        currentHP = Mathf.Clamp(currentHP - amount, minHP, maxHP);//限制生命值在最大与最小之间
    }

    //触发子弹
    private void OnTriggerEnter2D(Collider2D other)
    {
        eb = other.GetComponent<EnemyBulletScript>();//获取敌人子弹组件
        if (eb != null)//如果是敌人子弹
        {
            ReduceHP(1);     //受伤
        }
    }
}
