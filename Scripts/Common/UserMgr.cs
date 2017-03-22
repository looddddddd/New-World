using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 登录踢人、改密码踢人相关
/// </summary>
public class UserMgr : Singleton<UserMgr> 
{
    /// <summary>
    /// 是否主动登录
    /// </summary>
    static bool isInitiativeLogin = false;
    /// <summary>
    /// 是否打开应用
    /// </summary>
    static bool isOpenApp = false;
    /// <summary>
    /// 用户信息是否变换
    /// </summary>
    static bool isChangeUserInfo = false;
    /// <summary>
    /// installationId是否改变
    /// </summary>
    static bool isChangeInstallationId = false;
    /// <summary>
    /// 账户
    /// </summary>
    static string username = "username";
    /// <summary>
    /// 密码
    /// </summary>
    static string password = "password";
    /// <summary>
    /// 用户的objectId
    /// </summary>
    static string objectId = "objectId";
    /// <summary>
    /// 当前用户的installationId
    /// </summary>
    static string currentUserInstallationId = "currentUserInstallationId";
    /// <summary>
    /// 检查是否-登录踢人、改密码踢人
    /// </summary>
    public static void Main()
    { 
        if(isInitiativeLogin)
        {
            if (InitiativeLoginSuccess(username, password, "获取本地设备id")) 
            {
                LocalStoreEncryption(username, password);
                ListenerUserInfo(objectId);
            }
        }
        if (isOpenApp) 
        {
            if (Logined() != null)
            {
                if (BackgroundLogin(username))
                {
                    if (ComparisonInstallationId("获取本地设备id", currentUserInstallationId))
                    {
                        ListenerUserInfo(objectId);
                    }
                    else 
                    {
                        LogOut("该账号在别处登录了");
                    }
                }
                else 
                {
                    LogOut("该账号的密码被修改了");
                }
            }
        }
    }
    /// <summary>
    /// 主动登录成功
    /// </summary>
    /// <param name="username">账户</param>
    /// <param name="password">密码</param>
    /// <param name="equipmentId">设备id</param>
    /// <returns></returns>
    public static bool InitiativeLoginSuccess(string username, string password, string equipmentId)
    {
        return true;
    }
    /// <summary>
    /// 本地加密保存
    /// </summary>
    /// <param name="username">账户</param>
    /// <param name="password">密码</param>
    /// <returns></returns>
    public static bool LocalStoreEncryption(string username, string password)
    {
        return true;
    }
    /// <summary>
    /// 已登录用户
    /// </summary>
    /// <returns></returns>
    public static string Logined()
    {
        return "";
    }
    /// <summary>
    /// 利用本地保存的密码悄悄后台登录-(一键登录,快速登录)
    /// </summary>
    /// <param name="username">账户</param>
    /// <returns></returns>
    public static bool BackgroundLogin(string username)
    {
        return true;
    }
    /// <summary>
    /// 获取本地installationId
    /// </summary>
    /// <returns></returns>
    public static string GetInstallationId()
    {
        return "";
    }
    /// <summary>
    /// 退出登录
    /// </summary>
    /// <param name="msg">原因</param>
    /// <returns></returns>
    public static string LogOut(string msg)
    {
        return "";
    }
    /// <summary>
    /// 开始监听_User表
    /// </summary>
    /// <param name="objectId"></param>
    public static void ListenerUserInfo(string objectId)
    { 
        
    }
    /// <summary>
    /// 对比installationId是否相同
    /// </summary>
    /// <param name="equipmentId">设备id</param>
    /// <param name="ServerInstallationId">数据库的installationId</param>
    /// <returns></returns>
    public static bool ComparisonInstallationId(string equipmentId, string ServerInstallationId)
    {
        return true;
    }
}
