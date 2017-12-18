using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundButtons : MonoBehaviour
{

    public GameObject prefabButton;
    public RectTransform ParentPanel;

    private DataController dataController;

    // Use this for initialization
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        int numberOfRounds = dataController.GetAllRoundDataLength();

        for (int i = 0; i < numberOfRounds; i++)
        {
            int tempInt = i;

            GameObject goButton = (GameObject)Instantiate(prefabButton);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);
          
            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = "Ponavljanje " + (tempInt+1);
            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }

    }

    public void ButtonClicked(int buttonNo)
    {
        dataController.SetRoundIndex(buttonNo);
 
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

}