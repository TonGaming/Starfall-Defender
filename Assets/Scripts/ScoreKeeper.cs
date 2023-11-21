using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    // biến để lưu điểm - phải private
    [SerializeField] float currentScore;


    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        int instancesNum = FindObjectsOfType<ScoreKeeper>().Length;
        if(instancesNum > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // chắc chắn phải có một Getter
    public float GetCurrentScore()
    {
        return currentScore;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    // tạo một setter để có thể modified số điểm của player từ script khác
    public void IncreaseCurrentScore(float score)
    {
        currentScore += score;

        // Khoanh vùng điểm số lại để hạn chế âm
        Mathf.Clamp(score, 0, int.MaxValue);
    }

    // Reset lại điểm số
    public float ResetCurrentScore()
    {
        return currentScore = 0;
    }

    // k cần vì đã tích hợp vào Setter rồi
    //public float IncrementScore()
    //{
    //    return currentScore++;
    //}


}
