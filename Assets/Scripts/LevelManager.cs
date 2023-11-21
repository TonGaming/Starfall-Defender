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

    private void Awake()
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

    public void ResetAndLoadGame()
    {
        SceneManager.LoadScene("CoreGame");

        scoreKeeper.ResetCurrentScore();
    }

    public void StartGORoutine() // GameOver Routine
    {
        StartCoroutine(LoadGameOver());
    }

    

    public IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene("GameOverMenu");

        //playerScore = scoreKeeper.GetCurrentScore();

        //playerScoreUI.text = "Dung dz123123123:\n" + playerScore;
    }

    public void ExitGame()
    { 

        Application.Quit();
    }
}
