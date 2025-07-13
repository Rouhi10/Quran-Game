using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RTLTMPro;


public class GameManager : MonoBehaviour
{
    public GameObject QuizPanel;
    public GameObject StartPanel;
    public GameObject FinishPanel;

    [Space]
    public RTLTextMeshPro TextResultCorrect;
    public RTLTextMeshPro TextResultWrong;
    public RTLTextMeshPro TextResultTotal;

    private void Start()
    {
        StartPanel.SetActive(true);
        QuizPanel.SetActive(false);
        FinishPanel.SetActive(false);
    }
    public void StartQuiz()
    {
        StartPanel.SetActive(false);
        QuizPanel.SetActive(true);

        // بررسی وجود کامپوننت QuizManager و نمایش سوال جدید
        QuizManager quizManager = GetComponent<QuizManager>();
        if (quizManager != null)
        {
            quizManager.ShowNewQuestion();
        }
        else
        {
            Debug.LogError("QuizManager component not found");
        }
    }

    public void EndQuiz(int countOfCorrectAnswer,int countOfWorngAnswer)
    {
        StartPanel.SetActive(false);
        QuizPanel.SetActive(false);

        FinishPanel.SetActive(true);

        // نمایش نتایج در پنل پایان
        TextResultCorrect.text = countOfCorrectAnswer.ToString();
        TextResultWrong.text = countOfWorngAnswer.ToString();

        // محاسبه درصد پاسخ‌های صحیح
        float percentage = (float)countOfCorrectAnswer / (countOfCorrectAnswer + countOfWorngAnswer) * 100f;
        TextResultTotal.text = percentage.ToString("0") + "%";
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
