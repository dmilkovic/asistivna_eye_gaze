using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using LitJson;

//https://www.youtube.com/watch?v=OyQQ-7-22Hw
//https://www.youtube.com/watch?v=JIzMUQBIDgM

public class loadJson : MonoBehaviour {

    public GameData gameData;
    private string gameDataProjectFilePath = "/StreamingAssets/data.json";
    public Text question = null;
    public Text answer = null;
    private JsonData inputJsonData;

    // Use this for initialization
    void Start()
    {
        Debug.Log("start"); //zasto duplo??

        SerializedObject serializedObject = new SerializedObject(this);
        SerializedProperty serializedProperty = serializedObject.FindProperty("gameData");
        serializedObject.ApplyModifiedProperties();

        string filePath = Application.dataPath + gameDataProjectFilePath;

        if (File.Exists(filePath))
        {

            string dataAsJson = File.ReadAllText(filePath);
            inputJsonData = JsonMapper.ToObject(dataAsJson);

            for (int i = 0; i < inputJsonData["allRoundData"].Count; i++) {
                Debug.Log(inputJsonData["allRoundData"][i]["name"]);
            }

            question.text = inputJsonData["allRoundData"][0]["name"].ToString();
            answer.text = inputJsonData["allRoundData"][1]["name"].ToString();

        }
        else
        {
            gameData = new GameData();
        }



    }

    // Update is called once per frame
    void Update()
    {
      

    }

    /*void OnGUI()
    {
        question.text = myText;

    }*/


/*public GameData gameData;
private string gameDataProjectFilePath = "/StreamingAssets/data.json";

// Use this for initialization
void Start () {

}

// Update is called once per frame
void Update () {

}

void OnGUI()
{
    if (gameData != null)
    {
        SerializedObject serializedObject = new SerializedObject(this);
        SerializedProperty serializedProperty = serializedObject.FindProperty("gameData");

        EditorGUILayout.PropertyField(serializedProperty, true);
        //TODO: trebalo bi ovako mozda https://docs.unity3d.com/Manual/gui-Layout.html

        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Save data"))
        {
            SaveGameData();
        }
    }

    if (GUILayout.Button("Load data"))
    {
        LoadGameData();
    }
}

public void LoadGameData()
{
    string filePath = Application.dataPath + gameDataProjectFilePath;

    if (File.Exists(filePath))
    {
        string dataAsJson = File.ReadAllText(filePath);

        gameData = JsonUtility.FromJson<GameData>(dataAsJson);
    }
    else
    {
        gameData = new GameData();
    }
}

private void SaveGameData()
{
    string dataAsJson = JsonUtility.ToJson(gameData);

    string filePath = Application.dataPath + gameDataProjectFilePath;
    File.WriteAllText(filePath, dataAsJson);
}*/
}
