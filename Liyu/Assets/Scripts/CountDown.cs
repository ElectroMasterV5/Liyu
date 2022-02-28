using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Image shownImage;
    public Sprite[] countDownImages;
    public int count_down;
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
            shownImage.sprite = countDownImages[count_down];
            // countNum.text = ""+count_down;

        }
        else
        {
            CancelInvoke();
            Player1.GetComponent<FishControl>().GameStart();
            Player2.GetComponent<FishControl2>().GameStart();
            shownImage.gameObject.SetActive(false);
        }

    }

    //event function for restart level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //event function
    public void QuitGame()
    {
        Application.Quit();
    }
}
