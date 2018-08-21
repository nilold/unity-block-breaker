using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip destroyAudioClip;
    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.countBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();

    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(destroyAudioClip, Camera.main.transform.position);
        Destroy(gameObject, 0);
        level.countBrokenBlocks();
        gameStatus.incrementPlayerScore();
    }
}
