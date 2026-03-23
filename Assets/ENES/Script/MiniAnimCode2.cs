using DG.Tweening;
using UnityEngine;

public class MiniAnimCode2 : MonoBehaviour
{
    Tween loopTween;
    Vector3 originalScale;

    void Start()
    {
       
         
    }

    private void OnDisable()
    {
        StopAnim();
    }
    private void OnEnable()
    {
        originalScale = transform.localScale;
        StartAnim();
    }
    public void StartAnim()
    {
        loopTween = transform.DOScale(originalScale * 1.1f, 0.6f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(true); // timeScale baðýmsýz
    }

    public void StopAnim()
    {
        if (loopTween != null)
        {
            loopTween.Kill();
            loopTween = null;
        }
        transform.localScale = originalScale;
    }
}