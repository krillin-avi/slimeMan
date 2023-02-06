using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    Collider2D collider2d;
    float horizontal;
    float vertical;

    public TextMeshProUGUI scoreText; 
    public int score;
    public TextMeshProUGUI livesText;
    private int lives;
    private int win;
    // Audio Clip
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        score = 0;
        SetScoreText();
        lives = 3;
        SetlivesText();
        
    }

    void Update()
    {
       // Player Movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }

    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);

    }
    public void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "SimeMan")
        {
            if (score == 6950)  //6900
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else if (sceneName == "SimeMan Level 2")
        {
            if (score == 6750) //6700
            {
                if(gameObject.CompareTag("Player"))
                {
                    SetWinText();
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pellet")
        {
            audioSource.Play();  
        }
        if (collision.collider.tag == "Enemy")
        {
            lives = lives -1;
            SetlivesText();
        }
        
    }
    void SetlivesText()
    {
        livesText.text = "Lives: " + lives.ToString();

        if(lives <= 0) 
        {
            if(gameObject.CompareTag("Player"))
            {
                SetWinText();
            }
        }
    }
    
    void SetWinText()
    {
        if(score == 6700)
        {
            SceneManager.LoadScene(3);
        }
        else if( lives <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }
            
}
