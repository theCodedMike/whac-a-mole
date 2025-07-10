using UnityEngine;
using Random = UnityEngine.Random;


public class GameControl : MonoBehaviour
{
    public GameObject gopherPrefab;
    
    public Hole[] holes;
    // 计时器标签
    public TextMesh timeLabel;
    // 时间
    public float time = 30f;
    // 分数
    [HideInInspector]
    public int score = 0;
    [HideInInspector]
    public bool gameOver;
    // 地鼠的个数
    [HideInInspector]
    public int count = 0;
    // 记录地鼠的x, y坐标
    private int posX, posY;
    
    
    
    private void Awake()
    {
        posX = -2;
        posY = -2;
        holes = new Hole[9];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int idx = i * 3 + j;
                holes[idx] = new Hole()
                {
                    HoleX = posX,
                    HoleY = posY,
                    IsAppear = false
                };
                posY++;
            }

            posY = -2;
            posX += 2;
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnMany), 0,  10);
        //Spawn();
    }

    // 生成一只地鼠
    // 有点小问题，如果生成地鼠的频率变快以后，容易导致程序崩溃，原因未知
    public void Spawn()
    {
        print($"生成地鼠... {count}");
        // 如果所有的洞中都有地鼠，则不再生成
        if (count >= holes.Length)
            return;
        
        int i = Random.Range(0, 9);
        while (holes[i].IsAppear)
        {
            if (count >= holes.Length)
                return;
            i = Random.Range(0, 9);
        }
        
        //print($"{i}: {holes[i].HoleX}, {holes[i].HoleY}");
        GameObject gopher = Instantiate(gopherPrefab, new Vector3(holes[i].HoleX, holes[i].HoleY + 0.4f, -0.1f), Quaternion.identity);
        count++;
        gopher.GetComponent<Gopher>().Finish(i);
        
        holes[i].IsAppear = true;
    }

    // 生成许多地鼠
    public void SpawnMany()
    {
        InvokeRepeating(nameof(Spawn), 0, 1);
    }

    private void Update()
    {
        if (gameOver)
            return;
        
        time -= Time.deltaTime;
        timeLabel.text = $"Time : {time:F1}";
        
        if(time <= 0)
            GameOver();
    }


    private void GameOver()
    {
        time = 0;
        timeLabel.text = $"Time : 0";
        
        // 将所有延时调用函数取消
        CancelInvoke();
        gameOver = true;
        
        print("游戏结束...");
    }

    /*private string HolesToString()
    {
        StringBuilder sb = new StringBuilder(holes.Length);
        foreach (Hole hole in holes)
        {
            sb.Append(hole);
            sb.Append(", ");
        }
        return sb.ToString();
    }*/
}

// 地洞类，存储地洞的坐标以及是否出现
public class Hole
{
    public bool IsAppear; // 是否出现
    public int HoleX;
    public int HoleY;

    public override string ToString()
    {
        return $"({HoleX}, {HoleY}, {IsAppear})";
    }
}