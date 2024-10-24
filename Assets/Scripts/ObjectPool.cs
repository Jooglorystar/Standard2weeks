using System.Collections.Generic;
using UnityEngine;
using static ObjectPool;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject prefab;
        public int poolSize;
        public Queue<GameObject> ObjsInPool = new Queue<GameObject>();
    }

    public List<Pool> pools = new List<Pool>();

    private Dictionary<string, Pool> poolDict = new Dictionary<string, Pool>();

    void Awake()
    {
        foreach (var pool in pools)
        {
            poolDict.Add(pool.name, pool);

            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                pool.ObjsInPool.Enqueue(obj);
                obj.SetActive(false);
            }
        }
    }

    public GameObject Get(string name)
    {
        if (!poolDict.ContainsKey(name))
        {
            return null;
        }

        GameObject obj = null;

        if (!poolDict[name].ObjsInPool.Peek().activeSelf)
        {
            poolDict[name].ObjsInPool.Peek().SetActive(true);
            obj = poolDict[name].ObjsInPool.Dequeue();
            Debug.Log($"Get {name}");
        }
        else
        {
            Debug.Log($"������ �� �ִ� {name} ����");
        }
        return obj;

    }

    public void Release(GameObject obj)
    {
        TestObject to = obj.GetComponent<TestObject>();
        Pool pool = poolDict[to.Name];

        if (obj.activeSelf)
        {
            obj.SetActive(false);
            pool.ObjsInPool.Enqueue(obj);
            Debug.Log($"Release {obj.name}");
        }
    }
}
