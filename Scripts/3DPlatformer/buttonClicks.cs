using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonClicks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMyButtonClickStart()
    {
        Debug.Log("Start button clicked!");
        SceneManager.LoadScene(1);
    }

    public void onMyButtonClickInfo()
    {
        Debug.Log("Info button clicked");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
