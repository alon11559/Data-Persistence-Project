using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    
    class SaveData
    {
        public int HighScore;
        public string nameOfPlayer;

    }

    public static void SaveHighScore()
    {
        SaveData data = new SaveData();

        data.HighScore = MainManager.m_HighScore;
        data.nameOfPlayer = MainManager.nameOfPlayerWithHighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public static void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MainManager.m_HighScore = data.HighScore;
            MainManager.nameOfPlayerWithHighScore = data.nameOfPlayer;

        }
    }


}
