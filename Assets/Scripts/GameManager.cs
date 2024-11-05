using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text countdownText;
    [SerializeField] private Text resultText;
    [SerializeField] private GameObject resultUI;
    [SerializeField] private float levelTime = 10;

    private float time;

    void Start()
    {
        resultUI.SetActive(false);
        time = levelTime;
        StartCoroutine(countdown());
    }

    // Update is called once per frame
    void Update()
    {
        //if (time > 0)
        //{
        //    time = time - Time.deltaTime;
        //    if (time < 0 )
        //    {
        //        time = 0;
        //    }
        //    countdownText.text = time.ToString("0.0");
        //}
    }

    private IEnumerator countdown()
    {
        countdownText.text = time.ToString("0.0");
        do
        {
            yield return null;
            time -= Time.deltaTime;
            countdownText.text = time.ToString("0.0");
        } while (time > 0);

        countdownText.text = "0";
        gameEnd(false);
    }

    private void gameEnd(bool isPass)
    {
        resultUI.SetActive(true);
        if (isPass)
        {
            resultText.text = "Pass";
        }
        else
        {
            resultText.text = "Fail";
        }
    }

    public void Again()
    {
        SceneManager.LoadScene(0);
    }
}
