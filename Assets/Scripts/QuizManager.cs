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

    [Space]
    public GameObject CorrectPS;
    public GameObject WorngPS;

    private List<QuestionData> availableQuestions;
    private QuestionData currentQuestion;

    GameManager gameManager;
    void Start()
    {
        gameManager = GetComponent<GameManager>();

        // نسخه جدید از دیتابیس برای ایجاد نشدن تداخل
        availableQuestions = new List<QuestionData>(QuestionDB.questions);
        
    }

    public void ShowNewQuestion()
    {
        CorrectPS.SetActive(false);
        WorngPS.SetActive(false);


        // غیر فعال کردن پنل های پاسخ و ریست کردن رنگ دکمه ها
        NextQuestPanel.SetActive(false);
        WorngAnswerPanel.SetActive(false);
        ResetColorBtn();

        
        // برسی کردن اینکه ایا بازی تمام شده است یا نه
        if (availableQuestions.Count == 0)
        {
            Debug.Log("Game Finished! No more questions available.");
            gameManager.EndQuiz();
            FinishPanel.SetActive(true);
            return;
        }

        // انتخاب یک سوال تصادفی از لیست سوالات باقی مانده
        int randomIndex = Random.Range(0, availableQuestions.Count);
        currentQuestion = availableQuestions[randomIndex];

        // نمایش سوال و پاسخ ها در UI
        QuestionText.text = currentQuestion.questionText;
        for (int i = 0; i < AnswerBtnText.Length; i++)
        {
            AnswerBtnText[i].text = currentQuestion.answers[i];
        }

        // حذف سوال نمایش داده شده از لیست باقی مانده ها
        availableQuestions.RemoveAt(randomIndex);
    }
    void ShowAnswerWhitColorBtn()
    {
        // نمایش سوالات غلط و درست با رنگ قرمز و سبز

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
        // ریست کردن رنگ دکمه ها به سفید
        for (int i = 0; i < AnswerBtnText.Length; i++)
        {
            AnswerBtnText[i].GetComponentInParent<Image>().color = Color.white;
        }
    }
    public void OnAnswerSelected(int answerIndex)
    {
        // برسی پاسخ انتخاب شده و نمایش پاسخ صحیح یا غلط
        ShowAnswerWhitColorBtn();
        if (answerIndex == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Correct");
            NextQuestPanel.SetActive(true);
            CorrectPS.SetActive(true);
            return;
        }
        else
        {
            Debug.Log("Worng");
            WorngAnswerPanel.SetActive(true);
            WorngPS.SetActive(true);
        }



    }
}
