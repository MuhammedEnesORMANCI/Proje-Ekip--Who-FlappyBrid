using UnityEngine;

public class KusKontrol : MonoBehaviour
{
    public GameManager gameManager; // GameManager'a eriþim saðlayacaðýz
    public float ziplamaGucu = 5f; // Kuþun zýplama gücü
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Oyun baþladýðýnda sahnedeki GameManager'ý otomatik bulur
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        // Sol týk veya ekrana dokunma ile zýplama
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * ziplamaGucu;
        }
    }

    // 1. DURUM: Sensörden (boruarasi) geçince puan kazan
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boruarasi"))
        {
            gameManager.SkorArtir();
        }
    }

    // 2. DURUM: Boruya veya yere çarpýnca oyun bitsin
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.OyunBitti();
    }
}