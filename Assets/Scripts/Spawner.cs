using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;

    void Start()
    {
        pool.Get("Monster");
        pool.Get("Arrow");
    }

    void Update()
    {
        
    }
}
