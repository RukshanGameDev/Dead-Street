
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    private bool hasSaved = false;
    public GameObject LevelPassPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (hasSaved)
        {
            return;
        }
        if (other.CompareTag("Player")&& InventoryManager.Instance.CheckInventory())
        {
            SaveGame();
            LevelPassPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;

        }
    }

    private void SaveGame()
    {
        int CurrentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        SaveData data = new SaveData();
        data.Level = CurrentLevel;
        data.isCompleted = true;
        SaveManager.instance.saveLevel(data);
        hasSaved = true;
        Debug.Log("checck point reached ,game saved");
    }
}
