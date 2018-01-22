using UnityEngine;
using UnityEngine.SceneManagement;
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
    private string dataAsJson, filePath;
    public InputField answerInputField;
    public InputField questionInputField;
    private JsonData inputJsonData;
    public Canvas canvas;
    public GameObject initialsObject;
    private int QuestionIndex = 0;
    public InputField inputFieldCo, inputFieldAa, inputFieldBb, inputFieldCc, inputFieldDd;
    GameController gameController = new GameController();


    // Use this for initialization
    void Start()
    {
        //Debug.Log("start"); //zasto duplo??

       /* SerializedObject serializedObject = new SerializedObject(this);
        SerializedProperty serializedProperty = serializedObject.FindProperty("gameData");
        serializedObject.ApplyModifiedProperties();*/

        filePath = Application.dataPath + gameDataProjectFilePath;

        if (File.Exists(filePath))
        {

            dataAsJson = File.ReadAllText(filePath);
            inputJsonData = JsonMapper.ToObject(dataAsJson);

            /* inputFieldGo = GameObject.Find("pitanje");
            InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
            GameObject inputFieldA = GameObject.Find("odgovorA");
            InputField inputFieldAa = inputFieldA.GetComponent<InputField>();
            GameObject inputFieldB = GameObject.Find("odgovorB");
            InputField inputFieldBb = inputFieldB.GetComponent<InputField>();
            GameObject inputFieldC = GameObject.Find("odgovorC");
            InputField inputFieldCc = inputFieldC.GetComponent<InputField>();
            GameObject inputFieldD = GameObject.Find("odgovorD");
            InputField inputFieldDd = inputFieldD.GetComponent<InputField>();
            */
            showData(QuestionIndex);
            /*GameObject naprijedButton = GameObject.Find("Naprijed");
            Button naprijedOdabir = naprijedButton.GetComponent<Button>();
            naprijedOdabir.onClick.AddListener(prethodnoPitanje);
            GameObject natragButton = GameObject.Find("Natrag");
            Button natragOdabir = natragButton.GetComponent<Button>();
            natragOdabir.onClick.AddListener(sljedecePitanje);

            //int j = 0;
            void prethodnoPitanje()
            {
                Debug.Log("kliknuo si.");
            }

            void sljedecePitanje()
            {
                Debug.Log("kliknuo si nazad");
            }*/
           
            //title.text = inputjsondata["allrounddata"][0]["name"].tostring();
            //question.text = inputjsondata["allrounddata"][0]["questions"][0]["questiontext"].tostring();
            //answer.text = inputjsondata["allrounddata"][0]["questions"][0]["answers"][0]["answertext"].tostring();
            //answerinputfield.text = inputjsondata["allrounddata"][0]["questions"][0]["answers"][0]["answertext"].tostring();
            //questioninputfield.text = inputjsondata["allrounddata"][0]["questions"][0]["questiontext"].tostring();
            //answer.text = inputjsondata["allrounddata"][0]["questions"][0]["answers"][1]["answertext"].tostring();
            //answer.text = inputjsondata["allrounddata"][0]["questions"][0]["answers"][2]["answertext"].tostring();
            //answer.text = inputjsondata["allrounddata"][0]["questions"][0]["answers"][3]["answertext"].tostring();
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

    private void showData(int QuestionIndex)
    {
        int j = QuestionIndex;

        GameObject inputFieldGo = GameObject.Find("pitanje");
        inputFieldCo = inputFieldGo.GetComponent<InputField>();
        GameObject inputFieldA = GameObject.Find("odgovorA");
        inputFieldAa = inputFieldA.GetComponent<InputField>();
        GameObject inputFieldB = GameObject.Find("odgovorB");
        inputFieldBb = inputFieldB.GetComponent<InputField>();
        GameObject inputFieldC = GameObject.Find("odgovorC");
        inputFieldCc = inputFieldC.GetComponent<InputField>();
        GameObject inputFieldD = GameObject.Find("odgovorD");
        inputFieldDd = inputFieldD.GetComponent<InputField>();
        inputFieldCo.text = inputJsonData["allRoundData"][0]["questions"][j]["questionText"].ToString();

        //questionInputField.text = inputJsonData["allRoundData"]["questions"]["questionText"][j].ToString();
        //Debug.Log(j);
        Debug.Log(inputJsonData["allRoundData"][0]["questions"][j]["questionText"].ToString());
        //for (int k = 0; k < inputJsonData["allRoundData"][0]["questions"][j]["answers"].Count; k++)
        //{
        if (inputJsonData["allRoundData"][0]["questions"][j]["answers"][0]["answerText"].IsString)
        {
            inputFieldAa.text = inputJsonData["allRoundData"][0]["questions"][j]["answers"][0]["answerText"].ToString();
        }
        if (inputJsonData["allRoundData"][0]["questions"][j]["answers"][1]["answerText"].IsString)
        {
            inputFieldBb.text = inputJsonData["allRoundData"][0]["questions"][j]["answers"][1]["answerText"].ToString();
        }
        if (inputJsonData["allRoundData"][0]["questions"][j]["answers"][2]["answerText"].IsString)
        {
            inputFieldCc.text = inputJsonData["allRoundData"][0]["questions"][j]["answers"][2]["answerText"].ToString();
        }
        if (inputJsonData["allRoundData"][0]["questions"][j]["answers"][3]["answerText"].IsString)
        {
            inputFieldDd.text = inputJsonData["allRoundData"][0]["questions"][j]["answers"][3]["answerText"].ToString();
        }
    }

    public void NextQuestion()
    {
        Debug.Log("Stisnut NEXT");
        if((QuestionIndex+1) == inputJsonData["allRoundData"][0]["questions"].Count)
        {
            QuestionIndex = 0;
        }
        else
        {
            QuestionIndex += 1;
        }
        showData(QuestionIndex);
    }

    public void PreviousQuestion()
    {
        if (QuestionIndex == 0)
        {
            QuestionIndex = inputJsonData["allRoundData"][0]["questions"].Count-1;
        }
        else
        {
            QuestionIndex -= 1;
        }
        Debug.Log(QuestionIndex);
        showData(QuestionIndex);
    }

    /*public void SaveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(gameData);

        string filePath = Application.dataPath + gameDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }*/

    public void SaveQuestionsData()
    {
        inputJsonData["allRoundData"][0]["questions"][QuestionIndex]["questionText"] = inputFieldCo.text;
        dataAsJson = JsonMapper.ToJson(inputJsonData);
        File.WriteAllText(filePath, dataAsJson);
        Debug.Log(dataAsJson);
    }
    public void addQuestion() {

    }

    public void ReturnToMenu()
    {
        gameController.ReturnToMenu();
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
    */


}
