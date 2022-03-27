using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//状态对象基类

public abstract class StateBase
{
    //当前状态对象代表的枚举状态
    public Enum StateType;

    //当前控制的角色
    public FSMController Controller;
    //首次实例化的初始化
    public virtual void Init(FSMController Controller , Enum stateType)
    {
        this.Controller = Controller;
        this.StateType = stateType;
    }

    //进入
    public abstract void OnEnter();
    //更新
    public abstract void OnUpdate();
    //退出
    public abstract void OnExit();
}
