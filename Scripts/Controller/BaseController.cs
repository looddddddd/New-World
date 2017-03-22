using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJson;
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
    /// <summary>
    /// 云端逻辑方法名
    /// </summary>
    string cloudLogic = "cloudLogic";
    /// <summary>
    /// 是否打印输出
    /// </summary>
    bool isDebug = true;
    protected void Request<TBmobTable>(Dictionary<string, object> ps, Action<TBmobTable> cb)
    {
        GM.Instance.bmob.Endpoint<JsonObject>(cloudLogic, ps, (resp, exception) =>
        {
            if (exception != null)
            {
                Debug.Log("调用失败, 失败原因为： " + exception.Message); // 没有网络时返回的信息   --   调用失败, 失败原因为： Could not resolve host: api.bmob.cn, and response content is 
                return;
            }
            if (isDebug)
            {
                Parameters parameters = ps[Parameters.parameters] as Parameters;
                Debug.Log("开始打印云端逻辑返回数据:" + parameters.KCEvent);
                foreach (string key in resp.data.Keys)
                {
                    Debug.Log("key:" + key);
                    Debug.Log("value:" + resp.data[key] + ",type:" + resp.data[key].GetType());
                }
                Debug.Log("结束打印云端逻辑返回数据:" + parameters.KCEvent);
            }

            TBmobTable data = SimpleJson.SimpleJson.DeserializeObject<TBmobTable>(resp.data.ToString());//TODO -- 登录的时候报错 failed to convert parameters
            cb(data);
        });
    }
    /// <summary>
    /// 是否请求成功
    /// </summary>
    /// <param name="code">0 - 代表请求成功</param>
    /// <param name="error">"" - 空代表请求成功</param>
    /// <returns></returns>
    protected bool isSuccess(int code, string error = "")
    {
        if (code == 0 && error == "") return true;
        return false;
    }
}
