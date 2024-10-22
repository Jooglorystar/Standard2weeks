using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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

    void Start()
    {
        /*
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            pools.Add(obj);
            obj.SetActive(false);
        }
        */
        foreach (var pool in pools)
        {
            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                pool.ObjsInPool.Add(obj);
                obj.SetActive(false);
                Debug.Log($"{pool.name} »ý¼º {i}");
            }
        }
    }

    public GameObject Get(string name)
    {
        /*
        GameObject obj = null;
        for (int i = 0; i < poolSize; i++)
        {
            if(!pool[i])
            {
                pool[i].SetActive(true);
                obj = pool[i];
                break;
            }
        }
        */
        
        if(!poolDict.ContainsKey(name))
        {
            return null;
        }
        GameObject obj = null;
        for(int i = 0; i< poolDict[name].poolSize; i++)
        {
            if (!poolDict[name].ObjsInPool[i])
            {
                poolDict[name].ObjsInPool[i].SetActive(true);
                obj = poolDict[name].ObjsInPool[i];
                break;
            }
        }
        return obj;
        
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }
}
