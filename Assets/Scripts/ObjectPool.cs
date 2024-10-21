using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Instantiate(pool[i], transform);
        }
    }

    public GameObject Get()
    {
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
        return obj;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
    }
}
