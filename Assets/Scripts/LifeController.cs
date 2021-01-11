using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public int lifeCount;
    public Text livesText;


    // Start is called before the first frame update
    void Start()
    {
        lifeCount = Constants.STARTING_LIVES;
        livesText.text = "Remaining Lives: " + lifeCount;
    }

    public void UpdateLivesText()
    {

        //Debug.Log("Life count at " + lifeCount + ". Removing life.);
        lifeCount--;
        livesText.text = "Remaining Lives: " + lifeCount;
        if (lifeCount < 0)
        {
            //Reset
        }
    }
}
