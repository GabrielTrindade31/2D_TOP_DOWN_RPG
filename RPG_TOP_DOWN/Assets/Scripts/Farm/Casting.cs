using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    [SerializeField] private bool dectectingPlayer;
    [SerializeField] private GameObject fishprefab;
    [SerializeField] private int percentage = 70;
    private PlayerItens player;
    private PlayerAnim playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerItens>();
        playerAnim = FindObjectOfType<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dectectingPlayer && Input.GetKeyDown(KeyCode.F))
        {
           playerAnim.OnCastingStart();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1, 100);
        if (randomValue <= percentage){
            Instantiate(fishprefab, player.transform.position + new Vector3(Random.Range(-4f,-2f), 0f, 0f), Quaternion.identity);
        }
        else{

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
