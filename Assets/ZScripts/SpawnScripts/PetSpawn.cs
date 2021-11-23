using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawn : MonoBehaviour
{
    public GameObject[] Prefabs;//定义物体种类
    private float timer=30;
    private void Update()
    {
        //设置间距5秒来生成
        if (Time.time >= timer)
        {
            timer = Time.time + 30;
            Create();
        }
    }

    public void Create()
    {
        int randomIndex = Random.Range(0, Prefabs.Length);//生成随机数
        //随机生成物体
        GameObject random_Material = Instantiate(Prefabs[randomIndex], this.transform.position, Quaternion.identity);
    }
}
