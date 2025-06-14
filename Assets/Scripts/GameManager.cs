using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject QuizPanel;
    public GameObject StartPanel;


    private void Start()
    {
        StartPanel.SetActive(true);
        QuizPanel.SetActive(false);
    }
    public void StartQuiz()
    {
        StartPanel.SetActive(false);
        QuizPanel.SetActive(true);

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

    public void EndQuiz()
    {
        StartPanel.SetActive(false);
        QuizPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
