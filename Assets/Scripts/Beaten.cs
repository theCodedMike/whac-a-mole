using System.Collections;
using UnityEngine;

public class Beaten : MonoBehaviour
{
    private GameControl _gameControl;

    private int _idx; // 当时生成的地鼠的索引 
    
    
    
    private void Start()
    {
        _gameControl = FindFirstObjectByType<GameControl>();
    }

    // 在点击后0.35s后销毁该地鼠
    public void Finish(int idx)
    {
        _idx = idx;
        StartCoroutine(nameof(DestroyLocalObject));
    }

    private IEnumerator DestroyLocalObject()
    {
        Destroy(gameObject, 0.35f);
        yield return new WaitForSeconds(0.3f);
        //print($"Beaten: idx = {_idx}");
        _gameControl.holes[_idx].IsAppear = false;
        _gameControl.count--;
    }
}
