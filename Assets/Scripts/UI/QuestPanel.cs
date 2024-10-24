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
                    questText = $"Quset {i + 1} - {QuestManager.Instance.QuestList[i].QuestName} (�ּҷ��� {QuestManager.Instance.QuestList[i].QuestRequiredLevel})\n";
                    break;

                case QuestType.Monster:
                    MonsterQuestDataSO monsterQuest = (MonsterQuestDataSO)(QuestManager.Instance.QuestList[i]);
                    questText = $"Quset {i + 1} - {monsterQuest.QuestName} (�ּҷ��� {monsterQuest.QuestRequiredLevel})\n{monsterQuest.TargetName}�� {monsterQuest.TargetGoalCount}���� ����\n";
                    break;

                case QuestType.Encounter:
                    EncounterQuestDataSO encounterQuest = (EncounterQuestDataSO)(QuestManager.Instance.QuestList[i]);
                    questText = $"Quset {i + 1} - {encounterQuest.QuestName} (�ּҷ��� {encounterQuest.QuestRequiredLevel})\n{encounterQuest.TargetName}�� ��ȭ�ϱ�\n";
                    break;
            }
            questTexts += questText;
        }
        return questTexts;
    }
}
