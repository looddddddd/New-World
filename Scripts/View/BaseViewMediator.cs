﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseViewMediator : BaseMediator
{
    public Button[] btns;
    public Toggle[] togs;
    protected override void OnAwake()
    {
        base.OnAwake();
        AddBtnsListener();
        AddTogsListener();
        AddEventListener();
    }
    /// <summary>
    /// 添加按钮事件监听
    /// </summary>
    protected virtual void AddBtnsListener()
    {
        if (btns.Length == 0) return;
        for (int i = 0; i < btns.Length; i++)
        {
            if (btns[i] == null) continue;
            string btnName = btns[i].name;
            btns[i].onClick.AddListener(delegate()
            {
                OnBtnClick(btnName);
            });
        }
    }
    /// <summary>
    /// 添加开关事件监听
    /// </summary>
    protected virtual void AddTogsListener()
    {
        if (togs.Length == 0) return;
        for (int i = 0; i < togs.Length; i++)
        {
            if (togs[i] == null) continue;
            string togName = togs[i].name;
            togs[i].onValueChanged.AddListener(delegate(bool isChanged)
            {
                OnTogChanged(togName, isChanged);
            });
        }
    }
    /// <summary>
    /// 添加广播事件
    /// </summary>
    protected virtual void AddEventListener()
    {
        //NotiCenter.AddEventListener(KCEvent.KCItemChange, delegate(object data)
        //{

        //});    
    }
    protected virtual void OnBtnClick(string btnName) { }
    protected virtual void OnTogChanged(string togName, bool isChanged){ }
}
