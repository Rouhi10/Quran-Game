using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData 
{
    public string questionText;
    public string[] answers = new string[4];
    public int correctAnswerIndex;
}
