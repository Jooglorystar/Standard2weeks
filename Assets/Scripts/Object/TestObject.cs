using UnityEngine;

public class TestObject : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private float deactiveTime;

    public string Name { get { return name; } }

    void Start()
    {
        if (this.gameObject.activeSelf)
        {
            Invoke("Deactive", 3f);
        }
    }

    private void Deactive()
    {
        ObjectPoolManager.Instance.objectPool.Release(this.gameObject);
    }
}