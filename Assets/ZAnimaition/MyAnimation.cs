using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 动画行为类。提供有关动画的行为。
/// </summary>
public class MyAnimation//定义MyAnimation类
{
    /// <summary>
    /// 附加在模型上的动画组件引用
    /// </summary>
    private Animation anim;
    /// <summary>
    /// 创建动画行为类
    /// </summary>
    /// <param name="anim"></param>
    public MyAnimation(Animation anim)//构造函数（对应new初始化）为action赋初始值
    {
        this.anim = anim; //将anim赋值给此物体的anim
    }
    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="animName"></param>
    public void Play(string animName)
    {
        anim.CrossFade(animName);//根据动作名播放动画（淡入）
    }
    public bool IsPlaying(string animName)
    {
        return anim.IsPlaying(animName);//判断动画是否正在播放
    }
}
