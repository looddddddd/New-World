using cn.bmob.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM :Singleton<GM>
{
    /// <summary>
    /// Bmob脚本引用
    /// </summary>
    public BmobUnity bmob{get;set;}
    /// <summary>
    /// 初始化Bmob对象
    /// </summary>
    public void BmobStart()
    {
        bmob = GameObject.FindGameObjectWithTag("BmobUnity").GetComponent<BmobUnity>();
    }
    /// <summary>
    /// 登录场景
    /// </summary>
    public void StartLogin()
    {
        SceneManager.LoadScene("Login");
    }
    /// <summary>
    /// 主场景
    /// </summary>
    public void StartMain()
    {
        SceneManager.LoadScene("Main");
    }

    #region 登录踢人、改密码踢人相关

    #endregion
}
