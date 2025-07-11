using UnityEngine;

/// <summary>
/// 地鼠类
/// </summary>
public class Done_Gophers : MonoBehaviour {
    
    public GameObject beaten;
    
    public int id;

    /// <summary>
    /// 地鼠出现后，如果未被点击，将在三秒后自动销毁，将相应洞口的isAppear值设置为false
    /// </summary>
	void Update () {
        
        Destroy(this.gameObject,3.0f);
        FindObjectOfType<Done_GameControl>().holes[id].isAppear = false;
    }
   
    /// <summary>
    /// 鼠标点击
    /// </summary>
    void OnMouseDown() {
        Debug.Log("点击");

        //在相同的位置生成一个被击打图像的地鼠
        GameObject g;
        g = Instantiate(beaten, gameObject.transform.position, Quaternion.identity);
        g.GetComponent<Done_Beaten>().id = id;

        //增加分数
        FindObjectOfType<Done_GameControl>().score += 1;
        int scores = FindObjectOfType<Done_GameControl>().score;
        GameObject.Find("Score").gameObject.GetComponent<TextMesh>().text = "Score: " +scores.ToString();
        
        //FindObjectOfType<>().text = score.ToString();
        //GetComponentInChildren<TextMesh>().text = score.ToString();
        //scoreLabel.text = "Score: " + score; 

        //在0.1s后摧毁当前生成的地鼠
        Destroy(this.gameObject, 0.1f);
        
    }

    

}
