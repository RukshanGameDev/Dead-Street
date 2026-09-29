using System.IO;

using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private string SavePath;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SavePath = Application.persistentDataPath + "/save.json";
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log(Application.persistentDataPath);
    }


    public void saveLevel(SaveData state)
    {


        string jason = JsonUtility.ToJson(state, true);
        Debug.Log(jason);
        File.WriteAllText(SavePath, jason);
        Debug.Log("game saves" + jason);
    }



    public SaveData LoadLevel()
    {
        if (!File.Exists(SavePath))
        {
            Debug.LogWarning("save file not found");
            return null;
        }

        string json = File.ReadAllText(SavePath);
        return JsonUtility.FromJson<SaveData>(json);
    }

}
