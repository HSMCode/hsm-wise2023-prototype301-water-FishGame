using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script moves the icebergs in the background of the scene
public class background : MonoBehaviour
{
    public float moveSpeed;
    private float offset;
    private Vector3 startPos;


    private void Start()
    {
        //saves the start position so i can reset it later
        startPos = transform.position;
    }

    void Update()
    {
        //how far away is the current position from the start position?
        offset = startPos.x - (transform.position.x);

        //if the distance is greater than 50 the background movement has to start over
        if (offset > 50f)
        {
            //so reset the position to its start position
            transform.position = startPos;
        }
        // if the distance isnt greater than 50 yet (and the player is alive)
        else
        {
            //move the object forward (on the x- axis). The distance depends on how much time passed since the last frame and its speed
            transform.position = transform.position - transform.right * moveSpeed *2 * Time.deltaTime;
        }
        
    }

}
