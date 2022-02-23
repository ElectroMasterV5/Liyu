using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleShellControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D Turtle;
    [SerializeField] float moveSpeed = 700;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = moveSpeed * Time.deltaTime;
        Turtle.AddRelativeForce(new Vector2(0, moveAmount));
        Invoke("DestroyMyself", 20f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<FishControl>().DisableControl();
            DestroyMyself();
        }
        if (collision.transform.tag == "Player2")
        {
            collision.transform.GetComponent<FishControl2>().DisableControl();
            DestroyMyself();
        }
    }
    public void DestroyMyself()
    {
        Destroy(this.gameObject);
    }
}
