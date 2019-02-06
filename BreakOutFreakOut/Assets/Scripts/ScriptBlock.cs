using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour {
    [SerializeField] AudioClip breakBlock;

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
        FindObjectOfType<GameStatus>().AddToScore();

        AudioSource.PlayClipAtPoint(breakBlock, Camera.main.transform.position);
        Destroy(gameObject);

        level.BlockDestroyed();

    }
}
