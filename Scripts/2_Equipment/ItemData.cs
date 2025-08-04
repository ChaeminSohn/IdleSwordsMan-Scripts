using System;
using System.Collections.Generic;
using System.Diagnostics;

// 모든 아이템의 기본이 될 추상 클래스
// 아이템의 고정된 정보만 담음
[Serializable]
public abstract class ItemData
{
    public int dataId;              // 아이디
    public string name;             // 이름
    public string description;      // 설명
    public RarityType rarity;       //등급
}

// 아이템의 가변성 데이터만 담음
[Serializable]
public class ItemState
{
    public int dataId;                  // 아이디
    public int level = 1;               // 레벨
    public int experience = 0;          // 경험치
    public bool isUnlocked = false;     // 소유 여부
    public bool canUpgrade = false;     // 업그레이드 가능 여부
}

// ItemState 가 어떤 종류의 ItemData 를 참고하는지 알 수 있도록 제너릭으로 생성
[Serializable]
public class ItemState<TData> : ItemState where TData : ItemData
{
    public TData data;
}



#region GearData

[Serializable]
public class GearData : ItemData
{
    public GearType type;
}

[Serializable]
public class GearState : ItemState<GearData>
{
    public Sprite visualSprite { get; private set; }

    // Resources 폴더에서 장비 외형 스프라이트를 로드
    public void LoadVisual()
    {
        string path = $"Sprites/Gears/{data.dataId}";
        visualSprite = Resources.Load<Sprite>(path);

        if (visualSprite == null)
        {
            Debug.LogWarning($"GearState 찾을 수 없습니다");
        }
    }
}

[Serializable]
public class GearDataLoader : ILoader<int, GearData>
{
    public List<GearData> Items = new List<GearData>();

    public Dictionary<int, GearData> MakeDict()
    {
        Dictionary<int, GearData> dict = new Dictionary<int, GearData>();
        foreach (GearData gearData in Items)
            dict.Add(gearData.dataId, gearData);
        return dict;
    }
}

#endregion

#region SkillData

[Serializable]
public class SkillData : ItemData
{
    public SkillType type;
    public SkillExecuteType executeType;
    public float cooldown;
    public float range;
    public int targetCount;
    public float damageMultiplier;
    public int attackCount;
    public float attackInterval;
    public float recognitionRange;
    public float projSpeed;
    public float projRange;
    public float duration;
    public StatType stat;
    public float buffValue;
    public string effectName;
    public float effectDuration;
    public string animTrigger;
    public string clipName;
}

[Serializable]
public class SkillDataLoader : ILoader<int, SkillData>
{
    public List<SkillData> Items = new List<SkillData>();

    public Dictionary<int, SkillData> MakeDict()
    {
        Dictionary<int, SkillData> dict = new Dictionary<int, SkillData>();
        foreach (SkillData skillData in Items)
            dict.Add(skillData.dataId, skillData);
        return dict;
    }
}

#endregion

#region PartyData

[Serializable]
public class PartyData : ItemData
{
    public float attackSpeed;
    public PartyType type;
}


[Serializable]
public class PartyDataLoader : ILoader<int, PartyData>
{
    public List<PartyData> Items = new List<PartyData>();

    public Dictionary<int, PartyData> MakeDict()
    {
        Dictionary<int, PartyData> dict = new Dictionary<int, PartyData>();
        foreach (PartyData partyData in Items)
            dict.Add(partyData.dataId, partyData);
        return dict;
    }
}

#endregion