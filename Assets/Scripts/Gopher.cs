using System.Collections;
using UnityEngine;


public class Gopher : MonoBehaviour
{
    public GameObject beatenPrefab;

    private int _idx; // 当时生成的地鼠的索引 

    private GameControl _gameControl;
    
    
    
    private void Start()
    {
        _gameControl = FindFirstObjectByType<GameControl>();
    }

    public void Finish(int idx)
    {
        _idx = idx;
        StartCoroutine(nameof(DestroyLocalObject));
    }

    private IEnumerator DestroyLocalObject()
    {
        // 如果地鼠未被击中，则在3秒后销毁
        Destroy(gameObject, 3f);
        yield return new WaitForSeconds(2.95f);
        //print($"Gopher: idx = {_idx}");
        _gameControl.holes[_idx].IsAppear = false;
        _gameControl.count--;
    }

    private void OnMouseDown()
    {
        // 如果游戏结束，但是地鼠还在显示，则无法击打
        if (_gameControl.gameOver && _gameControl.holes[_idx].IsAppear)
            return;
        
        // 在相同位置生成一个被击打图像的地鼠
        GameObject beaten = Instantiate(beatenPrefab, gameObject.transform.position, Quaternion.identity);
        beaten.GetComponent<Beaten>().Finish(_idx);
        
        // 加1分
        _gameControl.score += 1;
        GameObject.Find("Score").GetComponent<TextMesh>().text = $"Score : {_gameControl.score}";
        
        // 0.1s后销毁当前生成的地鼠
        Destroy(gameObject, 0.1f);
    }
}
