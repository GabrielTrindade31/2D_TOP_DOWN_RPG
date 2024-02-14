using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private bool dectectingPlayer;
    [SerializeField] private int watervalue;
    private PlayerItens player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerItens>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dectectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            player.WaterLimit(watervalue);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dectectingPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dectectingPlayer = false;
    }
}
