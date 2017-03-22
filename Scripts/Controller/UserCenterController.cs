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
    /// 用户中心
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="table">表数据类</param>
    /// <param name="_KCEvent">触发的事件</param>
    public void UserCenter<T>(T table, KCEvent _KCEvent)
    {
        Request<T>(Parameters.GetParameteres(_KCEvent, table), (data) =>
        {
            NotiCenter.Instance.DispatchEvent(_KCEvent, data);
        });
    }
}
