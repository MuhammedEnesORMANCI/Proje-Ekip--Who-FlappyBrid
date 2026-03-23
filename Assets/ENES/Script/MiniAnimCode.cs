using UnityEngine;
using DG.Tweening;

public class MiniAnimCode : MonoBehaviour
{
    Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void PlayAnim()
    {
        transform.DOKill(); // varsa eski tween'i sil

        transform
            .DOScale(originalScale * 1.15f, 0.1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                transform.DOScale(originalScale, 0.1f)
                .SetEase(Ease.InQuad);
            });
    }
}