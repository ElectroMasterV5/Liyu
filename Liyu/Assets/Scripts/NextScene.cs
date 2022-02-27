using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Sprite[] Images;
    public string nextScene;
    public Image thisImage;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangePicture()
    {

        if (i == 6)
        {
            i = 0;
            SceneManager.LoadScene(nextScene);
            return;
        }
        // var i = 0;
        Debug.Log(i);
        thisImage.sprite = Images[i++];
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
