using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{

    [SerializeField] private SpriteRenderer HouseSprite;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Transform point3;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmount;
    private float timeCount;
    private bool isBeginning;
    private bool dectectingPlayer;

    private Player player;
    private PlayerAnim playerAnim;
    private PlayerItens playeritens;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playeritens = player.GetComponent<PlayerItens>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dectectingPlayer && Input.GetKeyDown(KeyCode.F) && playeritens.totalWood >= 3)
        {
            isBeginning = true;
            playerAnim.OnHammeringStart();
            HouseSprite.color = startColor;
            transform.position = Vector2.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
        }
        transform.position = Vector2.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
        if (isBeginning)
        {
            timeCount += Time.deltaTime;
            if (timeCount < timeAmount / 3)
            {
                player.transform.position = point1.position;
            }
            else if (timeCount < timeAmount * 2 / 3)
            {
                player.transform.rotation = Quaternion.Euler(0, -180, 0);
                player.transform.position = point2.position;
            }
            else if (timeCount < timeAmount)
            {
                player.transform.position = point3.position;
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            player.ispaused = true;
            if (timeCount >= timeAmount)
            {
                playerAnim.OnHammeringEnd();
                HouseSprite.color = endColor;
                player.ispaused = false;
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
