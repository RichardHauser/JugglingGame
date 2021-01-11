using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public float currentTime = 0f;

    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        int seconds = (int)(currentTime % 60);
        timeText.text = "Elapsed Time: " + seconds;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        int seconds = (int)(currentTime % 60);
        timeText.text = "Elapsed Time: " + seconds;
    }
}
