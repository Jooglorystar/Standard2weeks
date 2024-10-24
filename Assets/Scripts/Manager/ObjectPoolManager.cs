using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager instance;

    public ObjectPool objectPool;

    public static ObjectPoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Find ObjectPoolManager");
                instance = FindObjectOfType<ObjectPoolManager>();
                if (instance == null)
                {
                    Debug.Log("Create ObjectPoolManager");
                    instance = new GameObject("ObjectPoolManager").AddComponent<ObjectPoolManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        objectPool = GetComponent<ObjectPool>();
    }
}
