using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter 
{
    int _lives;
    public int currentLives
    {
        set
        {
            _lives = value;
            PlayerPrefs.SetInt("Lives", _lives);
        }
        get
        {
            return _lives;
        }
    }
 }
