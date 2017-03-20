using cn.bmob.io;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginViewMediator : MonoBehaviour {
    public Button regBtn;
    public Button loginBtn;
    public InputField accountInput;
    public InputField passwordInptut;
	void Start () {
        regBtn.onClick.AddListener(delegate() {
            OnRegBtnClick();
        });
        loginBtn.onClick.AddListener(delegate()
        {
            OnLoginBtnClick();
        });
	}
    void OnRegBtnClick()
    {
        Debug.Log("OnRegBtnClick");
        Signup();
    }
    /// <summary>
    /// 如果程序需要为用户添加额外的字段，需要继承BmobUser
    /// 数据类，类似 litjson
    /// </summary>
    public class Login_BmobUser : BmobUser
    {
        public BmobInt life { get; set; }

        public BmobInt attack { get; set; }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("life", this.life);
            output.Put("attack", this.attack);
        }

        public override void readFields(BmobInput input)
        {
            base.readFields(input);

            this.life = input.getInt("life");
            this.attack = input.getInt("attack");
        }
    }
    ///注册
    /// <summary>
    /// 
    /// </summary>
    void Signup()
    {
        Login_BmobUser user = new Login_BmobUser();
        user.username = accountInput.text;
        user.password = passwordInptut.text;
        user.email = "support@bmob.cn";
        user.life = 0;
        user.attack = 0;

        GM.bmob.Signup<Login_BmobUser>(user, (resp, exception) =>
        {
            if (exception != null)
            {
                print("注册失败, 失败原因为： " + exception.Message);
                return;
            }
            print("注册成功");
        });
    }

    void OnLoginBtnClick()
    {
        Debug.Log("OnLoginBtnClick");
        Login();
    }
    /// <summary>
    /// 登录
    /// </summary>
    void Login()
    {
        GM.bmob.Login<Login_BmobUser>(accountInput.text, passwordInptut.text, (resp, exception) =>
        {
            if (exception != null)
            {
                print("登录失败, 失败原因为： " + exception.Message);
                return;
            }

            print("登录成功, @" + resp.username + "(" + resp.life + ")$[" + resp.sessionToken + "]");

            print("登录成功, 当前用户对象Session： " + BmobUser.CurrentUser.sessionToken);
        });
    }
}
