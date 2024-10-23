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
                    MonsterQuestDataSO SO = (MonsterQuestDataSO)(QuestManager.Instance.QuestList[i]);
                    questText = $"Quset {i + 1} - {QuestManager.Instance.QuestList[i].QuestName} (최소레벨 {QuestManager.Instance.QuestList[i].QuestRequiredLevel})\n{SO.TargetName}를 {SO.TargetGoalCount}마리 소탕\n";
                    break;

                case QuestType.Encounter:
                    QuestManager.Instance.QuestList[i] = (EncounterQuestDataSO)QuestManager.Instance.QuestList[i];
                    questText = $"Quset {i + 1} - {QuestManager.Instance.QuestList[i].QuestName} (최소레벨 {QuestManager.Instance.QuestList[i].QuestRequiredLevel})\n와 대화하기\n";
                    break;
            }
            questTexts += questText;
        }
        return questTexts;
    }
}
