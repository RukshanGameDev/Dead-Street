using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepObject : MonoBehaviour
{
    private void Awake()
    {

        DontDestroyOnLoad(gameObject);

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
    }
}