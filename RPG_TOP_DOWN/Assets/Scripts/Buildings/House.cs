using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{

    [SerializeField] private GameObject houseCollider;
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
        if (dectectingPlayer && Input.GetKeyDown(KeyCode.F) && playeritens.TotalWood >= 2)
        {
            
            isBeginning = true;
            playerAnim.OnHammeringStart();
            HouseSprite.color = startColor;
            playeritens.TotalWood -= 2;
        }
       
        if (isBeginning)
        {
            timeCount += Time.deltaTime;
            if (timeCount < timeAmount / 3)
            {
                player.transform.position = point1.position;
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                // player.transform.position = Vector3.MoveTowards(player.transform.position, point1.position, 5 * Time.deltaTime);
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
                houseCollider.SetActive(true);
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
