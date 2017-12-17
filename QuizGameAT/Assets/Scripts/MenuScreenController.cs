using UnityEngine;
using System.Collections;


public class MenuScreenController : MonoBehaviour
{
    private DataController dataController;
    private RoundData currentRoundData;

    public void StartGame(int roundIndex)
	{
        dataController = FindObjectOfType<DataController>();
        dataController.SetRoundIndex(roundIndex);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

    public void ExitGame()
    {
        Application.Quit();
    }
}