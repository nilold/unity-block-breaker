using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    //config
    [Range(0.1f, 2f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBreak = 50;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool enableAutoplay;

    // state
    [SerializeField]int playerScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if(gameStatusCount > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        UpdatePlayerScore();
    }

    public void DestroyStatus()
    {
        Destroy(gameObject);
    }

    private void UpdatePlayerScore()
    {
        scoreText.SetText(playerScore.ToString());
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void incrementPlayerScore()
    {
        playerScore += pointsPerBreak;
        UpdatePlayerScore();

    }

    public bool isAutoPlayEnabled(){
        return enableAutoplay;
    }

    //public int getPlayerScore()
    //{
    //    return playerScore;
    //}

}
