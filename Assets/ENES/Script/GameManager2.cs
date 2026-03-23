using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public int skor = 0;

    [Header("Skor Resim Ayarlarý")]
    public Sprite[] rakamResimleri; // 0-9 arasý resimler
    public GameObject rakamPrefab;  // Sayý oluþturmak için örnek obje

    [Header("Paneller")]
    public GameObject oyunIciSkorPaneli;
    public GameObject oyunIciSkorPaneliStart;// Oyunun tepesindeki skor
    public GameObject finalSkorPaneli;   // Game Over tablosundaki skor yeri
    public GameObject enYuksekSkorPaneli;// Game Over tablosundaki BEST yeri
    public GameObject gameOverPanel;     // Tüm Game Over ekraný

    private void Awake()
    {
        OyunuDurdur();
    }
    private void Start()
    {
    
    }
    public void Menu()
    {

       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void OyunuDurdur()
    {
        Time.timeScale = 0;
    }
    public void OyunuDevamEttir()
    {
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        // Oyun baþladýðýnda sadece tepe skoru
        oyunIciSkorPaneli.SetActive(true);
        oyunIciSkorPaneliStart.SetActive(false);
        PuanYazdir(skor, oyunIciSkorPaneli);
    }

    public void SkorArtir()
    {
        skor++;
        PuanYazdir(skor, oyunIciSkorPaneli);
    }

    // BU FONKSÝYON ARTIK HER YERE SAYI YAZABÝLÝYOR
    void PuanYazdir(int sayi, GameObject hedefPanel)
    {
        // 1. Panelin içini temizle
        foreach (Transform child in hedefPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // 2. Sayýyý resimlere çevirip panele diz
        string sayiString = sayi.ToString();
        foreach (char karakter in sayiString)
        {
            int rakam = int.Parse(karakter.ToString());
            GameObject yeniRakam = Instantiate(rakamPrefab, hedefPanel.transform);
            yeniRakam.GetComponent<Image>().sprite = rakamResimleri[rakam];
        }
    }

    public void OyunBitti()
    {
        // 1. Oyun içi skoru gizle
        oyunIciSkorPaneli.SetActive(false);

        // 2. Game Over panelini aç
        if (gameOverPanel != null) gameOverPanel.SetActive(true);

        // 3. En Yüksek Skoru Hesapla ve Kaydet (PlayerPrefs)
        int enYuksekSkor = PlayerPrefs.GetInt("Rekor", 0); // Kayýtlý rekoru getir

        if (skor > enYuksekSkor)
        {
            enYuksekSkor = skor;
            PlayerPrefs.SetInt("Rekor", enYuksekSkor); // Yeni rekoru kaydet
        }

        // 4. Tabelaya Skorlarý Yazdýr
        PuanYazdir(skor, finalSkorPaneli);       // Senin Skorun
        PuanYazdir(enYuksekSkor, enYuksekSkorPaneli); // Rekor

        Time.timeScale = 0;
    }

    public void TekrarOyna()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        oyunIciSkorPaneli.SetActive(false);
        oyunIciSkorPaneliStart.SetActive(true);
    }
}