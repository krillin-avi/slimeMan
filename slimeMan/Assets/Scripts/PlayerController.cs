using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public TextMeshProUGUI scoreText; 
    public int score;
    public TextMeshProUGUI livesText;
    private int lives;
    public TextMeshProUGUI WinText;
    private int win;
    // Audio Clip
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        score = 0;
        SetScoreText();
        lives = 3;
        SetlivesText();
        WinText.gameObject.SetActive(false);
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
            if (score == 6900)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
        else if (sceneName == "SimeMan Level 2")
        {
            if (score == 6700)
            {
                if(gameObject.CompareTag("Player"))
                {
                    Destroy(gameObject);
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
            //Destroy(collision.collider.gameObject);
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
                Destroy(gameObject);
                SetWinText();
            }
        }
    }
    
        void SetWinText()
    {
        if(score == 6700)
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "You Win: Press SPACE";
            if(Input.GetKeyDown(KeyCode.Space) == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }
        }
        else if( lives <= 0)
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "YOU DIED: Press SPACE";
            if(Input.GetKeyDown(KeyCode.Space) == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }
        }
    }

}
