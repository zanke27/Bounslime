using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameEndUiManager : MonoBehaviour
{
    protected EventParam eventParam = new EventParam();
    
    [SerializeField] CanvasGroup stageClearImage = null;
    private void Start()
    {
        EventManager.StartListening("StageClear", DoStageClear);
    }

    private void DoStageClear(EventParam eventparam)
    {
        EventManager.TriggerEvent("StopState", eventparam);
        stageClearImage.DOFade(1, 0.5f);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("StageClear", DoStageClear);
    }
}
