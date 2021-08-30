using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int numberOfBlocks;
    ScreenLoader screenLoader;

    private void Start()
    {
        screenLoader = FindObjectOfType<ScreenLoader>();
    }

    public void addBlock()
    {
        numberOfBlocks++;
    }

    public void removeBlock()
    {
        numberOfBlocks--;

        if(numberOfBlocks == 0)
        {
            screenLoader.LoadNextScene();
        }
    }
    
}
