using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{


    [SerializeField] private Transform attackpoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;
    private Player player;
    private Animator anim;
    private Casting casting;
    private bool isHitting;
    private float recoveryTime = 2.5f;
    private float timeCount;
    public Animator Anim { get => anim; set => anim = value; }


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        Anim = GetComponent<Animator>();
        casting = FindAnyObjectByType<Casting>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
        timeCount += Time.deltaTime;
        if (isHitting)
        {
            if (timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0f;
            }
        }
    }
    #region movement
    void OnMove()
    {
        if (!player.ispaused)
        {
            if (player._direction.sqrMagnitude > 0)
            {
                if (player._isrolling)
                {
                    Anim.SetTrigger("isRoll");
                    player._isrolling = false;
                }
                else
                {
                    Anim.SetInteger("transition", 1);
                }
            }
            else
            {
                Anim.SetInteger("transition", 0);
            }
            if (player._direction.x > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            if (player._direction.x < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            if (player._iscutting)
            {
                Anim.SetInteger("transition", 3);
            }
            if (player._isdigging)
            {
                Anim.SetInteger("transition", 4);
            }
            if (player._iswatering)
            {
                Anim.SetInteger("transition", 5);
            }
        }
        if (player.ispaused)
        {
            Anim.SetInteger("transition", 0);
        }
    }
    void OnRun()
    {
        if (player._isrunning && !player.ispaused)
        {
            Anim.SetInteger("transition", 2);
        }
        if (player.ispaused)
        {
            Anim.SetInteger("transition", 0);
        }
    }
    #endregion

    #region Attack

    public void OnAtack(){

        Collider2D hit = Physics2D.OverlapCircle(attackpoint.position, radius,enemyLayer);

        if (hit != null){
            hit.GetComponentInChildren<AnimationControl>().Onhit();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpoint.position, radius);
    }


    #endregion
    public void OnCastingStart()
    {
        anim.SetTrigger("isCasting");
        player.ispaused = true;
    }

    public void OnCastingEnd()
    {
        casting.OnCasting();
        player.ispaused = false;
    }
    public void OnHammeringStart()
    {
        anim.SetBool("building", true);
        player.ispaused = true;
    }

    public void OnHammeringEnd()
    {
        anim.SetBool("building", false);
        player.ispaused = false;
    }
    public void Onhit()
    {
        if (!isHitting)
        {
            anim.SetTrigger("hit");
            player.health -= 10f;
            isHitting = true;
        }
    }
}
