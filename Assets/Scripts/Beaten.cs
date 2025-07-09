using UnityEngine;

public class Beaten : MonoBehaviour
{
    // 在点击后0.35s后销毁该地鼠
    private void Update()
    {
        Destroy(gameObject, 0.35f);
    }
}
