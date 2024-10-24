using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("GetArrow", 0f,2f);
        InvokeRepeating("GetMonster", 0f,3f);
    }

    void Update()
    {
    }

    void GetArrow()
    {
        ObjectPoolManager.Instance.objectPool.Get("Arrow");
    }

    void GetMonster()
    {
        ObjectPoolManager.Instance.objectPool.Get("Monster");
    }
}
