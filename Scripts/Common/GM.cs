using cn.bmob.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GM 
{
    public static BmobUnity bmob;

    public static void BmobStart()
    {
        bmob = GameObject.FindGameObjectWithTag("BmobUnity").GetComponent<BmobUnity>();
    }
}
