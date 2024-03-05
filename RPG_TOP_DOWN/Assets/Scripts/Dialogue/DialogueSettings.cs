using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
   [Header("Settings")]
   public GameObject actor;
   
   [Header("Dialogue")]
   public Sprite speakerSprite;
   public string sentence;
   public string actorName;
   public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}
[System.Serializable]
public class Languages
{
    public string english;
    public string portuguese;
    public string spanish;

}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings ds = (DialogueSettings)target;

        Languages l = new Languages();
        l.portuguese = ds.sentence;

        Sentences s  = new Sentences();
        s.profile = ds.speakerSprite;
        s.sentence = l;

        if(GUILayout.Button("Create Dialogue")){
            if(ds.sentence != ""){
                ds.dialogues.Add(s);
                ds.actorName = null;
                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
    }
}
#endif