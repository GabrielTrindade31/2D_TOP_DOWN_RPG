using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;
    private Animator anim;
    private PlayerAnim playerAnim;
    private Skeleton skeleton;
    private Skeletonboss skeletonboss;
    private SpawnEnemy spawnEnemy;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindAnyObjectByType<Player>();
        playerAnim = FindObjectOfType<PlayerAnim>();
        skeleton = GetComponentInParent<Skeleton>();
        skeletonboss = GetComponentInParent<Skeletonboss>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayAnim(int value)
    {
        anim.SetInteger("transition", value);
    }
    public void Atack()
    {
        if (skeleton != null)
        {
            if (!skeleton.isdead)
            {
                Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);
                if (hit != null && player.isdead == false)
                {
                    playerAnim.Onhit();
                }
            }
        }
        if (skeletonboss != null)
        {
            if (!skeletonboss.isdead)
            {
                Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);
                if (hit != null && player.isdead == false)
                {
                    playerAnim.Onhit();
                }
            }
        }

    }
    public void Onhit()
    {

        if (skeleton != null)
        {
            if (skeleton.health <= 20)
            {
                skeleton.health -= 20;
                skeleton.healthBar.fillAmount = skeleton.health / skeleton.maxHealth;
                skeleton.isdead = true;
                anim.SetTrigger("death");
                spawnEnemy.OnEnemyDeath(GameObject.Find("Skeleton"));
                Destroy(skeleton.gameObject, 1f);
            }
            else
            {
                skeleton.health -= 20;
                skeleton.healthBar.fillAmount = skeleton.health / skeleton.maxHealth;
                anim.SetTrigger("hit");
            }
        }
        if (skeletonboss != null)
        {
            if (skeletonboss.health <= 20)
            {
                skeletonboss.health -= 20;
                skeletonboss.healthBar.fillAmount = skeletonboss.health / skeletonboss.maxHealth;
                skeletonboss.isdead = true;
                skeletonboss.isalive = false;
                anim.SetTrigger("death");
                spawnEnemy.OnEnemyDeath(GameObject.Find("Skeleton_boss"));
                Destroy(skeletonboss.gameObject, 1f);
            }
            else
            {
                skeletonboss.health -= 20;
                skeletonboss.healthBar.fillAmount = skeletonboss.health / skeletonboss.maxHealth;
                anim.SetTrigger("hit");
            }
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
