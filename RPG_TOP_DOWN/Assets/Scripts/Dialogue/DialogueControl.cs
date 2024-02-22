using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialolueObj;//dialogue windown
    public Image profileSprite;//sprite of the actor
    public TextMeshProUGUI speechText;//text of the speech
    public Text actorNameText;//Name of npc
    private Player player;
    private PlayerAnim playeranim;
    private NPC_Dialogue npc;

    [Header("Settings")]
    public float typingSpeed;//speed of the speech

    //variables of control
    [HideInInspector]public bool isShowing;// if the windown is visible

    private int index;// infex of the setences
    private string[] sentences;//array of the sentences
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }
    public idiom language;
    public static DialogueControl instance;

    //awake is called before all the Starts() in the hyrarchy of the script execution
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        playeranim = player.GetComponent<PlayerAnim>();
    }

    void Update()
    {

    }
    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentece()
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialolueObj.SetActive(false);
                sentences = null;
                isShowing = false;
                player.ispaused = false;
                playeranim.Anim.SetInteger("transition", 0);
            }
        }
    }
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialolueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
            player.ispaused = true;
        }
    }
}
