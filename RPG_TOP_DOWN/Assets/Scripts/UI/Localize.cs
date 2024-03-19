using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
public class Localize : MonoBehaviour
{
    private bool active = false;

    private void Start(){
        int ID = PlayerPrefs.GetInt("LocaleKey", 0);
        ChangeLanguage(ID);
        Debug.Log(ID);
    }
    public void ChangeLanguage(int localeIndex){
        if(active == true){
            Debug.Log("rodou");
            Debug.Log(localeIndex);
            return;
            
        }
        StartCoroutine(SetLanguage(localeIndex));
    }
    IEnumerator SetLanguage(int _localeIndex){
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeIndex];
        active = false;
    }
}
