using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl2 : MonoBehaviour
{

    [SerializeField] float steerSpeed = 100;
    [SerializeField] float moveSpeed = 500;
    [SerializeField] Rigidbody2D myFish;
    [SerializeField] Transform fishHead;
    [SerializeField] GameObject TurtleShell;
    [SerializeField] GameObject BananaPeel;
    [SerializeField] Transform FishFire;
    [SerializeField] Transform FishThrow;
    [SerializeField] GameObject Enemy;
    bool canMove = true;
    bool isMoving = false;
    public int InverseNum = 1;
    public bool isInverse = false;
    public bool Turtle = false;
    public bool Banana = false;
    public bool Inverse = false;
    public bool Squild = false;

    // Update is called once per frame
    
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal2") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical2") * moveSpeed * Time.deltaTime;
        //Diff
       
      

        if (canMove&&!isInverse)
        {
            myFish.AddRelativeForce(new Vector2(0, moveAmount));
            transform.RotateAround(fishHead.position, new Vector3(0, 0, 1), -steerAmount);
            // transform.Translate(0, moveAmount, 0);
        }
       
        if (!canMove)
        {
            Invoke("EnableControl", 3f);
        }
       
        if (Input.GetKeyDown(KeyCode.J))
        {
            UseTurtle();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            UseBanana();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            UseInverse();
        }
    }

    public void DisableControl()
    {
        canMove = false;
        Debug.Log("I was crashed");
    }
    public void EnableControl()
    {
        canMove = true;

    }
    
    public void GetTurtle()
    {
        Turtle = true;
    }
    public void GetBanana()
    {
        Banana = true;
    }
    public void GetInverse()
    {
        Inverse = true;
    }
    public void GetSquild()
    {
        Squild = true;
    }
    public void UseTurtle()
    {
        if (Turtle == true)
        {
            Instantiate(TurtleShell, FishFire.position, FishFire.rotation);
            Turtle = false;
        }
    }
    public void UseBanana()
    {
        if (Banana == true)
        {
            Instantiate(BananaPeel, FishThrow.position, FishThrow.rotation);
            Banana = false;
        }
    }
    public void UseInverse()
    {
        if (Inverse == true)
        {
        }
    }
}
