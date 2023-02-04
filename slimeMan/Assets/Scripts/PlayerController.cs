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

    // Audio Clip
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        score = 0;
        SetScoreText();
    }

    void Update()
    {
       // Player Movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else if (sceneName == "SimeMan Level 2")
        {
            if (score == 6700)
            {
                print("you win");
                //display win text
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.collider.tag == "Pellet")
        {
            audioSource.Play();
            
        }
   }

    


}
