using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour {
    [SerializeField] AudioClip breakBlock;
    [SerializeField] GameObject blockSparks;

    level level;

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
        if (tag == "Breakable") { DestroyBlock(); }  
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
