using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
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




    //destroy the score object when the win or lose scenes load (look into onEnable functions)
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // here you can use scene.buildIndex or scene.name to check which scene was loaded
        if (scene.name == "You Win" || scene.name == "You Lose")
        {
            // Destroy the gameobject this script is attached to
            Destroy(gameObject);
        }
    }
    


}
