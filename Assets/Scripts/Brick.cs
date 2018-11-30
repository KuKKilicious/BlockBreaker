using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    [SerializeField]
    public AudioClip crack;
    [SerializeField]
    GameObject smoke;
    public static int breakableCount = 0;

    [SerializeField]
    Sprite[] hitSprites;

    
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    // Use this for initialization
    void Start () {
        isBreakable  = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
        
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (isBreakable)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
        }
        

    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        Debug.Log(timesHit);
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        ParticleSystem.MainModule mainModule = smokePuff.GetComponent<ParticleSystem>().main;
        mainModule.startColor = this.GetComponent<SpriteRenderer>().color;
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }else
        {
            Debug.LogError("missing sprite on Brick");
        }
    }


    // TODO Remove this method once we can actually win
    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
    
}
