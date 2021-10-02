using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHundler : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;
    public InputField NameInputField;
   public string Name;
   public int Score;
   public string OldName;
   public int OldScore;
    public static UIHundler hundler;
    private void Awake()
    {
       if (hundler != null)
        {
            Destroy(gameObject);
            return;
        }


        hundler = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class saveable
    {
        public string name;
        public int Score;
        public string OldName;
        public int OldScore;
    }
    

    private void Start()
    {
        Load();
        BestScoreText.text = $"Best Score :{hundler.OldName}: {hundler.OldScore}";
    }
    public void LoadSceneWithName(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void LoadSceneWithNumber(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
    public void MainScene()
    {
        Name = NameInputField.text;
        gameObject.SetActive(false);
        LoadSceneWithName("main");
    }

 public   void Exit()
    {
       // Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
   Application.Quit();

#endif

    }
  public void Save()
    {
        if (hundler.Score > hundler.OldScore)
        {   saveable saveables = new saveable();
            saveables.OldScore = hundler.Score;
            saveables.OldName = hundler.Name;
            string json = JsonUtility.ToJson(saveables);
            File.WriteAllText(Application.persistentDataPath + "/Save_score.json", json);
            Debug.Log(Application.persistentDataPath + "/Save_score.json");


        }

    }
   public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/Save_score.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/Save_score.json");

         saveable saveables= JsonUtility.FromJson<saveable>(json);
            hundler.OldName = saveables.OldName;
           hundler.OldScore = saveables.OldScore;
            Debug.Log(saveables.OldScore+saveables.OldName);
        }
    }
    
}
