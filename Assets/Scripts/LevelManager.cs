using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Text TextScore;
    public AudioClip EndSound;
    public GameObject EndMenu;
    public 

    AudioSource audioSource;
    MoveKnife moveKnife;
    TriggerManager triggerManager;
    Text endScoreText;
    GameData gameData;

    int score = 0;

    void Start()
    {
        TextScore.text = "Score: " + score.ToString();
        audioSource = Camera.main.GetComponent<AudioSource>();
        moveKnife = Object.FindObjectOfType<MoveKnife>();
        triggerManager = Object.FindObjectOfType<TriggerManager>();
        endScoreText = EndMenu.GetComponentInChildren<Text>();
        gameData = Object.FindObjectOfType<GameData>();
        moveKnife.speed = gameData.Speed;
        triggerManager.InitialiseStart(gameData.form);
    }

    public void StartGame()
    {
        EndMenu.SetActive(false);
        score = 0;
        TextScore.text = "Score: " + score.ToString();
        moveKnife.StartGame();
        triggerManager.StartGame();
    }

    public void EndGame()
    {
        audioSource.clip = EndSound;
        audioSource.Play();
        moveKnife.Pause();
        endScoreText.text = "END OF THE GAME !\nYour score is : " + score.ToString();
        EndMenu.SetActive(true);

    }

    public void GetOnePoint()
    {
        score++;
        TextScore.text = "Score: " + score.ToString();
    }

    public void QuitGame()
    {
        Destroy(gameData.gameObject);
        SceneManager.LoadScene("Menu");
    }
}
