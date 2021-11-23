using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 枪
/// </summary>
public class GunBasic : MonoBehaviour
{
    private bool IsFire;

    Animator anim;

    bl_ControllerExample cont;//获取人物脚本组件

    public GameObject player;//直接获取人物

    float xContorller;//定义x方向旋转

    float yContorller;//定义y方向旋转

    public GameObject Gun1;//获取枪

    public GameObject bulletObject;//定义子弹

    private float gunRotate, bulletRotate;//定义枪旋转与子弹旋转

    private Vector2 lookDirection = new Vector2(1, 0);//定义初始方向

    Ammo ammo;//定义弹药脚本类型的变量

    public void Awake()
    {
        cont = player.GetComponent<bl_ControllerExample>();//获取人物控制组件
        ammo = player.GetComponent<Ammo>();//获取人物子弹组件
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        Rotation();
        if (Input.GetKeyDown(KeyCode.J))
        {
            Click();
        }
    }
    private void FixedUpdate()
    {
        anim.SetBool("IsFiring", IsFire);
        if (IsFire == true)
            IsFire = false;
    }
    public void Click()
    {
        IsFire = true;
        if (ammo.MyCurrentAmmo > 0)
        //如果子弹足够按键时生成一个子弹
        {
            GameObject bullet = Instantiate(bulletObject, Gun1.transform.position, Quaternion.Euler(new Vector3(0, 0, bulletRotate))) as GameObject;
            BulletScript bc = bullet.GetComponent<BulletScript>();
            if (bc != null)//判断生成的子弹是否具有脚本
            {
                bc.Move(lookDirection, 3000);//子弹移动
            }
        }
    }

    //定义枪旋转
    public void GunRotate(float x, float y, float rotate)
    {
        Gun1.transform.eulerAngles = new Vector3(x, y, rotate);//定义枪的旋转
        
    }

    //旋转子弹以及枪
    public void Rotation()
    {
        Vector2 moveVector = new Vector2(cont.Horizontal, cont.Vertical);//即时赋值方向
        if (cont.Horizontal != 0 || cont.Vertical != 0)//方向调整
        {
            lookDirection = moveVector.normalized;//将方向归一化
            gunRotate = Vector2.Angle(lookDirection, Vector2.right);//确认枪的方向
            bulletRotate = gunRotate;//定义子弹旋转方向
            if (cont.Vertical > 0)//当目标轴朝上时，方向相反
                gunRotate = -gunRotate;
            bulletRotate = gunRotate;
            if (cont.Horizontal < 0)//当目标轴向左时，定义旋转角度
            {
                xContorller = 180;
                yContorller = -180;
                gunRotate = -gunRotate;
                bulletRotate = gunRotate;
            }
            else if (cont.Horizontal > 0)//当目标轴向右时，定义旋转角度
            {
                xContorller = 0;
                yContorller = -180;
                bulletRotate = -gunRotate;
            }
            GunRotate(xContorller, yContorller, gunRotate);//枪进行旋转
        }
    }
}
