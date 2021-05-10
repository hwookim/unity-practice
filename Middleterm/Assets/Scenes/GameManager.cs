using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject text;
    public Text timeText;
    public Text scoreText;

    private float playTime;
    private bool isEnd;

    // Start is called before the first frame update
    void Start()
    {
        playTime = 15;
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnd) {
            playTime -= Time.deltaTime;
            timeText.text = "Time: " + (int) playTime;
        }
    }

    public void EndGame() {
        isEnd = true;
        ShowGameEndText();
    }

    void ShowGameEndText() {
        float score = PlayerPrefs.GetFloat("Score");
        scoreText.text = "Score: " + (int) score;
    }
}
