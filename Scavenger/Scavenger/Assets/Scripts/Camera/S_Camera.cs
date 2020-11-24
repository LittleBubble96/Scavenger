using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class S_Camera : Bubble_MonoSingle_Destroy<S_Camera>
{
    [Bubble_Name("距离")] public float distance;
    [Bubble_Name("旋转速度")] public float changeTime = 0.3f;
    
    /// <summary>
    /// 目标
    /// </summary>
    private Transform target;

    private Vector3 initDir;

    private float cuHorAngle, curVerAngle;

    #region 改变旋转位移参数

    private float tempChangeTime;
    private Vector3 startPos,endPos;
    private Quaternion startRot, endRot;
    #endregion

    public void Init()
    {
        
    }

    public void DoLateUpdate()
    {
        CheckMouse();
    }

    #region 接口
    /// <summary>
    /// 设置目标
    /// </summary>
    public void SetTarget(Transform target)
    {
        this.target = target;
        initDir = target.forward * -1;
        cuHorAngle = 0;
        curVerAngle = 0;
    }

    /// <summary>
    /// 直接改变位置
    /// </summary>
    public void SetTransformImmediately(Transform point)
    {
        SetTransformImmediately(point.position);
    }
    
    public void SetTransformImmediately(Vector3 pos)
    {
        transform.position = pos;
    }
    
    /// <summary>
    /// Lerp改变位置
    /// </summary>
    public void SetTransformFade(Transform point)
    {
        SetTransformFade(point.position);
    }
    
    public void SetTransformFade(Vector3 pos)
    {
        changeTime = tempChangeTime;
        startPos = transform.position;
        endPos = pos;
    }
    #endregion

    /// <summary>
    /// 检测鼠标
    /// </summary>
    private void CheckMouse()
    {
        
    }

    /// <summary>
    /// 计算位置
    /// </summary>
    /// <param name="horAngle"></param>
    /// <param name="verAngle"></param>
    private Vector3 CalculatePos(float horAngle,float verAngle)
    {
        var x = Mathf.Sin(horAngle * Mathf.Deg2Rad) * distance;
        var z = Mathf.Cos(horAngle * Mathf.Deg2Rad) * distance * -1;
        var y = Mathf.Sin(verAngle * Mathf.Deg2Rad) * distance;
        Vector3 p = new Vector3(x, y, z);
        float angle = Vector3.Angle(initDir, Vector3.back);
        Vector3 value = Quaternion.AngleAxis(angle, Vector3.up) * p;
        DDebug.Log("value：" + value);
        return value;
    }



}
