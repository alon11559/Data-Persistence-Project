using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{

    public Text inputName;
    public static string nameOfPlayer;


    // Start is called before the first frame update
    public void StartGame()
    {
        nameOfPlayer = inputName.text.ToString();
        MenuManager.LoadHighScore();
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit;
#endif
    }

}
