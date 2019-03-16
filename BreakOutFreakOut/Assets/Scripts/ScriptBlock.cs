using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour {

    //config params
    [SerializeField] AudioClip breakBlock;
    [SerializeField] GameObject blockSparks;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //cached ref
    level level;


    //state vars
    [SerializeField] int timesHit; //TODO only serialized for debugging

    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<level>();
        if (tag == "Breakable") { level.CountBlocks(); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits) { DestroyBlock(); }
    }

    private void DestroyBlock()
    {
            TriggerSparklesVFX();
            PlayBlockDestroy();
            Destroy(gameObject);
            level.BlockDestroyed();
    }

    private void PlayBlockDestroy()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakBlock, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparks, transform.position, transform.rotation);

        Destroy(sparkles, 1f);
    }

    

    

}
