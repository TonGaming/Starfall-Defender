using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    TextMeshProUGUI playerScoreUI;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        playerScoreUI = GetComponent<TextMeshProUGUI>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Start is called before the first frame update
    void Start()
    {
        float playerScore = scoreKeeper.GetCurrentScore();

        playerScoreUI.text = "YOU SCORED:\n" + playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
