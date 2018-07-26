using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour {
    [SerializeField] AudioClip breakBlock;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakBlock, Camera.main.transform.position);
        Destroy(gameObject);    
    }

}
