using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BaseController<T> where T : new ()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null) instance = new T();
            return instance;    
        }
    }
    string cloudLogic = "cloudLogic";
    protected void Request<T>(Dictionary<string,object> ps,Action<cn.bmob.response.EndPointCallbackData<T>,cn.bmob.exception.BmobException> cb)
    {
        GM.Instance.bmob.Endpoint<T>(cloudLogic, ps, (resp, exception) =>
        {
            if (exception != null)
            {
                Debug.Log("调用失败, 失败原因为： " + exception.Message);
                return;
            }
            cb(resp, exception);
        });
    }
}
