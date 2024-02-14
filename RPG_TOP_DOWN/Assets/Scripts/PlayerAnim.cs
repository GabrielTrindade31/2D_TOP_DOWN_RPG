using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
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
        if (player._direction.sqrMagnitude > 0)
        {
            if (player._isrolling)
            {
                anim.SetTrigger("isRoll");
                player._isrolling = false;
            }
            else
            {
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
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
            anim.SetInteger("transition", 3);
        }
        if (player._isdigging)
        {
            anim.SetInteger("transition", 4);
        }
        if (player._iswatering)
        {
            anim.SetInteger("transition", 5);
        }
    }
    void OnRun()
    {
        if (player._isrunning)
        {
            anim.SetInteger("transition", 2);
        }
    }
    #endregion
}
