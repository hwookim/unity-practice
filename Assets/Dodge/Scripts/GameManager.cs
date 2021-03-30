using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;
    public Text playerInfoText;

    private float surviveTime;
    private bool isGameover;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("ID", 2016112661);
        PlayerPrefs.SetString("name", "김현우");
        playerInfoText.text = PlayerPrefs.GetInt("ID") + " " + PlayerPrefs.GetString("name");

        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover) {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int) surviveTime;
        }
        else {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene("Dodge");
            }
        }
    }

    public void EndGame() {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime) {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int) bestTime;
    }
}
