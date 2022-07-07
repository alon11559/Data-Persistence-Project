using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public static int HighScore;

     

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
        HighScore = MainManager.m_HighScore;
        DontDestroyOnLoad(gameObject);

    }



    [System.Serializable]
    
    class SaveData
    {
        public int HighScore;
    }

    public static void SaveHighScore()
    {
        SaveData data = new SaveData();

        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);


         int timesWrittenToJson = 0;
        Debug.Log(timesWrittenToJson);
        timesWrittenToJson++;
        Debug.Log(timesWrittenToJson);
    }

    public static void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
        }
    }


}
