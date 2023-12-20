using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 2f;

    
    void Update()
    {
       
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}