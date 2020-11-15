using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoGoalCollider : MonoBehaviour
{
    //cached reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameScore>().goalieAddToScore();
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
