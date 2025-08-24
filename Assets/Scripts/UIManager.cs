using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void CloseGame()
    {
        // بسته شدن بازی
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void OpenScene(int sceneIndex)
    {
        // لود یک صحنه با ایندکس انتخابی
        SceneManager.LoadScene(sceneIndex);
    }

    public void OpenInfoPanel(GameObject panel)
    {
        //باز کردن پنل درباره ما
        panel.SetActive(true);
    }

    public void CloseInfoPanel(GameObject panel)
    {
        //بستن پنل درباره ما
        panel.SetActive(false);
    }
}
