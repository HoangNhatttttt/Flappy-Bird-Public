using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public int highScore;
}

public class GameSaveManager : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "save.sav");
        Debug.Log("Save file path: " + savePath);
    }

    public void ResetHighScore()
    {
        SaveHighScore(0);
    }

    public void SaveHighScore(int score)
    {
        SaveData data = new SaveData { highScore = score };
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream(savePath, FileMode.Create))
        {
            bf.Serialize(fs, data);
        }
        Debug.Log("Save new highscore");
    }

    public int LoadHighScore() {
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(savePath, FileMode.Open))
            {
                SaveData data = (SaveData)bf.Deserialize(fs);
                Debug.Log("Load highscore success: " + data.highScore);
                return data.highScore;
            }
        }
        Debug.Log("Load highscore fail, return 0.");
        return 0;
    }
}
