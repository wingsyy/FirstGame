using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 开关地图
/// </summary>
public class Map : MonoBehaviour
{
    private new Camera camera;//创建一个具有camera属性的camera

    public GameObject mapCamera;//获取camera

    bool IsMap=false;//判断地图是否打开

    public void Start()
    {
        camera = mapCamera.GetComponent<Camera>();
    }

    public void Click()
    {
        if(IsMap==false)
        {
            camera.depth = 1;//切换地图
            IsMap = true;
        }
        else if(IsMap==true)
        {
            camera.depth = -1;
            IsMap = false;
        }
    }
}
