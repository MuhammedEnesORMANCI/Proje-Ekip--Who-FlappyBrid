using UnityEngine;

public class KusEtkilesim : MonoBehaviour
{
    // GameManager'a ulaþmak için deðiþken
    GameManager yonetici;

    void Start()
    {
        // Oyun baþladýðýnda sahnedeki GameManager'ý otomatik bulur
        yonetici = FindObjectOfType<GameManager>();
    }

    // 1. Sensörden (boruarasi) geçince puan kazan
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boruarasi"))
        {
            yonetici.SkorArtir();
        }
    }

    // 2. Boruya çarpýnca oyun bitsin
    private void OnCollisionEnter2D(Collision2D collision)
    {
        yonetici.OyunBitti();
    }
}