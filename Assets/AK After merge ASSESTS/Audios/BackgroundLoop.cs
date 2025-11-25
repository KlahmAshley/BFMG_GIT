using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
   public AudioSource backgroundMusic;
    void Start()
    {
        DontDestroyOnLoad(backgroundMusic);
    }

}