using cn.bmob.io;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using SimpleJson;
//using JsonObject = SimpleJson.JsonObject;
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
        Request<object>(Parameters.GetParameteres(KCEvent.Singup, user), (resp, exception) =>
        {
            //resp.data; {"result":{"code":202,"error":"username '22' already taken."}}
            //{"result":{"createdAt":"2017-03-22 00:34:38","objectId":"1f919a0193","sessionToken":"3c17691740c62771802548a725e1e233"}}
            //SimpleJson.JsonObject
            //JsonObject jso = SimpleJson.SimpleJson.DeserializeObject("{}") as JsonObject;
            Debug.Log("返回对象为： " + resp);
            Debug.Log(resp.data.GetType());//SimpleJson.JsonObject
            cn.bmob.response.EndPointCallbackData<object> u = resp;
            string jd = JsonMapper.ToJson(resp.data);
            Debug.Log(jd);
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
    public void Test()
    {
        Dictionary<string, object> p = new Dictionary<string, object>();
        p.Add("objectId","tAgSRRRY");
        GM.Instance.bmob.Endpoint<Hashtable>("test",(resp, exception) => 
        {
            Debug.Log("Test");
            if (exception != null)
            {
                Debug.Log("调用失败, 失败原因为： " + exception.Message);
                return;
            }

            Debug.Log("返回对象为： " + resp);
        });
    }
}
