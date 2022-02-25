using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public int count_down;
    public Text countNum;
    public GameObject Player1;
    public GameObject Player2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Time_count", 0f, 1.0F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Time_count()

    {

        if (count_down > 0)
        {

            count_down--;

            countNum.text = ""+count_down;

        }
        else
        {

            CancelInvoke();
            Player1.GetComponent<FishControl>().GameStart();
            Player2.GetComponent<FishControl2>().GameStart();
            Destroy(countNum);
        }

    }
}
