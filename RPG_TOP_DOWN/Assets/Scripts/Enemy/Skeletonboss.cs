using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Skeletonboss : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationControl animcontrol;

    public LayerMask playerLayer;
    public float followingRange;
    public Image healthBar;
    public bool isdead = false;
    public bool isalive;
    public float health = 100;
    public float maxHealth = 100;
    private Player player;
    private bool detectPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(health >0 && !isdead){
            isalive = true;
        }
        if (!isdead && detectPlayer)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
            if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                animcontrol.PlayAnim(2);
            }
            else
            {
                animcontrol.PlayAnim(1);
            }
            float posX = player.transform.position.x - transform.position.x;
            if (posX > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
    }
    private void FixedUpdate()
    {
        DetectPlayer();
    }

    public void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, followingRange, playerLayer);

        if (hit != null)
        {
            detectPlayer = true;
        }
        else
        {
            detectPlayer = false;
            animcontrol.PlayAnim(0);
            agent.isStopped = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, followingRange);
    }

}
