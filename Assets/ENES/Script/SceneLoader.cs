using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        // Sahne yüklenince OnSceneLoaded tetiklenecek
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Sahneyi yükle
        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Event handler’ı kaldır
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Sahnedeki tüm HoverActivate scriptlerini bul
        HoverActivate[] hovers = FindObjectsOfType<HoverActivate>();
        foreach (HoverActivate hover in hovers)
        {
            hover.OnSceneReload();
        }
    }
}