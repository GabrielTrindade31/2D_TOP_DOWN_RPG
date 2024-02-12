using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code that control the player
public class Player : MonoBehaviour
{

    public int health;
    [SerializeField] private float speed;
    [SerializeField] private float runspeed;
    private float initialSpeed;
    private bool isrunning;
    private bool isrolling;
    private bool iscutting;
    private bool isdigging;
    private int handlingObj;
    private Rigidbody2D rig;
    private Vector2 direction;
    // Start is called before the first frame update

    public bool _isrolling{
        get { return isrolling; }
        set { isrolling = value; }
    }
    public bool _isrunning
    {
        get { return isrunning; }
        set { isrunning = value; }
    }
    public bool _iscutting
    {
        get { return iscutting; }
        set { iscutting = value; }
    }
    public bool _isdigging
    {
        get { return isdigging; }
        set { isdigging = value; }
    }
    public Vector2 _direction
    {
        get { return direction; }
        set { direction = value; }
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            handlingObj = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            handlingObj = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            handlingObj = 3;
        }
        //Control the direction in every frame of the player
        OnInput();
        OnRun();
        Onrolling();
        Oncutting();
        OnDigging();

    }
    private void FixedUpdate()
    {
        //Code that control the position of the rigibody in the scene, with this we control the fisics
        OnMove();
    }
    void Atack()
    {
        //code to atack
    }
    #region Movement
    void Oncutting(){
        if(handlingObj == 1){
            if(Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift)){
                iscutting = true;
                speed = 0f;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                iscutting = false;
                speed = initialSpeed;
            }
        }
        
    }
    void OnDigging(){
        if(handlingObj == 2){
           if(Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift)){
            isdigging = true;
            speed = 0f;
            }
            else if (Input.GetMouseButtonUp(0))
            {
            isdigging = false;
            speed = initialSpeed;
            } 
        }
    }
    void OnInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void OnMove()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }
    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runspeed;
            isrunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isrunning = false;
        }
    }

    void Onrolling()
    {

        if (Input.GetMouseButtonDown(1))
        {
            isrolling = true;
            speed = runspeed;

        }
        else if (Input.GetMouseButtonUp(1))
        {
            isrolling = false;
            speed = initialSpeed;
        }
    }
    #endregion
}
