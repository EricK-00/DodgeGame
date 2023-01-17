using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public TMP_Text timeText;
    public TMP_Text bestText;

    private const string SCENE_NAME = "SampleScene";
    private const string BEST_TIME_RECORD = "best";
    private float surviveTime = 0f;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt(BEST_TIME_RECORD, 0);
        bestText.text = $"Best: {PlayerPrefs.GetInt(BEST_TIME_RECORD)}";
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            //Time.timeScale = 0f;

            if (Input.GetKeyDown(KeyCode.R))
            {  
                //isGameOver = false;
                //player.transform.position = Vector3.zero;
                //player.SetActive(true);

                SceneManager.LoadScene(SCENE_NAME);
            }
        }

        surviveTime += Time.deltaTime;
        timeText.text = $"Time: {(int)surviveTime}";
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverText.SetActive(true);

        int bestTimeRecord = Mathf.Max((int)surviveTime, PlayerPrefs.GetInt(BEST_TIME_RECORD));
        PlayerPrefs.SetInt(BEST_TIME_RECORD, bestTimeRecord);

        bestText.text = $"Best: {bestTimeRecord}";
    }
}
