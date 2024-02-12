using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer; 
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private int digAmount;

    private int initialdigAmount;
    // Start is called before the first frame update
    void Start()
    {
        initialdigAmount = digAmount;
    }

    // Update is called once per frame

    public void Onhit()
    {   
        digAmount--;

        if (digAmount <= initialdigAmount/2){
           spriteRenderer.sprite = hole;
        }
        if (digAmount <= 0){
            spriteRenderer.sprite = carrot;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shove"))
        {
            Onhit();
        }
    }
}
