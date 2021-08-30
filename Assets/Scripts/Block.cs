using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakAudio;
    [SerializeField] GameObject particleEffect;
    [SerializeField] int maxHit;
    [SerializeField] int numOfHits = 0;
    [SerializeField] Sprite[] hitSprites;
    Level level;
    GameStatus status;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if(tag == "Breakable")
            level.addBlock();
        status = FindObjectOfType<GameStatus>();
        maxHit = hitSprites.Length + 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            numOfHits++;
            if (numOfHits >= maxHit)
            {
                AudioSource.PlayClipAtPoint(breakAudio, Camera.main.transform.position);
                Destroy(gameObject);
                level.removeBlock();
                effectCommencer();
                status.addScore();
            }

            else
            {
                initiateNextSprite();
            }
        }
    }

   public void effectCommencer()
    {
        GameObject particle = Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(particle,1f);
    }

    private void initiateNextSprite()
    {
        if (hitSprites[numOfHits-1] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[numOfHits - 1];
        else
            Debug.LogError("Out of bounds from " + gameObject.name);
    }
}
