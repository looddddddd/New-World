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
    string cloudLogic = "cloudLogicTest";
    /// <summary>
    /// 是否打印输出
    /// </summary>
    bool isDebug = true;
    /// <summary>
    /// 请求数据
    /// </summary>
    /// <typeparam name="TBmobTable">表的数据类</typeparam>
    /// <param name="ps">请求的参数</param>
    /// <param name="cb">完成请求的回调</param>
    protected void Request<TBmobTable>(Dictionary<string, object> ps, Action<TBmobTable> cb)
    {
        GM.Instance.bmob.Endpoint<JsonObject>(cloudLogic, ps, (resp, exception) =>
        {
            //网络异常检测
            if (exception != null)
            {
                Debug.Log("调用失败, 失败原因为： " + exception.Message); // 没有网络时返回的信息   --   调用失败, 失败原因为： Could not resolve host: api.bmob.cn, and response content is 
                return;
            }
            //打印数据
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
            //数据异常检测-code,error
            Exception err = SimpleJson.SimpleJson.DeserializeObject<Exception>(resp.data.ToString());
            if (err.code != 0 && !String.IsNullOrEmpty(err.error))//Bmob官方定义的数据异常
            {
                Debug.Log("请求失败, 失败原因为： " + err.error);
                return;
            }
            if (!String.IsNullOrEmpty(err.message))//发送自定义消息
            {
                HandleMessageEvent(err.message);
                return;
            }
            cb(SimpleJson.SimpleJson.DeserializeObject<TBmobTable>(resp.data.ToString()));
        });
    }
    /// <summary>
    /// 处理消息事件
    /// </summary>
    void HandleMessageEvent(string message)
    {
        switch (message)
        {
            case "User_Not_Login"://账号在其他地方登陆
                //退回主界面
                break;
            case "User_PassWord_Invalid"://密码失效
                //退回主界面
                break;
            default:

                break;
        }
        Debug.Log("收到一条新的消息:" + message);
    }
}
