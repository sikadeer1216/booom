using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMController : MonoBehaviour
{
    //当前状态
    public abstract Enum CurrentState { get; set; }

    //当前状态的对象
    protected StateBase CurrStateObj;
    //存放全部对象-对象池
    private List<StateBase> stateList = new List<StateBase>();
    //修改状态
    public void ChangeState(Enum newState , bool reCurrState = false)
    {
        //如果新状态和当前状态一致
        if (newState == CurrentState && !reCurrState) return;
        //如果当前状态存在
        if (CurrStateObj != null) CurrStateObj.OnExit();

        //基于新状态的枚举，获得一个 新的状态对象
        CurrStateObj = GetStateObj(newState);
        CurrStateObj.OnEnter();
    }

    //获取状态对象
    //给一个枚举，返回一个和这个枚举同名的类型的对象

    private StateBase GetStateObj(Enum stateType)
    {
        for(int i = 0; i < stateList.Count; i++)
        {
            if (stateList[i].StateType == stateType) return stateList[i];
        }
        StateBase state = Activator.CreateInstance(Type.GetType(stateType.ToString())) as StateBase;
        state.Init(this,stateType);
        stateList.Add(state);
        return state;
    }
    protected virtual void Update()
    {
        if (CurrStateObj != null) CurrStateObj.OnUpdate();
    }
}
