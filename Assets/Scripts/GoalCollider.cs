using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCollider : MonoBehaviour
{
    //cached reference
    SceneLoader sceneLoader;
    

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    
    }


    //create new script 'Round' to reuse this method in AutoGoalCollider.cs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameScore>().AddToScore();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 5"))
        {
            sceneLoader.LoadWinOrLose();
        }
        else
        {
            sceneLoader.LoadNextScene();
        }


       
    }
}


