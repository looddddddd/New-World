using cn.bmob.io;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 用户中心
/// </summary>
public class UserCenterController : Singleton<UserCenterController>
{
    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="accout"></param>
    /// <param name="password"></param>
    public void Singup(UserCenter user)
    {
        GM.Instance.bmob.Signup<UserCenter>(user, (resp, exception) =>
        {
            if (exception != null)
            {
                Debug.Log("注册失败, 失败原因为： " + exception.Message);
                return;
            }

            NotiCenter.Instance.DispatchEvent(KCEvent.Singup, resp);
        });
    }
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="accout"></param>
    /// <param name="password"></param>
    public void Login(string accout,string password)
    {
        GM.Instance.bmob.Login<UserCenter>(accout, password, (resp, exception) =>
        {
            if (exception != null)
            {
                Debug.Log("登录失败, 失败原因为： " + exception.Message);
                return;
            }
            Debug.Log("登录成功, @" + resp.username + "(" + resp.life + ")$[" + resp.sessionToken + "]");
            Debug.Log("登录成功, 当前用户对象Session： " + BmobUser.CurrentUser.sessionToken);

            NotiCenter.Instance.DispatchEvent(KCEvent.Login, resp);
        });
    }
}
