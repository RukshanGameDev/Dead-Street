using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject GameOverMenu;
    public GameObject GamePauseMenu;
    public GameObject GameSettingMenu;

    [Header("Audio")]
    public AudioSource AudioSource;
    public AudioClip ButtonClick;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            GamePauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            AudioSource.PlayOneShot(ButtonClick);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        GamePauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioSource.PlayOneShot(ButtonClick);

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        AudioSource.PlayOneShot(ButtonClick);

    }

    public void GameStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        AudioSource.PlayOneShot(ButtonClick);

    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        AudioSource.PlayOneShot(ButtonClick);

    }
    public void SoundOn()
    {
        AudioListener.volume = 1f;
        AudioSource.PlayOneShot(ButtonClick);


    }
    public void SoundOff()
    {
        AudioListener.volume = 0f;
        AudioSource.PlayOneShot(ButtonClick);


    }
    public void CloseSetting()
    {
        GameSettingMenu.SetActive(false);
        AudioSource.PlayOneShot(ButtonClick);

    }
    public void OpenSetting()
    {
        GameSettingMenu.SetActive(true);
        AudioSource.PlayOneShot(ButtonClick);


    }
    public void GameExite()
    {
        Application.Quit();
        AudioSource.PlayOneShot(ButtonClick);

    }
    public void BackTolevelMap()
    {
        SceneManager.LoadScene(1);
        AudioSource.PlayOneShot(ButtonClick);

    }
}
