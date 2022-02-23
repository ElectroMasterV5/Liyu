using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBanana : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.GetComponent<FishControl>().GetBanana();
            DestroyMyself();
        }
        if (collision.tag == "Player2")
        {
            collision.transform.GetComponent<FishControl2>().GetBanana();
            DestroyMyself();
        }
    }
    public void DestroyMyself()
    {
        Destroy(this.gameObject);
    }
}
