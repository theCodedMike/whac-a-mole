using UnityEngine;
using UnityEditor.SceneManagement;

/// <summary>
/// 重新开始函数
/// </summary>
public class Done_Restart : MonoBehaviour {
    /// <summary>
    /// 按钮被点击以后，重新调用游戏场景
    /// </summary>
    public void OnMouseDown() {
        Debug.Log("restart");
        EditorSceneManager.LoadScene("Done_mole");
    }
}
