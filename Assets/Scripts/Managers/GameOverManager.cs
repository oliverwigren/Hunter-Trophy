using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Start");
    }

}
