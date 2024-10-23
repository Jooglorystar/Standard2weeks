using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public QuestManager questManager;
    // Start is called before the first frame update
    void Start()
    {
        questManager = QuestManager.Instance;
    }
}
