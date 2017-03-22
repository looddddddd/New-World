using cn.bmob.io;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using LitJson;
using SimpleJson;
/// <summary>
/// 用户中心
/// </summary>
public class UserCenterController : BaseController<UserCenterController>
{
    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="accout"></param>
    /// <param name="password"></param>
    public void Singup(UserCenter user)
    {
        Request<UserCenter>(Parameters.GetParameteres(KCEvent.Singup, user), (data) =>
        {
            if (isSuccess(data.code)) 
            {
                NotiCenter.Instance.DispatchEvent(KCEvent.Singup, data);
                return;
            }
            Debug.Log("注册失败,失败原因。 code：" + data.code + "  error：" + data.error);
        });
    }
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="accout"></param>
    /// <param name="password"></param>
    public void Login(UserCenter user)
    {
        Request<UserCenter>(Parameters.GetParameteres(KCEvent.Login, user), (data) =>
        {
            if (isSuccess(data.code)) 
            {
                NotiCenter.Instance.DispatchEvent(KCEvent.Login, data);
                return;
            }
            Debug.Log("登录失败,失败原因。 code：" + data.code + "  error：" + data.error);
        });
    }
}
