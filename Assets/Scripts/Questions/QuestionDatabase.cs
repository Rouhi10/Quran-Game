using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// این ویژگی یک گزینه در منوی Create یونیتی اضافه می‌کند
[CreateAssetMenu(fileName = "New Question Database", menuName = "Quiz/Question Database")]

// این کلاس از ScriptableObject ارث‌بری می‌کند تا بتواند به عنوان یک asset ذخیره شود
public class QuestionDatabase : ScriptableObject
{
    // لیستی از تمام سوالات موجود در این پایگاه داده
    public List<QuestionData> questions;
}