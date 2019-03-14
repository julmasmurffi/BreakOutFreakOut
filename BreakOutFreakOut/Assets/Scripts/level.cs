using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour {
    
    //debugging for editor
    [SerializeField] int breakableBlocks; 
    
    // cache ref
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
