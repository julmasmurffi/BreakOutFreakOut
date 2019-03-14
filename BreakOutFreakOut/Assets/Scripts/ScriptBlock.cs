using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour {
    [SerializeField] AudioClip breakBlock;
    [SerializeField] GameObject blockSparks;

    level level;

    private void Start()
    {
        level = FindObjectOfType<level>();

        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
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
