using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel01()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel02()
    {
        SceneManager.LoadScene(3);

    }
    public void LoadLevel03()
    {

    }
    public void LoadLevel04()
    {

    }
    public void LoadLevel05()
    {

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);

    }

}
