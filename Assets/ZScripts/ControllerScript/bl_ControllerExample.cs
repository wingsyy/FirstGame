using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class bl_ControllerExample : MonoBehaviour
{
    /// <summary>
    /// 人物移动以及人物属性
    /// </summary>
	[SerializeField] private bl_Joystick Joystick;//Joystick reference for assign in inspector

    [SerializeField] private float Speed = 5;//定义移动速度

    Rigidbody2D player;//定义刚体

    Animator animator;//定义动作

    EnemyBulletScript eb;//定义敌人子弹

    public Slider slider;//获取人物血条长度

    public GameObject Fill;//删除血点

    HP hp;//定义hp

    private float timer;//定义死亡计时器

    private bool IsHurt = false;//判断受伤的初始状态
    private bool IsDied = false;//判断死亡的初始状态
    /// <summary>
    /// 封装数据
    /// 
    /// </summary>
    public bool IsHurting { get { return IsHurt; } }
    public bool IsDying { get { return IsDied; } }

    //游戏开始
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();//获取Rigidbody2D组件
        animator = GetComponent<Animator>();//获取Animator组件
        hp = GetComponent<HP>();//获取HP脚本组件
    }

    /// <summary>
    /// 封装移动数据
    /// </summary>
    public float Horizontal { get { return Joystick.Horizontal; } }//封装horizontal数据
    public float Vertical { get { return Joystick.Vertical; } }//封装vertical数据
    //private float X;
    //private float Y;
    //public float ComHorizontal { get { return X; } }//封装horizontal数据
    //public float ComVertical { get { return Y; } }//封装vertical数据

    private void Update()
    {
        AnimatorController();//控制动作  
        DieController();//控制死亡
        BloodController();//控制血条
        if (Horizontal != 0)
        {
            TurnAround(Horizontal);//如果人物移动调用旋转

        }
        //CompurterController();
        //if (Horizontal != 0 || X != 0)
        //{
        //    TurnAround(Horizontal);//如果人物移动调用旋转
        //    TurnAround(X);//如果人物移动调用旋转
        //}
        //CompurterController();
    }

    private void FixedUpdate()
    {
        MoveController();//移动以及防止抖动
        if (IsHurt == true)
            IsHurt = false;
    }

    //旋转方法
    private void TurnAround(float h)
    {
        //通过欧拉角到四元数旋转
        if (h > 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);//右转
        }
        if (h < 0)
        {
            this.transform.rotation = Quaternion.Euler(0, -180, 0);//左转
        }
    }

    //血条控制器
    private void BloodController()
    {
        slider.value = hp.MyCurrentHP / hp.MyMaxHP;
        if (hp.MyCurrentHP == 0)
            Destroy(Fill.gameObject);
    }

    //死亡控制器
    private void DieController()
    {
        if (hp.MyCurrentHP != 0)//血条不为0
        {
            timer = Time.time + 1;//计时死亡
        }
        else
        {
            IsDied = true;//改变死亡判定
            animator.SetBool("Die", IsDied);//设置死亡触发参数
            if (Time.time >= timer)
            {
                SceneManager.LoadScene(0);//重载游戏
            }
        }
    }

    //动作控制器
    private void AnimatorController()
    {
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));//更改动作面板中Speed值以实现动作切换   
        //animator.SetFloat("Speed", Mathf.Abs(X));//更改动作面板中Speed值以实现动作切换    
        animator.SetBool("Hurt", IsHurt); //改变动作参数

    }

    //移动控制
    private void MoveController()
    {
        Vector2 position = player.position;//获取玩家的位置
        position.x += Horizontal * Speed * Time.deltaTime;//x轴位置移动
        position.y += Vertical * Speed * Time.deltaTime;//y轴位置移动
        //position.x += 5 * X * Speed * Time.deltaTime;//x轴位置移动
        //position.y += 5 * Y * Speed * Time.deltaTime;//y轴位置移动
        player.MovePosition(position);//根据刚体进行移动不会产生碰撞反弹效果
    }

    //触发器判定受伤
    private void OnTriggerEnter2D(Collider2D other)//触发
    {
        eb = other.GetComponent<EnemyBulletScript>();//获取敌人子弹组件
        if (eb != null)//如果是敌人子弹
        {
            IsHurt = true;//受伤
        }
    }
    //private void CompurterController()
    //{
    //   X=Input.GetAxis("Horizontal");
    //   Y= Input.GetAxis("Vertical");
    //}
}