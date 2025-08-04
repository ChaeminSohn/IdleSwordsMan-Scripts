using Assets.HeroEditor.Common.Scripts.Common;
using Data;
using Excellcube.EasyTutorial.Utils;
using UnityEngine;
using UnityEngine.Events;

public class ActionTutorialStep : TutorialStep
{
    private UIActionTutorialStep _ui;
    private UnityAction _completeTutorial;
    public  UnityAction CompleteTutorial
    {
        get => _completeTutorial;
        set => _completeTutorial = value;
    }
    public ActionTutorialStep(UIActionTutorialStep ui)
    {
        _ui = ui;
    }
    protected override void ConfigureView()
    {
        if(Data == null)
        {
            Debug.LogError("Fail to configure the view. Data type isn't matched with ActionTutorialPageData");
            return;
        }
        // Highlight target 탐색.
        //SearchDynamicHighlightTarget(ref Data);

        
        // ActionLog 텍스트가 없으면 박스 비활성화
        if (string.IsNullOrEmpty(Data.actionLog))
        {
            _ui.ActionImage.SetActive(false);
            _ui.ActionLogText.SetActive(false);
        }
        else
        {
            _ui.ActionImage.SetActive(true);
            _ui.ActionLogText.SetActive(true);
            _ui.ActionLogText.text = Data.actionLog;
        }
        
        // 튜토리얼 액션 버튼 할당
        if(Data.targetButtonType != Define.UIButtonType.None)
        {
            GameObject targetButton = Managers.Tutorial.GetTargetButton(Data.targetButtonType);
            if (targetButton == null) return;

            if (!targetButton.TryGetComponent<RectTransform>(out RectTransform target))
            {
                return;
            }
            // 터치 블로킹 전용 패널 활성화
            _ui.UnmaskPanel.transform.parent.gameObject.SetActive(true);
            _ui.UnmaskPanel.fitTarget = target;
            _ui.Indicator.Place(target, Data.indicatorPosition == 1);
            _ui.Indicator.Show(target);
        }
        else
        {
            _ui.UnmaskPanel.transform.parent.gameObject.SetActive(false);
            _ui.Indicator.gameObject.SetActive(false);
        }
        
        if(_completeTutorial == null)
        {
            Debug.LogError("[ActionTutorialPage] CompleteTutorial UnityAction isn't assigned!");
        }
        
        Managers.Tutorial.AddListener(Data.targetButtonType, _completeTutorial);
    }
}
