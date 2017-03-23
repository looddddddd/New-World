using cn.bmob.io;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginViewMediator : BaseViewMediator {
    public InputField accountInput;
    public InputField passwordInptut;
    protected override void OnBtnClick(string btnName)
    {
        base.OnBtnClick(btnName);
        switch (btnName)
        {
            case "SignupBtn"://注册按钮
                Signup();
                break;
            case "LoginBtn"://登录按钮
                Login();
                break;
        }
    }
    protected override void AddEventListener()
    {
        base.AddEventListener();
        NotiCenter.Instance.AddEventListener(KCEvent.Singup, delegate(object data) 
        {
            BmobUser user = (BmobUser)data;
            Debug.Log("注册成功:username:" + user.username);
        });
        NotiCenter.Instance.AddEventListener(KCEvent.Login, delegate(object data)
        {
            BmobUser user = (BmobUser)data;
            Debug.Log("登录成功:username:" + user.username);
        });
    }
    ///注册
    /// <summary>
    /// 
    /// </summary>
    void Signup()
    {
        string account = accountInput.text;
        string password = passwordInptut.text;
        string email = "448020164@qq.com";
        if (account.Length <= 0) return;
        if (password.Length <= 0) return;

        BmobUser user = new BmobUser();
        user.username = account;
        user.password = password;
        user.email = email;
        UserCenterController.Instance.UserCenter(user,KCEvent.Singup);
    }
    /// <summary>
    /// 登录
    /// </summary>
    void Login()
    {
        string account = accountInput.text;
        string password = passwordInptut.text;
        if (account.Length <= 0) return;
        if (password.Length <= 0) return;

        BmobUser user = new BmobUser();
        //TestTable user = new TestTable();
        user.username = account;
        user.password = password;
        //user.installationId = "545";
        UserCenterController.Instance.UserCenter(user, KCEvent.TODO1);
    }
    /// <summary>
    /// 重置密码
    /// </summary>
    void RestPassword()
    {
        string email = "448020164@qq.com";
        if (email.Length <= 0) return;

        BmobUser user = new BmobUser();
        user.email = email;
        UserCenterController.Instance.UserCenter(user, KCEvent.RestPassword);
    }
    /// <summary>
    /// 邮箱验证
    /// </summary>
    void EmailVerify()
    {
        string email = "448020164@qq.com";
        if (email.Length <= 0) return;

        BmobUser user = new BmobUser();
        user.email = email;
        UserCenterController.Instance.UserCenter(user, KCEvent.EmailVerify);
    }
}
public class TestTable : BmobUser
{
    public string installationId { get; set; }
}
