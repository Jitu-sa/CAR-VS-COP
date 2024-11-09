using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class player : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float speed = 5.0f;
    private int score;
    private int highscore;
    private bool gameIsOver = false;
    public TextMeshProUGUI scoreText; // Reference to a Text component to display the score
    private Vector2 touchposition;

    private void Start()
    {
        // Initialize the score and start the score update coroutine
        StartCoroutine(UpdateScore());
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchposition = touch.position;
            }
        }

        if (touchposition.y < 2000)
        {
            playermovement();
        }
    }

    IEnumerator UpdateScore()
    {
        while (!gameIsOver)
        {
            // Increase the score by 1 every second
            score++;
            // Update the score text
            scoreText.text = score.ToString();

            yield return new WaitForSeconds(1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//game end logic 
    {
        if (collision.gameObject.tag == "crate")
        {
            savefinalscore();
            SceneManager.LoadScene(3);
        }
    }

    private void savefinalscore()//saving score and highscore
    {
        PlayerPrefs.SetInt("finalscore", score);
        if (score > PlayerPrefs.GetInt("highscore", 0))
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }

    void playermovement()
    {
        // Get the current mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Make sure the Z-coordinate is appropriate for 2D

        // Clamp the X position of the mouse within the specified range
        float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);

        // Move the game object towards the clamped X position
        Vector3 targetPosition = new Vector3(clampedX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

}
