using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    public Animator Anim { get => anim; set => anim = value; }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        Anim = GetComponent<Animator>();
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
    void OnRun()
    {
        if (player._isrunning)
        {
            Anim.SetInteger("transition", 2);
        }
    }
    #endregion
}
