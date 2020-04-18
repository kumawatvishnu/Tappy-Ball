using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public bool gameOver;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        gameOver = false;
        UIManager.instance.StartGame();
        GameObject.Find("PipeSpawner").GetComponent<PipeSpawner>().StartSpawningPipes();
        //GameObject.Find("PipeHolder").GetComponent<PipeController>().StartMovePipe();
    }
    public void GameOver()
    {
        gameOver = true;
        GameObject.Find("PipeSpawner").GetComponent<PipeSpawner>().StopSpawningPipes();
        ScoreManger.instance.StopScore();
        UIManager.instance.GameOver();
    }
}
