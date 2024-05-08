using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] Color fadeColor;
    [SerializeField] float fadeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        FadeToClear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FadeToClear()
    {
        fadeImage.color = fadeColor;
        StartCoroutine(FadeToClearRoutine());
        IEnumerator FadeToClearRoutine()
        {
            float timer = 0;
            while (timer < fadeTime)
            {
                yield return null;
                timer+=Time.deltaTime;
                fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b,1f - (timer/fadeTime));
            }
            fadeImage.color = Color.clear;
        }
    }

    public void FadeToColor(string newScene = "")
    {
        fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b,0);
        StartCoroutine(FadeToColorRoutine());
        IEnumerator FadeToColorRoutine()
        {
            float timer = 0;
            while (timer < fadeTime)
            {
                yield return null;
                timer+=Time.deltaTime;
                fadeImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b,(timer/fadeTime));
            }
            fadeImage.color = fadeColor;

            if (newScene != "")
                SceneManager.LoadScene(newScene);
        }
    }
}
