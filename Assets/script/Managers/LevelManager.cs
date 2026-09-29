using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level Buttons")]
    [SerializeField] private GameObject[] levelButtons;

    private SaveData saveData;

    void Start()
    {
        LoadLevelProgress();
    }

    void LoadLevelProgress()
    {
        saveData = SaveManager.instance.LoadLevel();

        // Initially lock all levels
        foreach (GameObject button in levelButtons)
        {
            button.SetActive(false);
        }

        // No save data: Unlock Level 1
        if (saveData == null)
        {
            Debug.Log("No saved data found");

            if (levelButtons.Length > 0)
                levelButtons[0].SetActive(true);

            return;
        }

        // Unlock completed levels + next level
        int unlockedLevel = saveData.Level;

        if (saveData.isCompleted)
        {
            unlockedLevel++;
        }

        // Activate unlocked level buttons
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < unlockedLevel)
            {
                levelButtons[i].SetActive(true);
            }
        }

        Debug.Log("Level progress loaded: " + unlockedLevel);
    }
}