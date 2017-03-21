using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginSceneMediator : BaseSceneMediator
{
    protected override void OnStart()
    {
        base.OnStart();
        GM.Instance.BmobStart();
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("BmobUnity"));
    }
}
