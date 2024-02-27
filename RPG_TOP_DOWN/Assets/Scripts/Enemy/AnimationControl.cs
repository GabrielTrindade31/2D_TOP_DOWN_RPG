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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerAnim = FindObjectOfType<PlayerAnim>();
        skeleton = GetComponentInParent<Skeleton>();
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
        if (!skeleton.isdead)
        {
            Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);
            if (hit != null)
            {
                playerAnim.Onhit();
            }
        }

    }
    public void Onhit()
    {


        if (skeleton.health <= 20)
        {
            skeleton.health -= 20;
            skeleton.healthBar.fillAmount = skeleton.health / 100;
            skeleton.isdead = true;
            anim.SetTrigger("death");

            Destroy(skeleton.gameObject, 1f);
        }
        else
        {
            skeleton.health -= 20;
            skeleton.healthBar.fillAmount = skeleton.health / 100;
            anim.SetTrigger("hit");
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
