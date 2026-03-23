using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverActivate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image hedefImage; 
    Color originalColor;

    void Start()
    {
        originalColor = hedefImage.color;
        hedefImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        hedefImage.transform.localScale = Vector3.one * 0.9f;
        hedefImage.gameObject.SetActive(false);
    }

    public void OnSceneReload()
    {
        if (hedefImage == null) return;

        originalColor = hedefImage.color;
        hedefImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        hedefImage.transform.localScale = Vector3.one * 0.9f;
        hedefImage.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hedefImage == null) return;

        hedefImage.gameObject.SetActive(true);

        // DOTween yoksa direkt scale ve alfa
        hedefImage.color = originalColor;
        hedefImage.transform.localScale = Vector3.one;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hedefImage == null) return;

        hedefImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        hedefImage.transform.localScale = Vector3.one * 0.9f;
        hedefImage.gameObject.SetActive(false);
    }
}