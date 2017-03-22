using cn.bmob.io;
/// <summary>
/// 异常类
/// </summary>
public class Exception : BmobTable
{
    /// <summary>
    /// 错误码
    /// </summary>
    public int code { get; set; }
    /// <summary>
    /// 错误信息
    /// </summary>
    public string error { get; set; }
}
