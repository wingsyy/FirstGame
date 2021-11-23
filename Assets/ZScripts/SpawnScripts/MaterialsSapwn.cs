using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 随机生成物体
/// </summary>
public class MaterialsSapwn : MonoBehaviour
{
    public GameObject []Prefabs;//定义物体种类

    private float maxGenerateTime=10;//最长生成时间

    private int maxCount=10;//最大数量

    private int spawnedCount;//生成的数量

    private float timer;//计时器

    public Vector2 minPos, maxPos;//边界

    private void Update()
    {
        //设置间距5秒来生成
        if(Time.time>=timer)
        {
            timer = Time.time + 5;
            Generate();
        }
    }

    //生成敌人
    public void Generate()
    {
        spawnedCount+=1;//计数器加1
        if (spawnedCount >= maxCount)
            return;//假如物品已经达到上限，返回空
        else
            Invoke("Create", Random.Range(0, maxGenerateTime-5));//随机在5+0，maxGenerateTime间生成
    }

    //随机生成敌人
    public void Create()
    {
        int randomIndex = Random.Range(0, Prefabs.Length);//生成随机数
        //随机生成物体
        GameObject random_Material = Instantiate(Prefabs[randomIndex], new Vector2(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y)), Quaternion.identity);

    }
}
