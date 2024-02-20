using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;
    // Start is called before the first frame update
    bool palyerHit;
    public Sprite profileSprite1;
    public Player player;
    
    
    private void Start()
    {
        GetNPCInfo(); 
        player = FindAnyObjectByType<Player>();
    }
    private List<string> sentences = new List<string>();
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && palyerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
            player.ispaused = true;
        }
    }

    void GetNPCInfo()
    {
        for(int i=0; i<dialogue.dialogues.Count; i++)
        {
            switch(DialogueControl.instance.language){
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
                case DialogueControl.idiom.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            }
            
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            palyerHit = true;
            DialogueControl.instance.profileSprite.sprite = profileSprite1;
            player.ispaused = true;
        }
        else
        {
            palyerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
