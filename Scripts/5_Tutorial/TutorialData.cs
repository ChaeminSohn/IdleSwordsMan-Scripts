using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// 튜토리얼의 각 단계를 정의하는 데이터
[Serializable]
public class TutorialStepData
{
    public int key;
    public TutorialStepType type;
    public float startDelay;
    
    // Dialogue 전용 데이터
    public string npcName;
    public string dialogueText;
    
    // 왼쪽, 혹은 오른쪽에 표시될 npc 스프라이트 ID
    // 둘다 비워둘 시 표시 X, 둘다 할당할 시 왼쪽만 표시됨
    public string leftSpriteName;
    public string rightSpriteName;
    
    // Action 전용 데이터
    // 클릭을 유도할 버튼의 고유 이름
    public UIButtonType targetButtonType;

    public string actionLog;
    // 강조 화살표 위치 (0 : 아래, 1 : 위)
    public int indicatorPosition;
}

// 튜토리얼의 모든 단계를 순서대로 담는 데이터
[Serializable]
public class TutorialData
{
    public int key;
    public List<int> steps;
}

[Serializable]
public class TutorialStepDataLoader : ILoader<int, TutorialStepData>
{
    public List<TutorialStepData> Items = new();
    public Dictionary<int, TutorialStepData> MakeDict()
    {
        Dictionary<int, TutorialStepData> dict = new();
        foreach (TutorialStepData data in Items)
            dict.Add(data.key, data);
        return dict;
    }
}

[Serializable]
public class TutorialDataLoader : ILoader<int, TutorialData>
{
    public List<TutorialData> Items = new();

    public Dictionary<int, TutorialData> MakeDict()
    {
        Dictionary<int, TutorialData> dict = new();
        foreach (var data in Items)
            dict.Add(data.key, data);
        return dict;
    }
}

   
