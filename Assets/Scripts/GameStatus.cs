using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    //config
    [Range(0.1f, 2f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBreak = 50;
    [SerializeField] TextMeshProUGUI scoreText;

    // state
    [SerializeField]int playerScore = 0;

	// Use this for initialization
	void Start ()
    {
        UpdatePlayerScore();
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

    //public int getPlayerScore()
    //{
    //    return playerScore;
    //}

}
