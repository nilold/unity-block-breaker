using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] int breakableBlocks; //only for debug purposes
    SceneLoader sceneLoader;
    //GameStatus gameStatus;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        //gameStatus = FindObjectOfType<GameStatus>();
    }

    public void countBlocks()
    {
        breakableBlocks++;
        //gameStatus.incrementPlayerScore();
    }

    public void countBrokenBlocks(){
        breakableBlocks--;
        if (breakableBlocks < 1)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
