using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReturnGame()
    {
       SceneManager.LoadScene("MenuStart");
    }
}
