using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private Casting casting;

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
        if(player.ispaused)
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
         if(player.ispaused)
        {
            Anim.SetInteger("transition", 0);
        }
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
}
