using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonGrow  : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Vector3 baseScale;
    Tween pulse;


    void Start()
    {
        baseScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        

        transform.DOKill();

        transform.DOScale(baseScale * 1.08f, 0.15f).OnComplete(() =>
        {
            pulse = transform.DOScale(baseScale * 1.12f, 0.5f)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        });
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(baseScale, 0.15f);
    }
}