using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveInverse : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.GetComponent<FishControl>().GetInverse();
            Debug.Log("get inverse");
            DestroyMyself();
        }
        if (collision.tag == "Player2")
        {
            collision.transform.GetComponent<FishControl2>().GetInverse();
            DestroyMyself();
        }
    }
    public void DestroyMyself()
    {
        Destroy(this.gameObject);
    }
}
