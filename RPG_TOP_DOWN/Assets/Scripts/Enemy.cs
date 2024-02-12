using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
    public int health;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enemy Created");
    }
    // Update is called once per frame
    void Update()
    {
    
    }
    void FollowPlayer()
    {
        //code to enemy follow the player
    }
     void SeekPlayer()
    {
        //code to enemy seek the player
    }
    void Atack()
    {
        //code to enemy atack the player
    }
    void Movement ()
    {
        //code to enemy movement
    }
}

