using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    [SerializeField] Text TimeText = null;
    [SerializeField] GameObject timeManager = null;
    [SerializeField] GameObject Canvas = null;
    [SerializeField] GameObject GoodMassege = null;
    [SerializeField] GameObject ButMessage = null;
    [SerializeField] Text Counttext = null;
    [SerializeField] GameObject gameoverPanel = null;
    [SerializeField] GameObject gameclearPanel = null;
    [SerializeField] Text TitelText = null;


    int countDown;

    GameObject butPrefab;
    GameObject goodPrefab;
    float timeCount;
    bool isStartflg;

     void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        timeCount = 0;
        countDown = 3;
        Counttext.text = countDown.ToString();
        ShowTime();
        TitelText.text = Static.TitelText;
       
    }

     void Update()
    {
        if (isStartflg)
        {
            timeCount += Time.deltaTime;
            ShowTime();
            if (timeCount >= 1.0f)
            {
                NotDisplay();
            }
           
        }
        else
        {
            OnDisplay();
            ShowTime();
           
        }
       

    }

    void ShowTime()
    {
        TimeText.text = timeCount.ToString("F2");
    }

    public void StartTime()
    {
        isStartflg = true;
        countDown--;
        Counttext.text = countDown.ToString();
    }

    public void StopTime()
    {
        isStartflg = false;
        //timeCount = 3.0f;
        if (timeCount == Static.CleraTime)
        {
            ShowMasseg();
            GameClearScene();
        }
        else
        {
            ShowButMessage();
            GameOverScene();
        }
        
    }

    void OnDisplay()
    {
        timeManager.SetActive(true);

    }

    void NotDisplay()
    {
        timeManager.SetActive(false);

    }

    void ShowMasseg()
    {
        GameObject prefab = (GameObject)Instantiate(GoodMassege);
        prefab.transform.SetParent(Canvas.transform, false);
    }
    void ShowButMessage()
    {
        butPrefab = (GameObject)Instantiate(ButMessage);
        butPrefab.transform.SetParent(Canvas.transform, false);
    }

    public void ResetClick(int count)
    {
        timeCount = 0;
        TimeText.text = timeCount.ToString("F2");
        GameObject.Destroy(butPrefab);
    }


    public void GameOverScene()
    {
       StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        if (countDown <= 0 && !isStartflg)
        {
            yield return new WaitForSeconds(1.3f);
            gameoverPanel.SetActive(true);
        }
    }

    public void ChnangeTitle()
    {
        SceneManager.LoadScene("TitelScene");
    }

    public void GameClearScene()
    {
        StartCoroutine(GameClear());
    }

    IEnumerator GameClear()
    {
        if (timeCount == Static.CleraTime  && !isStartflg || countDown <= 0 && !isStartflg)
        {
            yield return new WaitForSeconds(1.3f);
            gameclearPanel.SetActive(true);
        }
    }

    public void onclickTitel()
    {
        SceneManager.LoadScene("TitelScene");
    }
}
