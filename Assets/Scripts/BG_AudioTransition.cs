using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_AudioTransition : MonoBehaviour
{

    private static BG_AudioTransition instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }
}
