using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    //state variables
    [SerializeField] TMPro.TextMeshProUGUI currentScore;
    [SerializeField] TMPro.TextMeshProUGUI goalieCurrentScore;

    //cached ref
    GameScore gameScore;


    public void Start() {
        gameScore = FindObjectOfType<GameScore>();


    }

    private void Update()
    {

    }


    public void LoadNextScene() {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void LoadStartScene() {

        SceneManager.LoadScene(0);

    }


    public void QuitGame() {

        Application.Quit();


    }

    public void loadFirstLevel() {

        SceneManager.LoadScene("Level 1");

    }




    //if there is no scene to load, load win or lose screen(wip)
    public void LoadWinOrLose() {

        if  (FindObjectOfType<GameScore>().currentScore > FindObjectOfType<GameScore>().goalieCurrentScore)
        {
            SceneManager.LoadScene("You Win");
         
        }

        else {
            SceneManager.LoadScene("You Lose");
          
        }

    }





}







