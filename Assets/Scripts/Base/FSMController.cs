using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMController<T> : MonoBehaviour
{
    //当前状态
    public T CurrentState;

    //当前状态的对象
    protected StateBase<T> CurrStateObj;
    //存放全部对象-对象池
    private Dictionary<T,StateBase<T>> stateDic = new Dictionary<T, StateBase<T>>();
    //修改状态


    public void ChangeState<K>(T newState , bool reCurrState = false) where K:StateBase<T>, new()
    {
        //如果新状态和当前状态一致
        if (newState.Equals(CurrentState) && !reCurrState) return;
        //如果当前状态存在
        if (CurrStateObj != null) CurrStateObj.OnExit();

        //基于新状态的枚举，获得一个 新的状态对象
        CurrStateObj = GetStateObj<K>(newState);
        CurrStateObj.OnEnter();
    }

    //获取状态对象
    //给一个枚举，返回一个和这个枚举同名的类型的对象

    private StateBase<T> GetStateObj<K>(T stateType) where K : StateBase<T>, new()
    {
        if (stateDic.ContainsKey(stateType))
        {
            return stateDic[stateType];
        }

        StateBase<T> state = new K();
        state.Init(this,stateType);
        stateDic.Add(stateType, state);
        return state;
    }
    protected virtual void Update()
    {
        if (CurrStateObj != null) CurrStateObj.OnUpdate();
    }
}
