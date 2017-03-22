using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cn.bmob.io;
/// <summary>
/// 如果程序需要为用户添加额外的字段，需要继承BmobUser
/// </summary>
public class UserCenter : BmobUser
{
    /// <summary>
    /// 错误码
    /// </summary>
    public int code { get; set; }
    /// <summary>
    /// 错误信息
    /// </summary>
    public string error { get; set; }


    #region 如果程序需要为用户添加额外的字段，需要继承BmobUser

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
        this.attack = input.getInt("attack"); //error
    }

    #endregion
}