using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BalloonController : MonoBehaviour
{
    public float upSpeed;
    public float yPosition;
    int score = 0;
    float xValue = 2.5f;

    public TextMeshProUGUI scoreText;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > yPosition)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(0, upSpeed, 0);
    }

    private void OnMouseDown()
    {
        score++;
        scoreText.text = score.ToString();  
        audioSource.Play();
        ResetPosition();

    }

    void ResetPosition()
    {
        float randomX = Random.Range(-xValue, xValue);
        transform.position = new Vector2(randomX, -yPosition);
    }
}
