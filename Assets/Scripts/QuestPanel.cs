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
            string questText = "";
            switch (QuestManager.Instance.QuestList[i].questType)
            {
                case QuestType.Noncategorized:
                    questText = $"Quset {i + 1} - {QuestManager.Instance.QuestList[i].QuestName} (최소레벨 {QuestManager.Instance.QuestList[i].QuestRequiredLevel})\n";
                    break;

                case QuestType.Monster:
                    questText = $"Quset {i + 1} - {QuestManager.Instance.QuestList[i].QuestName} (최소레벨 {QuestManager.Instance.QuestList[i].QuestRequiredLevel})\n를 마리 소탕";
                    break;

                case QuestType.Encounter:
                    questText = $"Quset {i + 1} - {QuestManager.Instance.QuestList[i].QuestName} (최소레벨 {QuestManager.Instance.QuestList[i].QuestRequiredLevel})\n와 대화하기";
                    break;
            }
            questTexts += questText;
        }
        return questTexts;
    }
}
