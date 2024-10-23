using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    private Text questText;

    private void Awake()
    {
        questText = GetComponentInChildren<Text>();
    }

    void Start()
    {
        questText.text = PrintQuest();
    }

    private string PrintQuest()
    {
        string questTexts = "";

        for(int i = 0; i< QuestManager.Instance.QuestList.Count; i++)
        {
            string questText = $"Quset {i+1} - {QuestManager.Instance.QuestList[i].QuestName} (최소레벨 {QuestManager.Instance.QuestList[i].QuestRequiredLevel})\n";
            questTexts += questText;
        }
        return questTexts;
    }
}
