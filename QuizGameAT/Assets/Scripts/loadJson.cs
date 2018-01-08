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
    public Text title = null;
    public Text question = null;
    public Text answer = null;
    public InputField answerInputField;
    public InputField questionInputField;
    private JsonData inputJsonData;
    public Canvas canvas;

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

            for (int i = 0; i < inputJsonData["allRoundData"].Count; i++)
            {
                Debug.Log(inputJsonData["allRoundData"][i]["name"]);
                answerInputField.text = inputJsonData["allRoundData"][i]["questions"][i]["answers"][i]["answerText"].ToString();
                questionInputField.text = inputJsonData["allRoundData"][i]["questions"][i]["questionText"].ToString();
            }

            title.text = inputJsonData["allRoundData"][0]["name"].ToString();
            question.text = inputJsonData["allRoundData"][0]["questions"][0]["questionText"].ToString();
            answer.text = inputJsonData["allRoundData"][0]["questions"][0]["answers"][0]["answerText"].ToString();
            answerInputField.text = inputJsonData["allRoundData"][0]["questions"][0]["answers"][0]["answerText"].ToString();
            questionInputField.text = inputJsonData["allRoundData"][0]["questions"][0]["questionText"].ToString();
            //answer.text = inputJsonData["allRoundData"][0]["questions"][0]["answers"][1]["answerText"].ToString();
            //answer.text = inputJsonData["allRoundData"][0]["questions"][0]["answers"][2]["answerText"].ToString();
            //answer.text = inputJsonData["allRoundData"][0]["questions"][0]["answers"][3]["answerText"].ToString();
            //answer.enabled = false;

            /*https://gamedev.stackexchange.com/questions/116177/how-to-dynamically-create-an-ui-text-object-in-unity-5
             * dinamicki kreiranje button-a
             * GameObject UItextGO = new GameObject("Test");
            UItextGO.transform.SetParent(canvas.transform, false);

            RectTransform trans = UItextGO.AddComponent<RectTransform>();
            //trans.anchoredPosition = new Vector2(x, y);

            Text test = UItextGO.AddComponent<Text>();
            test.color = new Color(0f, 0f, 0f);
            test.font = new Font("Arial");
            test.fontStyle = FontStyle.Bold;
            test.enabled = true;
            test.text = "test";*/

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
