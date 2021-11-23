using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxBoss : MonoBehaviour
{
    public Vector2 minPos, maxPos;//边界
    public GameObject TheMaxBoss;
    private int count=3;
    public void ChangeCount()
    {
        if (count > 0)
        {
            count--;
            print(count);
        }
    }
    public void Update()
    {
        if(count==0)
        {
            GameObject go=Instantiate(TheMaxBoss, new Vector2(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y)), Quaternion.identity);
            count--;
            if(TheMaxBoss.transform.position.magnitude>10000)
            {
                Destroy(TheMaxBoss.gameObject);
            }
        }
        if(count==-1)
        {
            Destroy(this.gameObject);
        }
    }
}
