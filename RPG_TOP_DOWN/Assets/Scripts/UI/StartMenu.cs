using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup Idiom;
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Language()
    {
       SceneManager.LoadScene("Language");
    }
    public void QuitGame()
    {
       Application.Quit();
    }
}
