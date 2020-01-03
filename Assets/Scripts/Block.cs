using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    AudioClip breakSound;

    [SerializeField]
    GameObject blockSparkleVFX;

    [SerializeField]
    Sprite[] hitSprites;

    Level level;
    GameSession gameStatus;
    int timesHit;
    int maxHits;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        maxHits = hitSprites.Length + 1;
        if (CompareTag("Breakable"))
        {
            level.AddBreakableBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        if (++timesHit >= maxHits)
        {
            DestoryBlock();
        }
        else
        {
            ShowNextHotSprite();
        }
    }

    private void ShowNextHotSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    private void DestoryBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.DestroyBreakableBlock();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
