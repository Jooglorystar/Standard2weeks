using UnityEngine;

public class TestObject : MonoBehaviour
{
    [SerializeField] private string thisName;
    [SerializeField] private float deactiveTime;

    public string Name { get { return thisName; } }

    void Start()
    {
        if (this.gameObject.activeSelf)
        {
            Invoke("Deactive", deactiveTime);
        }
    }

    private void Deactive()
    {
        ObjectPoolManager.Instance.objectPool.Release(gameObject);
    }
}