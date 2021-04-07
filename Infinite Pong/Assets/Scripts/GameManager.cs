using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Final;
    public GameObject Left;
    public GameObject Right;
    public GameObject RetryButton;
    public GameObject Paddle;
    public GameObject Ball;
    public TextMeshProUGUI text;

    public GameObject TitleScreen;
    public GameObject GameplayObj;
    public TextMeshProUGUI HST;
    public TextMeshProUGUI HSG;

    bool speedmod = true;

    
    
    
    int score;
    // Start is called before the first frame update
    void Start()
    {

        HST.text = "HighScore " + PlayerPrefs.GetInt("HighScore").ToString();
        
        score = 0;
        text.text = score.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score%20 == 0 && score != 0 && speedmod && Ball.GetComponent<Ball>().speed <3.2f)
        {
            speedmod = false;
            if (score < 200)
            {

            
            
            Ball.GetComponent<Ball>().speed += 0.05f;
            }
            else
            {
                Ball.GetComponent<Ball>().speed += 0.1f;
            }
        }
    }

    public void UpdateScore()
    {
        score++;
        text.text = score.ToString();
        Final.text = score.ToString();
        speedmod = true;
    }

    public void Reset()
    {
        score = 0;
        
        text.text =  score.ToString();
        Paddle.SetActive(true);
        Paddle.GetComponent<Paddle>().enabled = true;
        Ball.SetActive(true);
        Ball.GetComponent<Ball>().resetpos();
        
        Paddle.GetComponent<Paddle>().resetpos();
        RetryButton.SetActive(false);
        Left.SetActive(true);
        Right.SetActive(true);
        FindObjectOfType<AudioManager>().playRetry();
        HSG.gameObject.SetActive(false);


    }

    public void LOSE()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        HSG.gameObject.SetActive(true);
        HSG.text = "HighScore " + PlayerPrefs.GetInt("HighScore").ToString();

        Paddle.GetComponent<Paddle>().enabled = false;
        RetryButton.SetActive(true);
        Left.SetActive(false);
        Right.SetActive(false);
        FindObjectOfType<AudioManager>().playLose();
        Final.enabled = true;
       
        Ball.SetActive(false);
        Paddle.SetActive(false);
        
    }

    public void Play()
    {
        TitleScreen.SetActive(false);
        GameplayObj.SetActive(true);
        FindObjectOfType<AudioManager>().playRetry();
    }
}
