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
    public float stopTime;
    public int InverseNum = 1;
    public bool hasProps;
    public bool isInverse = false;
    public bool Turtle = false;
    public bool Banana = false;
    public bool Inverse = false;
    public bool Squild = false;
    public bool GetInked = false;
    public bool Missile = false;
    public bool FinalStart = false;
    public Sprite[] TurtleIcon;
    public Sprite[] BananaIcon;
    public Sprite[] InverseIcon;
    public Sprite[] SquildIcon;
    public Sprite[] MissileIcon;
    public Image Icon;
    public Image IconJ;
    public Image IconK;
    public Image IconL;
    public Image IconU;
    public Image IconI;
    // Update is called once per frame
    private void Start()
    {
        Icon.sprite = null;
        IconJ.sprite = TurtleIcon[0];
        IconK.sprite = BananaIcon[0];
        IconU.sprite = MissileIcon[0];
        IconI.sprite = SquildIcon[0];
    }
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal2") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical2") * moveSpeed * Time.deltaTime;
        //Diff
        if (canMove && !isInverse && FinalStart)
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
        // if (GetInked)
        // {
        //     Invoke("Clean", 5f);
        // }
        if (!canMove)
        {
            Invoke("EnableControl", stopTime);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UseTurtle();
            UseBanana();
            UseInverse();
            UseSquild();
            UseMissile();
        }
        // if (Input.GetKeyDown(KeyCode.X))
        // {
        //     UseBanana();
        // }
        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     UseInverse();
        // }
        // if (Input.GetKeyDown(KeyCode.B))
        // {
        //     UseSquild();
        // }
        // if (Input.GetKeyDown(KeyCode.V))
        // {
        //     UseMissile();
        // }
    }
    public void GameStart()
    {
        FinalStart = true;
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
        if (hasProps)
        {
            return;
        }
        Icon.sprite = TurtleIcon[1];
        hasProps = true;
        Turtle = true;
    }
    public void GetBanana()
    {
        if (hasProps)
        {
            return;
        }
        Icon.sprite = BananaIcon[1];
        hasProps = true;
        Banana = true;
    }
    public void GetInverse()
    {
        if (hasProps)
        {
            return;
        }
        Icon.sprite = InverseIcon[1];
        hasProps = true;
        Inverse = true;
    }
    public void GetSquild()
    {
        if (hasProps)
        {
            return;
        }
        Icon.sprite = SquildIcon[1];
        hasProps = true;
        Squild = true;
    }
    public void GetMissile()
    {
        if (hasProps)
        {
            return;
        }
        Icon.sprite = MissileIcon[1];
        hasProps = true;
        Missile = true;
    }
    public void UseTurtle()
    {
        if (!Turtle & hasProps)
        {
            return;
        }
        if(Turtle == true)
        {
            Instantiate(TurtleShell, FishFire.position,FishFire.rotation);
            hasProps = false;
            Turtle = false;
            Icon.sprite = null;
        }
    }
    public void UseBanana()
    {
        if (!Banana & hasProps)
        {
            return;
        }
        if (Banana == true)
        {
            Instantiate(BananaPeel, FishThrow.position, FishThrow.rotation);
            hasProps = false;
            Banana = false;
            Icon.sprite = null;
        }
    }
    public void UseInverse()
    {
        if (!Inverse & hasProps)
        {
            return;
        }
        if (Inverse == true)
        {
            Enemy.GetComponent<FishControl>().InverseOp();
            hasProps = false;
            Inverse = false;
            Icon.sprite = null;
        }
    }
    public void UseSquild()
    {
        if (!Squild & hasProps)
        {
            return;
        }
        if (Squild)
        {
            Ink.color = new Color(255f, 255f, 255f, 1f);
            // GetInked = true;
            hasProps = false;
            Squild = false;
            Icon.sprite = null;
            Debug.Log("Squid");
            StartCoroutine(FadeColor());
        }
    }

    IEnumerator FadeColor()
    {
        yield return new WaitForSeconds(2f);
        Ink.color = new Color(255, 255, 255, 0f);
    }
    public void UseMissile()
    {
        if (!Missile & hasProps)
        {
            return;
        }
        if (Missile == true)
        {
            // Icon.sprite = MissileIcon[0];
            Enemy.GetComponent<FishControl>().DisableControl();
            //Diff
            IconU.sprite = MissileIcon[0];
            hasProps = false;
            Missile = false;
            Icon.sprite = null;
        }
    }
    // public void Clean()
    // {
    //         Ink.color = new Color(255, 255, 255, 0f);
    //         GetInked = false;
    // }
    public void GetRandom()
    {
        if (hasProps)
        {
            return;
        }
        float randomNum = Random.Range(0f, 5f);
        if(randomNum < 1f)
        {
            Icon.sprite = TurtleIcon[1];
            IconJ.sprite = TurtleIcon[1];
            hasProps = true;
            Turtle = true;
        }
        if (randomNum < 2f&&randomNum >=1f)
        {
            Icon.sprite = BananaIcon[1];
            IconK.sprite = BananaIcon[1];
            hasProps = true;
            Banana = true;
        }
        if (randomNum < 3f && randomNum >= 2f)
        {
            Icon.sprite = SquildIcon[1];
            IconI.sprite = SquildIcon[1];
            hasProps = true;
            Squild = true;
        }
        if (randomNum < 4f && randomNum >= 3f)
        {
            Icon.sprite = TurtleIcon[1];
            IconL.sprite = InverseIcon[1];
            hasProps = true;
            Inverse = true;
        }
        if (randomNum < 5f && randomNum >= 4f)
        {
            Icon.sprite = MissileIcon[1];
            hasProps = true;
            Missile = true;
        }
    }
}
