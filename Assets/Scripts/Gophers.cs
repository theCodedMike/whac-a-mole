using UnityEngine;

public class Gophers : MonoBehaviour
{
    public GameObject beaten;
    
    // Update is called once per frame
    private void Update()
    {
        // 如果地鼠未被击中，则在3秒后销毁
        Destroy(gameObject, 3f);
    }

    private void OnMouseDown()
    {
        // 在相同位置生成一个被击打图像的地鼠
        Instantiate(beaten, gameObject.transform.position, Quaternion.identity);
        // 0.1s后销毁当前生成的地鼠
        Destroy(gameObject, 0.1f);
    }
}
