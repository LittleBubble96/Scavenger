using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class S_GameManager :Bubble_MonoSingle<S_GameManager>
{
    /// <summary>
    /// 日常单例类封装
    /// </summary>
    private static List<S_MonoInstanceBase> _monoInstanceBases = new List<S_MonoInstanceBase>();
    
    void Awake()
    {
        BubbleFrameEntry.Awake();
        _monoInstanceBases = FindObjectsOfType<S_MonoInstanceBase>().ToList();
        foreach (var monoInstance in _monoInstanceBases)
        {
            monoInstance.Init();
        }
    }

    void Update()
    {
        BubbleFrameEntry.Update();
        
        foreach (var monoInstance in _monoInstanceBases)
        {
            monoInstance.DoUpdate(Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        foreach (var monoInstance in _monoInstanceBases)
        {
            monoInstance.DoLateUpdate();
        }
    }

    /// <summary>
    /// 获取单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetInstance<T>() where T : S_MonoInstanceBase
    {
        foreach (var mono in _monoInstanceBases)
        {
            if (typeof(T) == mono.GetType())
            {
                return mono as T;
            }
        }
        GameObject instance = new GameObject(typeof(T).ToString());
        var value = instance.AddComponent<T>();
        _monoInstanceBases.Add(value);
        return value;
    }
    
    
}
