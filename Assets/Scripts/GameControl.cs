using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject gopher;

    private void Start()
    {
        Instantiate(gopher, new Vector3(0, 0 + 0.4f, -0.1f), Quaternion.identity);
    }
}
