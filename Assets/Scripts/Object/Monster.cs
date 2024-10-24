using UnityEngine;

public class Monster : MonoBehaviour
{
    void Start()
    {
        if (this.gameObject.activeSelf)
        {
            Invoke("Deactive", 5f);
        }
    }

    private void Deactive()
    {
        ObjectPoolManager.Instance.objectPool.Release(this.gameObject);
    }
}