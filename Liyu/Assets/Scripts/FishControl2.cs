using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishControl2 : MonoBehaviour
{

    [SerializeField] float steerSpeed = 100;
    [SerializeField] float moveSpeed = 500;
    [SerializeField] Rigidbody2D myFish;
    [SerializeField] Transform fishHead;
    [SerializeField] GameObject TurtleShell;
    [SerializeField] GameObject BananaPeel;
    public Image Ink;
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
    public bool GetInked = false;
    public bool Missile = false;
    public Sprite[] TurtleIcon;
    public Sprite[] BananaIcon;
    public Sprite[] InverseIcon;
    public Sprite[] SquildIcon;
    public Sprite[] MissileIcon;
    public Image IconJ;
    public Image IconK;
    public Image IconL;
    public Image IconU;
    public Image IconI;
    // Update is called once per frame
    private void Start()
    {
        IconJ.sprite = TurtleIcon[0];
        IconK.sprite = BananaIcon[0];
        IconL.sprite = InverseIcon[0];
        IconU.sprite = MissileIcon[0];
        IconI.sprite = SquildIcon[0];
    }
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal2") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical2") * moveSpeed * Time.deltaTime;
        //Diff
        if (moveAmount != 0)
        {

        }
        if (canMove && !isInverse)
        {
            myFish.AddRelativeForce(new Vector2(0, moveAmount));
            transform.RotateAround(fishHead.position, new Vector3(0, 0, 1), -steerAmount);
            // transform.Translate(0, moveAmount, 0);
        }
        if (canMove && isInverse)
        {
            myFish.AddRelativeForce(new Vector2(0, moveAmount));
            transform.RotateAround(fishHead.position, new Vector3(0, 0, 1), steerAmount);
            Invoke("NormalOp", 5f);
            // transform.Translate(0, moveAmount, 0);
        }
        if (GetInked)
        {
            Invoke("Clean", 5f);
        }
        if (!canMove)
        {
            Invoke("EnableControl", 3f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            UseTurtle();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            UseBanana();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            UseInverse();
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            UseSquild();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            UseMissile();
        }
    }
    public void InverseOp()
    {
        isInverse = true;
    }
    public void NormalOp()
    {
        isInverse = false;
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
        IconJ.sprite = TurtleIcon[1];

        Turtle = true;
    }
    public void GetBanana()
    {

        IconK.sprite = BananaIcon[1];

        Banana = true;
    }
    public void GetInverse()
    {

        IconL.sprite = InverseIcon[1];

        Inverse = true;
    }
    public void GetSquild()
    {

        IconI.sprite = SquildIcon[1];
        Squild = true;
    }
    public void GetMissile()
    {

        IconU.sprite = MissileIcon[1];

        Missile = true;
    }
    public void UseTurtle()
    {
        if (Turtle == true)
        {
            Instantiate(TurtleShell, FishFire.position, FishFire.rotation);
            IconJ.sprite = TurtleIcon[0];

            Turtle = false;
        }
    }
    public void UseBanana()
    {
        if (Banana == true)
        {
            Instantiate(BananaPeel, FishThrow.position, FishThrow.rotation);

            IconK.sprite = BananaIcon[0];

            Banana = false;
        }
    }
    public void UseInverse()
    {
        if (Inverse == true)
        {
            Enemy.GetComponent<FishControl>().InverseOp();
            //Diff
            IconL.sprite = InverseIcon[0];

            Inverse = false;
        }
    }
    public void UseSquild()
    {
        if (Squild == true)
        {

            IconI.sprite = SquildIcon[0];
            Ink.color = new Color(255f, 255f, 255f, 1f);
            GetInked = true;
            Squild = false;
        }
    }
    public void UseMissile()
    {
        if (Missile == true)
        {
            Enemy.GetComponent<FishControl>().DisableControl();
            //Diff
            IconU.sprite = MissileIcon[0];

            Missile = false;
        }
    }
    public void Clean()
    {
        Ink.color = new Color(255, 255, 255, 0f);
        GetInked = false;
    }
    public void GetRandom()
    {
        float randomNum = Random.Range(0f, 4f);
        if (randomNum < 1f)
        {
            IconJ.sprite = TurtleIcon[1];

            Turtle = true;
        }
        if (randomNum < 2f && randomNum >= 1f)
        {

            IconK.sprite = BananaIcon[1];

            Banana = true;
        }
        if (randomNum < 3f && randomNum >= 2f)
        {

            IconI.sprite = SquildIcon[1];
            Squild = true;
        }
        if (randomNum <= 4f && randomNum >= 3f)
        {

            IconL.sprite = InverseIcon[1];

            Inverse = true;
        }
    }
}
