using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public QuestionDatabase QuestionDB;

    [Space]
    public RTLTextMeshPro QuestionText;
    public RTLTextMeshPro[] AnswerBtnText;

    [Space]
    public GameObject NextQuestPanel;
    public GameObject WorngAnswerPanel;
    public GameObject FinishPanel;

    private List<QuestionData> availableQuestions;
    private QuestionData currentQuestion;

    GameManager gameManager;
    void Start()
    {
        gameManager = GetComponent<GameManager>();

        // New Cpoy of the questions DB
        availableQuestions = new List<QuestionData>(QuestionDB.questions);
        
    }

    public void ShowNewQuestion()
    {
        NextQuestPanel.SetActive(false);
        WorngAnswerPanel.SetActive(false);

        ResetColorBtn();

        
        if (availableQuestions.Count == 0)
        {
            Debug.Log("Game Finished! No more questions available.");
            gameManager.EndQuiz();
            FinishPanel.SetActive(true);
            return;
        }

        // Randomly select a question from the available questions
        int randomIndex = Random.Range(0, availableQuestions.Count);
        currentQuestion = availableQuestions[randomIndex];

        // Set the question text and answers in the UI
        QuestionText.text = currentQuestion.questionText;
        for (int i = 0; i < AnswerBtnText.Length; i++)
        {
            AnswerBtnText[i].text = currentQuestion.answers[i];
        }

        // Remove the question from the available list
        availableQuestions.RemoveAt(randomIndex);
    }
    void ShowAnswerWhitColorBtn()
    {
        // Show the correct answer with green and wrong answers with red

        for (int i = 0; i < AnswerBtnText.Length; i++)
        {
            if (i == currentQuestion.correctAnswerIndex)
            {
                AnswerBtnText[i].GetComponentInParent<Image>().color = Color.green;
            }
            else
            {
                AnswerBtnText[i].GetComponentInParent<Image>().color = Color.red;
            }
        }
    }

    void ResetColorBtn()
    {
        // Reset the color of all answer buttons to white
        for (int i = 0; i < AnswerBtnText.Length; i++)
        {
            AnswerBtnText[i].GetComponentInParent<Image>().color = Color.white;
        }
    }
    public void OnAnswerSelected(int answerIndex)
    {
        // Check if the selected answer is correct or wrong
        ShowAnswerWhitColorBtn();
        if (answerIndex == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Correct");
            NextQuestPanel.SetActive(true);
            return;
        }
        else
        {
            Debug.Log("Worng");
            WorngAnswerPanel.SetActive(true);
        }



    }
}
