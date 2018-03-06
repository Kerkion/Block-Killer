using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public static int brickCount = 0;
    private int timesHit;
    private LevelManager levelManager;
    public Sprite[] hitSprites;
    private bool isBreakable;

	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        //pracenje lomljivih cigli
        if (isBreakable)
        {
            brickCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            brickCount--;
            Destroy(gameObject);
            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
       // SimulateWin();
    
    // TODO unisti ovu metodu kad bude omoguceno unistavanje brik-a

    /*void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }*/
}
