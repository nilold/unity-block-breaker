using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //cached reference
    Ball gameBall;
    GameSession gameSession;

	// Use this for initialization
	void Start () {
        gameBall = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(gameSession.isAutoPlayEnabled())
        {
            AutoPlay();
        }
        else
        {
            PlayOnMouse();
        }
    }

    private void AutoPlay()
    {
        Vector2 paddlePos = new Vector2(gameBall.transform.position.x, transform.position.y);
        if(gameBall.transform.position.y < 2f)
        transform.position = paddlePos;
    }

    private void PlayOnMouse()
    {
        float mouseXPosition = screenWidthUnits * Input.mousePosition.x / Screen.width;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mouseXPosition, minX, maxX);
        transform.position = paddlePos;
    }
}
