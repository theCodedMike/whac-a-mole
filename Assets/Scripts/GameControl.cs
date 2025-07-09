using UnityEngine;
using Random = UnityEngine.Random;


public class GameControl : MonoBehaviour
{
    public GameObject gopherPrefab;
    // 记录地鼠的x, y坐标
    public int posX, posY;
    
    public Hole[] holes;


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

    // 生成地鼠
    public void Spawn()
    {
        int i = Random.Range(0, 9);
        while (holes[i].IsAppear)
            i = Random.Range(0, 9);
        
        print($"{holes[i].HoleX}, {holes[i].HoleY}");
        GameObject gopher = Instantiate(gopherPrefab, new Vector3(holes[i].HoleX, holes[i].HoleY + 0.4f, -0.1f), Quaternion.identity);
        gopher.GetComponent<Gopher>().idx = i;
        
        holes[i].IsAppear = true;
    }

    // 
    public void SpawnMany()
    {
        InvokeRepeating(nameof(Spawn), 0, 1);
    }
}

// 地洞类，存储地洞的坐标以及是否出现
public class Hole
{
    public bool IsAppear; // 是否出现
    public int HoleX;
    public int HoleY;
}