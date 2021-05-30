using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPos : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    [SerializeField] float xv;
    [SerializeField] float yv;
    [SerializeField] AudioClip[] ballSounds;
    AudioSource myAudioSource;
    Rigidbody2D MyRigidBody2D;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        MyRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            lockPaddle();
            launch();

        }
        else if(hasStarted)
        {
            Vector2 temp = new Vector2(0, 0);
            temp.x = MyRigidBody2D.velocity.x;
            temp.y = MyRigidBody2D.velocity.y;
            if (temp.x < 6 && temp.x > 0)
            {
                temp.x += 6;
                if (temp.x > 10)
                {
                    temp.x = 10;
                }
            }
            if (temp.x > -6 && temp.x < 0)
            {
                temp.x -= 6;
                if (temp.x < -10)
                {
                    temp.x = -10;
                }
            }
            if (temp.y < 6 && temp.y > 0)
            {
                temp.y += 6;
                if (temp.y > 10)
                {
                    temp.y = 10;
                }
            }
            if (temp.y > -6 && temp.y < 0)
            {
                temp.y -= 6;
                if (temp.y < -10)
                {
                    temp.y = -10;
                }
            }
            MyRigidBody2D.velocity = temp;
            Debug.Log(MyRigidBody2D.velocity);
        } 
    }
    void lockPaddle()
    {
        Vector2 paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlepos + paddleToBallVector;
        
    }
    void launch()
    {

        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            MyRigidBody2D.velocity = new Vector2(xv, yv);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Vector2 velocityTweak = new Vector2(Random.Range(0, 0.2f), Random.Range(0, 0.2f));
        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
         //   MyRigidBody2D.velocity += velocityTweak;

        }
    }
}
