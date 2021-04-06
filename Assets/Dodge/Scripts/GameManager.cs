using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameEndText;
    public Text timeText;
    public Text recordText;
    public Text playerInfoText;

    private float playTime;
    private bool isEnd;
    private int bulletSpawnerCount;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("ID", 2016112661);
        PlayerPrefs.SetString("name", "김현우");
        playerInfoText.text = PlayerPrefs.GetInt("ID") + " " + PlayerPrefs.GetString("name");

        playTime = 0;
        bulletSpawnerCount = 4;
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnd) {
            playTime += Time.deltaTime;
            timeText.text = "Time: " + (int) playTime;
        }
        else {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene("Dodge");
            }
        }
    }

    public void EndGame() {
        isEnd = true;
        ShowGameEndText();
    }

    public void DestroyBulletSpawner() {
        bulletSpawnerCount--;
        if (bulletSpawnerCount == 0) {
            isEnd = true;
            ShowGameEndText();
        }
    }

    void ShowGameEndText() {
        gameEndText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if (playTime < bestTime) {
            bestTime = playTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time: " + (int) bestTime;
    }
}
