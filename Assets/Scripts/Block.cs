using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //config params
    [SerializeField] AudioClip destroyAudioClip;
    [SerializeField] GameObject blockSparflesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Level level;
    GameSession gameSession;

    //state variables
    [SerializeField] int hits; //serialize for debug purposes TODO: remove


    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            level.countBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hits++;
        if (tag == "Breakable")
            HandleBreakHit();

    }

    private void HandleBreakHit()
    {
        if (hits >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSPrite();
        }
    }

    private void ShowNextSPrite()
    {
        if (hitSprites[hits] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[hits];
        }
        else
        {
            Debug.LogError(gameObject.name + ": Block sprite is missing from array");
        }

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
