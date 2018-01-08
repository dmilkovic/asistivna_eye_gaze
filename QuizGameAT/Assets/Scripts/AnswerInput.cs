using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerInput : MonoBehaviour {

    public InputField answerText;

    private GameController gameController;
    private AnswerData answerData;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void SetUp(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }

    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}
