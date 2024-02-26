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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerAnim = FindObjectOfType<PlayerAnim>();
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
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);
        if (hit != null)
        {
            playerAnim.Onhit();
        }
        else
        {

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
