using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    private Fader fader;
    [SerializeField] CanvasGroup darknessCanvas;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        fader = FindObjectOfType<Fader>();
        darknessCanvas.alpha = 1;

    }

    public void Play()
    {
        StartCoroutine(LoadMainScene());
    }

    public IEnumerator LoadMainScene()
    {
        yield return StartCoroutine(fader.FadeInElement(darknessCanvas, 1));
        SceneManager.LoadScene(1);
    }
}
