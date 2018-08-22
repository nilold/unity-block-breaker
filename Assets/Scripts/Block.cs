using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip destroyAudioClip;
    Level level;
    GameSession gameSession;
    [SerializeField] GameObject blockSparflesVFX;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.countBreakableBlocks();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();

    }

    private void DestroyBlock()
    {
        PlayDestroySound();
        level.countBrokenBlocks();
        gameSession.incrementPlayerScore();
        TriggerSparklesVFX();
    }

    private void PlayDestroySound()
    {
        AudioSource.PlayClipAtPoint(destroyAudioClip, Camera.main.transform.position);
        Destroy(gameObject, 0);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparflesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
