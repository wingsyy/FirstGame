using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 弹药量
/// </summary>
public class Ammo : MonoBehaviour
{
    public GameObject TextAmmo;//定义子弹UI文本

    Text TextAmmoCount;//文本计算量

    private int maxAmmo = 100;//定义最大弹药数量
    private int minAmmo = 0;//定义最小弹药数量
    private int currentAmmo;//定义目前的弹药
    /// <summary>
    /// 封装数据
    /// </summary>
    public int MyMaxAmmo { get { return maxAmmo; } }
    public int MyCurrentAmmo { get { return currentAmmo; } }
    public int MyMinAmmo { get { return minAmmo; } }

    public void Start()
    {
        currentAmmo = 100;//为初始弹药数量赋值
        TextAmmoCount = TextAmmo.GetComponent<Text>();//获取子弹文本
    }

    public void Update()
    {
        TextAmmoCount.text = MyCurrentAmmo.ToString()+"/"+MyMaxAmmo.ToString(); //文本改变
        if (Input.GetKeyDown(KeyCode.J))
        {
            AmmoCount();//子弹减少
        }
    }
    

    //获取弹药
    public void ChangeAmmo(int amount)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + amount, minAmmo, maxAmmo);//限制弹药数量在最大与最小之间
    }

    //开枪子弹减少
    public void AmmoCount()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
        }
    }
}
