using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle: MonoBehaviour
{
    [SerializeField] float screenwidthInUnits=16f;
    [SerializeField] float max = 15f;
    [SerializeField] float min = 1f;

    // Update is called once per frame
    void Update()
    {
        float MouseposInUnits = Input.mousePosition.x / Screen.width * screenwidthInUnits;
        Vector2 Paddlepos = new Vector2(transform.position.x, transform.position.y);
        Paddlepos.x = Mathf.Clamp(MouseposInUnits, min, max);
        transform.position = Paddlepos; 
    }
}
