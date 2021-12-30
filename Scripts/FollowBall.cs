using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform ball;
    public float speed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.GetComponent<BallBehaviour>().gameStarted)
        {
            float yBall = 0;

            if (transform.position.y < ball.position.y)
            {
                yBall = transform.position.y + speed * Time.deltaTime;
            }
            else if (transform.position.y > ball.position.y)
            {
                yBall = transform.position.y - speed * Time.deltaTime;
            }

            transform.position = new Vector3(transform.position.x, Mathf.Clamp(yBall, -3.8f, 3.8f), transform.position.z);
        }
    }
}
