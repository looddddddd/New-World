using cn.bmob.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM 
{
    private static GM instance;
    public static GM Instance
    {
        get 
        {
            if (instance == null) instance = new GM();
            return instance; 
        }
    }



    public BmobUnity bmob;

    public void BmobStart()
    {
        bmob = GameObject.FindGameObjectWithTag("BmobUnity").GetComponent<BmobUnity>();
    }
    public void StartLogin()
    {
        SceneManager.LoadScene("Login");
    }
    public void StartMain()
    {
        SceneManager.LoadScene("Main");
    }
}
