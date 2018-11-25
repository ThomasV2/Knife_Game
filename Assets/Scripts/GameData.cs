using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameData : MonoBehaviour {

    int speed = 50;
    [HideInInspector]
    public string form = "Hand";

    public int Speed { 
        get { return speed; } 
        set {
            switch (value)
            {
                case 0:
                    speed = 50;
                    break;
                case 1:
                    speed = 150;
                    break;
                case 2:
                    speed = 250;
                    break;
                default:
                    speed = 50;
                    break;
            }
        } 
    }

    public int Form
    { 
        set {
            switch (value)
            {
                case 0:
                    form = "Hand";
                    break;
                case 1:
                    form = "Tentacule";
                    break;
                case 2:
                    form = "Alien";
                    break;
                default:
                    form = "Hand";
                    break;
            }
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void StartGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
