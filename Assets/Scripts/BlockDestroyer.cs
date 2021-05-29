using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockDestroyer : MonoBehaviour
{
    [SerializeField] AudioClip breaksound;
    [SerializeField] GameObject ImpactVFX;
    Level level;
    [SerializeField] Sprite[] hitSprites;
    int timeshit = 0;

    public void Start()
    {
            level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SFX();
        if (tag == "Breakable")
        {
            timeshit++;
            int maxHits = hitSprites.Length + 1;
            if (timeshit >= maxHits)
            {
                ImpactVFFEffects();
                DestroyTheBlock();
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = hitSprites[timeshit-1]; 
            }
        }
    }
    private void DestroyTheBlock()
    {
            FindObjectOfType<GameStatus>().AddToScore();
            Destroy(gameObject);
            level.BlockDestroyed();      
    }
    private void SFX()
    {
        AudioSource.PlayClipAtPoint(breaksound, Camera.main.transform.position);
    }
    private void ImpactVFFEffects()
    {
        GameObject Sparkles = Instantiate(ImpactVFX, transform.position, transform.rotation);
        Destroy(Sparkles, 1f);
    }    
}
