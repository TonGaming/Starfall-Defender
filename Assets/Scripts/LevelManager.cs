using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    float playerScore;
    [SerializeField] TextMeshProUGUI playerScoreUI;

    [SerializeField] float delayTime = 1f;

    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene("CoreGame");
    }

    public void StartGORoutine()
    {
        StartCoroutine(LoadGameOver());
    }

    public IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene("GameOverMenu");

        playerScore = scoreKeeper.GetCurrentScore();

        playerScoreUI.text = "YOUR SCORE:\n" + playerScore;
    }

    public void ExitGame()
    { 

        Application.Quit();
    }
}
