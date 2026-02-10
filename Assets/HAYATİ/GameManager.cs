using UnityEngine;
using TMPro; // Tabelayý kullanmak için bu þart

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;  // Tabela kutusu (Boþ)
    [SerializeField]private Player kuþ;
    private void Update()
    {
        scoreText.text = $"skor: {kuþ.skor}";
    }
}