using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;
    public GameObject startUi;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverText;
    public GameObject gameOverPanel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	public void StartGame()
    {
        startUi.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
        scoreText.text = ScoreManger.instance.score.ToString();	
	}
    public void GameOver()
    {
        gameOverText.SetActive(true);
        highScoreText.text = "High Score: "+PlayerPrefs.GetInt("HighScore").ToString();
        gameOverPanel.SetActive(true);
    }
    public void Replay()
    {
        SceneManager.LoadScene("level1");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
