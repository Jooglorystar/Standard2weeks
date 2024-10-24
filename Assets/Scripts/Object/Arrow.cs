using UnityEngine;

public class Arrow : MonoBehaviour
{
    void Start()
    {
        if(this.gameObject.activeSelf)
        {
            Invoke("Deactive", 3f);
        }
    }

    private void Deactive()
    {
        ObjectPoolManager.Instance.objectPool.Release(this.gameObject);
    }
}