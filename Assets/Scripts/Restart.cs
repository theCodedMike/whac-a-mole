using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void OnMouseDown()
    {
        print("Restart...");
        SceneManager.LoadScene("Game");
    }
}
