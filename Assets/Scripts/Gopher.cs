using UnityEngine;

public class Gopher : MonoBehaviour
{
    public GameObject beatenPrefab;

    public int idx; // 当时生成的地鼠的索引 

    private GameControl _gameControl;
    
    private void Start()
    {
        _gameControl = FindFirstObjectByType<GameControl>();
    }

    // Update is called once per frame
    private void Update()
    {
        // 如果地鼠未被击中，则在3秒后销毁
        Destroy(gameObject, 3f);
        _gameControl.holes[idx].IsAppear = false;
    }

    private void OnMouseDown()
    {
        // 在相同位置生成一个被击打图像的地鼠
        GameObject beaten = Instantiate(beatenPrefab, gameObject.transform.position, Quaternion.identity);
        beaten.GetComponent<Beaten>().idx = idx;

        // 加1分
        _gameControl.score += 1;
        GameObject.Find("Score").GetComponent<TextMesh>().text = $"Score : {_gameControl.score}";
        
        // 0.1s后销毁当前生成的地鼠
        Destroy(gameObject, 0.1f);
    }
}
