using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        ObjectPoolManager.Instance.objectPool.Get("Arrow");
        ObjectPoolManager.Instance.objectPool.Get("Monster");
    }

    void Update()
    {
        
    }
}
