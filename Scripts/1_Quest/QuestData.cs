using System;

[Serializable]
public class QuestData
{
    public int key;
    public string name;
    public QuestType type;
    public int conditionCount;
    public List<int> nextKeys;
}

[Serializable]
public class QuestState
{
    public int questKey;
    public QuestStatus status = QuestStatus.Inactive;
    public int currentCount = 0;
}

[Serializable]
public class QuestDataLoader : ILoader<int, QuestData>
{
    public List<QuestData> Items = new List<QuestData>();

    public Dictionary<int, QuestData> MakeDict()
    {
        Dictionary<int, QuestData> dict = new Dictionary<int, QuestData>();
        foreach (QuestData questData in Items)
            dict.Add(questData.key, questData);
        return dict;
    }
}


   

