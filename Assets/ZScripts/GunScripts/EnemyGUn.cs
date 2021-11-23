using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人攻击
/// </summary>
public class EnemyGUn : MonoBehaviour
{
    EnemyHP HPCount;//敌人血量

    public GameObject bulletObject;//定义子弹

    public GameObject Player;//获取玩家

    private float timer = 0;//定义计时器

    private void Start()
    {
        HPCount = GetComponent<EnemyHP>();
    }
    public void Update()
    {

        //如果敌人存活，发射子弹
        if (timer <= Time.time && HPCount.CurrentHP > 0&& (this.transform.position - Player.transform.position).magnitude < 30)
        {
            GenerateAmmo();//生成子弹
            timer = Time.time + 2;//间隔三秒
        }
    }
    public void GenerateAmmo()
    {
        //生成子弹
        GameObject bullet = Instantiate(bulletObject, this.transform.position, Quaternion.identity) as GameObject;
        EnemyBulletScript eb = bullet.GetComponent<EnemyBulletScript>();
        if (eb != null)
        {
            eb.Move((Player.transform.position - this.transform.position).normalized, 500);
        }
    }
}
