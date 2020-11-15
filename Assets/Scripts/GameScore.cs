using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    //config params
    [SerializeField] TMPro.TextMeshProUGUI playerScoreText;
    [SerializeField] TMPro.TextMeshProUGUI goalieScoreText;
    [SerializeField] TMPro.TextMeshProUGUI gameEndText;


    //state variables
    [SerializeField] public int currentScore = 0;
    [SerializeField] public int goalieCurrentScore = 0;

    //singleton pattern 
    private void Awake()
    {
        int gameScoreCount = FindObjectsOfType<GameScore>().Length;
        if (gameScoreCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    void Start()
    {
        displayScore(); //this is called twice: 1. when the scene starts and 2. after a point is scored
    }


    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = gameSpeed;
       
    }

    public void AddToScore()
    {
        currentScore++;
        displayScore();
    }


    public void goalieAddToScore()
    {
        goalieCurrentScore++;
        displayScore();
    }



    public void displayScore()
    {
        playerScoreText.text = currentScore.ToString();
        goalieScoreText.text = goalieCurrentScore.ToString();
    }



   


}
