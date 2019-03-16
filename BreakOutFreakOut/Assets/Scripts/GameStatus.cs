using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    //conf params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePerDestroyedBlock = 50;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    //state vars
    [SerializeField] int currentScore = 0;
    int resetScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();

    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = 1f;
	}

    public void AddToScore()
    {
        currentScore = currentScore + scorePerDestroyedBlock;

        scoreText.text = currentScore.ToString();
    }

    public void ResetScore()
    {
        currentScore = resetScore;
        scoreText.text = currentScore.ToString();
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
