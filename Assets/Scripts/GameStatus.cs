using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{
    int[] scores = { 0, 36 * 83, (33 + 36) * 83, (36 + 33 + 76) * 83, (33 + 36 + 76 + 60) * 83 };
    [Range(0.1f, 10f)] [SerializeField] float speed = 1f;
    [SerializeField] int pointesPerBlock = 83;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoretext;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = currentScore.ToString();
    }
    public void Awake()
    {  
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        { 
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = speed;
    }
    public void AddToScore()
    {   
        currentScore += pointesPerBlock;
        scoretext.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public void LevelInit(int x)
    {
        currentScore = x;
    }
}