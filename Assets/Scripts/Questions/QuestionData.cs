using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// این ویژگی نشان می‌دهد که این کلاس قابل نمایش در ادیتور یونیتی و ذخیره شدن است
[System.Serializable]
public class QuestionData 
{
    public string questionText;
    public string[] answers = new string[4];
    public int correctAnswerIndex;
}
