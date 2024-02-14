using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [Header("Settings")]
    [SerializeField] private int digAmount;
    [SerializeField] private float waterAmount;
    [SerializeField] private bool detecting;
    PlayerItens playeritems;
    private bool dugHole;
    private float currentWater;
    private bool colleting;
    private int initialdigAmount;
    // Start is called before the first frame update
    void Start()
    {
        initialdigAmount = digAmount;
        playeritems = FindObjectOfType<PlayerItens>();
    }

    void Update()
    {
        if (dugHole)
        {
            if (detecting)
            {
                currentWater += 0.1f;
            }
            if (currentWater >= waterAmount)
            {
                spriteRenderer.sprite = carrot;
                if (Input.GetKeyDown(KeyCode.E) && colleting)
                {
                    spriteRenderer.sprite = hole;
                    playeritems.TotalCarrot += 1;
                    currentWater = 0;
                }
            }
        }
    }
    // Update is called once per frame

    public void Onhit()
    {
        digAmount--;

        if (digAmount <= initialdigAmount / 2)
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shove"))
        {
            Onhit();
        }
        if (collision.CompareTag("Watering can"))
        {
            detecting = true;
        }
        if (collision.CompareTag("Player"))
        {
            colleting = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Watering can"))
        {
            detecting = false;
        }
        if (collision.CompareTag("Player"))
        {
            colleting = false;
        }
    }
}
