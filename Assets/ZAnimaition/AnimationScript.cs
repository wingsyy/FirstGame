using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class AnimationScript : MonoBehaviour
{
    public string runAnimName;//定义跑步文件并以string形式保存在Inspector面板由其赋值定义

    public string idleAnimName;//定义闲置文件并以string形式保存在Inspector面板由其赋值定义

    public MyAnimation action;//定义一个具有Animation特定性的action变量
    private void Awake()
    {
        // action=new MyAnimation(?) ;
        action = new MyAnimation(GetComponent<Animation>());//（类需要对变量进行new初始化）
        //在此脚本物体下寻找孩子中含有Animation组件的物体，并将Animation组件内容赋值给action变量
    }
}
