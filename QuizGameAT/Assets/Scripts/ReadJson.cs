using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadJson : MonoBehaviour {

    private RoundData[] allRoundData;
    private string gameDataFileName = "data.json";

    // Use this for initialization
    void Start () {
        LoadGameData();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void LoadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

            allRoundData = loadedData.allRoundData;
            //Debug.Log(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
}
