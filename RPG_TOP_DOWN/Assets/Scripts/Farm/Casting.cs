using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Casting : MonoBehaviour
{
    [SerializeField] private bool dectectingPlayer;
    [SerializeField] private GameObject fishprefab;
    [SerializeField] private int percentage = 70;
    private PlayerItens player;
    private Player player1;
    private PlayerAnim playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerItens>();
        playerAnim = FindObjectOfType<PlayerAnim>();
        player1 = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (dectectingPlayer && Input.GetKeyDown(KeyCode.F) && playerAnim.isCasting == false)
        {
            player1.ispaused = true;
            playerAnim.OnCastingStart();

        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);
        if (randomValue <= percentage)
        {
            int layerMask = 1 << 0 | 1 << -1;

            if ((Physics2D.Raycast(player.transform.position, player.transform.right, 2, layerMask, -0.04971060f, -0.05171068f)) && (Physics2D.Raycast(player.transform.position, -player.transform.right, 2, layerMask, -0.04971060f, -0.05171068f)) && (Physics2D.Raycast(player.transform.position, -player.transform.up, 2, layerMask, -0.04971060f, -0.05171068f)))
            {
                Instantiate(fishprefab, player.transform.position + new Vector3(0f, Random.Range(1f, 2f), 0f), Quaternion.identity);
            }
            else if ((Physics2D.Raycast(player.transform.position, player.transform.right, 2, layerMask, -0.04971060f, -0.05171068f)) && (Physics2D.Raycast(player.transform.position, -player.transform.right, 2, layerMask, -0.04971060f, -0.05171068f)) && (Physics2D.Raycast(player.transform.position, player.transform.up, 2, layerMask, -0.04971060f, -0.05171068f)))
            {
                Instantiate(fishprefab, player.transform.position + new Vector3(0f, Random.Range(-2f, -1f), 0f), Quaternion.identity);
            }
            else if (Physics2D.Raycast(player.transform.position, player.transform.right, 2, layerMask, -0.04971060f, -0.05171068f) && (player.transform.rotation == Quaternion.Euler(0, -180, 0)))
            {
                Instantiate(fishprefab, player.transform.position + new Vector3(Random.Range(1f, 2f), 0f, 0f), Quaternion.identity);
            }
            else if (Physics2D.Raycast(player.transform.position, player.transform.right, 2, layerMask, -0.04971060f, -0.05171068f) && (player.transform.rotation == Quaternion.Euler(0, 0, 0)))
            {
                Instantiate(fishprefab, player.transform.position + new Vector3(Random.Range(-2f, -1f), 0f, 0f), Quaternion.identity);
            }
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
