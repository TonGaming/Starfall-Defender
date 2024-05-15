using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    Health playerHealth;
    ScoreKeeper playerScore;

    [SerializeField] Slider playerHealthBarUI;
    [SerializeField] TextMeshProUGUI playerScoreText;

    private void Awake()
    {
        playerHealth = FindAnyObjectByType<Player>().GetComponent<Health>();
        playerScore = FindAnyObjectByType<ScoreKeeper>();
    }
    
    void Start()
    {
        playerHealthBarUI.maxValue = playerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBarUI.value = playerHealth.GetHealth();



        playerScoreText.text = playerScore.GetCurrentScore().ToString("00000");
    }


}
