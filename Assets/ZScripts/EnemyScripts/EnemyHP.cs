using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 敌人血条
/// </summary>
public class EnemyHP : MonoBehaviour
{
    public GameObject Slider;//定义血条

    Slider Sli;//血条

    public GameObject Fill;//血条点

    public GameObject Explosion;//特效

    BulletScript bullet;//子弹

    new BoxCollider2D collider;//定义碰撞体

    private float maxHP = 7;//定义最大生命值
    private float minHP = 0;//定义最小生命值
    private float currentHP;//定义目前的生命值
    /// <summary>
    /// 封装数据
    /// </summary>
    public float MaxHP { get { return maxHP; } }
    public float CurrentHP { get { return currentHP; } }
    public float MinHP { get { return minHP; } }


    private void Awake()
    {
        Sli = Slider.GetComponent<Slider>();//获取血条组件
        collider = GetComponent<BoxCollider2D>();
        currentHP = 7;//为初始生命值赋值
    }
    public void Update()
    {
        BloodController();//即时间控制血条
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        bullet = other.GetComponent<BulletScript>();//获取受到伤害的子弹组件
        if(bullet!=null)
        {
            if (currentHP > 0)
            {
                Instantiate(Explosion, other.transform.position, Quaternion.identity);//生成爆炸特效
                Reduce(1);//减少的血量
            }
            if (currentHP == 1)
            {
                collider.enabled = !collider.enabled;//消除碰撞体，子弹不再可以触碰敌人
            }
        }
    }

    //减少敌人血量
    public void Reduce(int amount)
    {
        currentHP = Mathf.Clamp(currentHP - amount, minHP, maxHP);//限制生命值在最大与最小之间
    }

    //控制敌人血条
    public void BloodController()
    {
        Sli.value = currentHP / maxHP;//血条
        if (currentHP == 0)//如果血条为零
        {
            Destroy(Fill.gameObject);
            Quaternion dir = Quaternion.Euler(new Vector3(0, 180, 90));
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, dir, 20 * Time.deltaTime);//模拟死亡
            Destroy(this.gameObject, 5);
        }
    }
}
