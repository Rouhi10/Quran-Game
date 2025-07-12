using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    void Start()
    {
        // برسی کردن اینکه ایا یک شی با تگ AudioManager وجود دارد یا خیر
        if (GameObject.FindGameObjectsWithTag("AudioManager").Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
