using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text TextScore;
    public AudioClip EndSound;
    public GameObject EndMenu;

    AudioSource audioSource;
    MoveKnife moveKnife;
    TriggerManager triggerManager;
    Text endScoreText;

    int score = 0;

    void Start()
    {
        TextScore.text = "Score: " + score.ToString();
        audioSource = Camera.main.GetComponent<AudioSource>();
        moveKnife = Object.FindObjectOfType<MoveKnife>();
        triggerManager = Object.FindObjectOfType<TriggerManager>();
        endScoreText = EndMenu.GetComponentInChildren<Text>();
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

    public void QuitApplication()
    {
        Application.Quit();
    }
}
