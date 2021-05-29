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
        if(!hasStarted)
        {
            lockPaddle();
            launch();
        
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(xv, yv);
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
