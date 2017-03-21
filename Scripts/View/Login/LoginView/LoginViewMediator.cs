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
            UserCenter user = (UserCenter)data;
            Debug.Log("注册成功:username:" + user.username);
        });
        NotiCenter.Instance.AddEventListener(KCEvent.Login, delegate(object data)
        {
            UserCenter user = (UserCenter)data;
            Debug.Log("登录成功:life:" + user.life);
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
        if (account.Length <= 0) return;
        if (password.Length <= 0) return;

        UserCenter user = new UserCenter();
        user.username = account;
        user.password = password;
        user.life = 10;
        user.attack = 20;
        UserCenterController.Instance.Singup(user);
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

        UserCenterController.Instance.Login(account, password);
    }
}
