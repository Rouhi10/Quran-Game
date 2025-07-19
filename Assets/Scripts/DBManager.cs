using System.Collections;
using System.Collections.Generic;
using SQLite;
using System.IO;
using UnityEngine;
using System.Linq;
using System;

public class DBManager : MonoBehaviour
{
    SQLiteConnection db;

    string dbName = "QuranWordDB.db";
    string dbPath;


    QuizManager quizManager;
    void Start()
    {
        quizManager = GetComponent<QuizManager>();

        StartCoroutine(LoadDatabase());

    }

    public IEnumerator LoadDatabase()
    {
        string sourcePath = Path.Combine(Application.streamingAssetsPath, dbName);
        string destPath = Path.Combine(Application.persistentDataPath, dbName);

        if (!File.Exists(destPath))
        {
            // اگر فایل در مسیر مقصد وجود نداشت، آن را از مسیر استریمینگ کپی کن
            var www = UnityEngine.Networking.UnityWebRequest.Get(sourcePath);
            yield return www.SendWebRequest();

            File.WriteAllBytes(destPath, www.downloadHandler.data);
        }

        dbPath = destPath;

        // اتصال به دیتابیس SQLite
        db = new SQLiteConnection(dbPath);
        var table = db.Table<QuestionsWord>().ToList();

        quizManager.QuestionDB.questions = new List<QuestionData>();

        foreach (QuestionsWord question in table)
        {
            // ایجاد متن سوال با فاصله و - بین حروف
            string spacedWord = string.Join(" - ", question.Word.ToCharArray().OrderBy(a => Guid.NewGuid()));



            // تصادفی کردن ترتیب پاسخ‌ها
            List<string> answers = new List<string> {
                question.Word,
                question.Similar1,
                question.Similar2,
                question.Similar3 
            };
            answers = answers.OrderBy(a => Guid.NewGuid()).ToList();



            // پیدا کردن ایندکس پاسخ صحیح پس از تصادفی‌سازی
            string correctAnswer = question.Word;
            int correctIndex = answers.IndexOf(correctAnswer);

            // اضافه کردن سوال به دیتابیس آزمون
            quizManager.QuestionDB.questions.Add(new QuestionData
            {
                questionText = spacedWord,
                questionMeaning = question.Meaning,
                answers = answers.ToArray(),
                correctAnswerIndex = correctIndex
            });
        }


        // انتخاب سوالات برای آزمون
        quizManager.SelectQuiz();
    }


    public class QuestionsWord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Word { get; set; }
        public string Meaning { get; set; }
        public string Similar1 { get; set; }
        public string Similar2 { get; set; }
        public string Similar3 { get; set; }
    }
}
