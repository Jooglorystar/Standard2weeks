using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;

    public static QuestManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("Find QuestManager");
                instance = FindObjectOfType<QuestManager>();
                if (instance == null)
                {
                    Debug.Log("Create QuestManager");
                    instance = new GameObject("QuestManager").AddComponent<QuestManager>();
                }
            }
            return instance;
        }
    }

    public List<QuestDataSO> QuestList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
