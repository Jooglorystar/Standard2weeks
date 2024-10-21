using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;

    public static QuestManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            if (instance == null)
            {
                Debug.Log("Quest Manager01");
                instance = FindObjectOfType<QuestManager>();
                if (instance == null)
                {
                    Debug.Log("Quest Manager02");
                    instance = new QuestManager();
                    instance.AddComponent<QuestManager>();
                }
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            QuestManager.Instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
}
