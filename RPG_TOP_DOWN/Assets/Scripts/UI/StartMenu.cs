using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class StartMenu : MonoBehaviour
{

    [SerializeField] CanvasGroup Idiom;
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LanguageSet()
    {

        Idiom.DOFade(1, .25f);
        Idiom.blocksRaycasts = true;
        Idiom.interactable = true;
        //SceneManager.LoadScene("Credits");
    }
    public void CloseLanguageSet()
    {

        Idiom.DOFade(0, .25f);
        Idiom.blocksRaycasts = false;
        Idiom.interactable = false;
        //SceneManager.LoadScene("Credits");
    }
}
