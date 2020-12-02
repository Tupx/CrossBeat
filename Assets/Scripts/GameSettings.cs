using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    public string fileData;
    public string[] lines;
    public string[] lineData;
    public float x;
    public float[] extractedData;

    // Start is called before the first frame update
    void Start()
    {
         extractedData = new float[128];
         fileData = System.IO.File.ReadAllText("Assets/clearlySoundData.csv");
         lines = fileData.Split("\n"[0]);

        int a = 0;

         foreach (string data in lines)
        {
            lineData = (lines[a].Trim()).Split(","[0]);
            if (a <= 128)
            {
                extractedData[a] = float.Parse(lineData[0]);
                Debug.Log(extractedData[a]);
            }
            a++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
