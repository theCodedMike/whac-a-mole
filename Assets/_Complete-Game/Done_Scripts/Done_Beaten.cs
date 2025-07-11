using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地鼠被击打以后调用该函数
/// </summary>
public class Done_Beaten : MonoBehaviour {

    public int id;
    /// <summary>
    /// 在点击后3.5s销毁该地鼠，将洞口的isAppear值设置为false
    /// </summary>
    void Update () {
        Destroy(gameObject, 0.35f);
        FindObjectOfType<Done_GameControl>().holes[id].isAppear = false;
    }
}
