using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    public int breakableBlocks;

    SceneLoader sceneLoader;
    public void AddBreakableBlock()
    {
        breakableBlocks++;
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void DestroyBreakableBlock()
    {
        if (--breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
