using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Creates field to adjust screen width * unity world units
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float min_X = 1f;
    [SerializeField] float max_X = 16f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        playerPos.x = Mathf.Clamp(mousePosInUnits, min_X, max_X);
        transform.position = playerPos;
    }
}
