using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject prefab;
        public int poolSize = 300;
        public List<GameObject> ObjsInPool = new List<GameObject>();
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
                pool.ObjsInPool.Add(obj);
                obj.SetActive(false);
            }
        }
    }

    public GameObject Get(string name)
    {
        if(!poolDict.ContainsKey(name))
        {
            return null;
        }

        GameObject obj = null;

        for(int i = 0; i< poolDict[name].poolSize; i++)
        {
            if (!poolDict[name].ObjsInPool[i].activeSelf)
            {
                poolDict[name].ObjsInPool[i].SetActive(true);
                obj = poolDict[name].ObjsInPool[i];
                Debug.Log($"Get {name}");
                break;
            }
            else
            {
                Debug.Log($"생성할 수 있는 {name} 없음");
            }
        }
        return obj;
        
    }

    public void Release(GameObject obj)
    {
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
    }
}
