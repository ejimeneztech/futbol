using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalie : MonoBehaviour
{
    //set speed
    [SerializeField] float speed = 1.0f;

    //set values of left and right positions
    [SerializeField] float moveLeft = 5;
    [SerializeField] float moveRight = 11;

    //set the position on the Y axis for the goalie
    [SerializeField] float goalieYCor = 8.75f;

    //state
    Vector2 pos1;
    Vector2 pos2;
   

    void Start()
    {
        pos1 = new Vector2(moveLeft,goalieYCor);
        pos2 = new Vector2(moveRight,goalieYCor);
    }

    // Update is called once per frame
    void Update()
    {
        //Linearly interpolates between pos1 and pos2 by t
        transform.position = Vector2.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
