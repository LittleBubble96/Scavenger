using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_MonoSingle_Destroy <T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance==null)
            {
                var single = FindObjectOfType<T>();
                if (single==null)
                {
                    GameObject obj = new GameObject {name = typeof(T).ToString()};
                    single = obj.AddComponent<T>();
                }
                _instance = single;
            }
            return _instance;
        }
    }
}