using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 1;
    [SerializeField] int RotateSpeed = 100;
    [SerializeField] GameObject Explosion;
    [SerializeField] Slider slider;
    [SerializeField] Image Fill;
    [SerializeField] TextMeshProUGUI ScoreText;

    int PlayerHealth = 50;
    public static int score;
    int highscore;
    float Volume;
    AudioSource AudioSource;

    void Start()
    {
        PlayerHealth = 50;
        score= 0;
        Fill.color = new Color(0, 1, 0.0113678f);
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Raycasting();
        Movement(); ;
        HealthBar();
        ScoreText.text=score.ToString();
    }

    void HealthBar()
    {
        slider.value = PlayerHealth;
        if (slider.value <= 25 )
        {
            Fill.color =new Color(0.8588235f, 0.5118588f, 0.5118588f);
        }
    }

    void Movement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Vector3 TwoDimensionTouch = new Vector3(touchPosition.x, touchPosition.y, 0);

            Vector3 direction = (TwoDimensionTouch - transform.position).normalized;

            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            float currentAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime * RotateSpeed);
            transform.rotation = Quaternion.Euler(0, 0, currentAngle);

            float PlayerPositionX = Mathf.Clamp(transform.position.x, -2.7f, 2.7f);
            float PlayerPositionY = transform.position.y;
            Vector3 PlayerPosition = new Vector3(PlayerPositionX, PlayerPositionY, 0);

            transform.position = Vector3.Lerp(PlayerPosition, TwoDimensionTouch, Time.deltaTime * PlayerSpeed);

        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerHealth--;
            if (PlayerHealth<=0)
            {
                StartCoroutine(ExplosionHandller());
            }
        }
    }

    IEnumerator ExplosionHandller()
    {
        Explosion.SetActive(true);
        yield return new WaitForSeconds(1);
        Explosion.SetActive(false);
        savefinalscore();
        Time.timeScale = 0;
        SceneManager.LoadScene(3);
    }

    void savefinalscore()
    {
        PlayerPrefs.SetInt("finalscore", score);
        if (score > PlayerPrefs.GetInt("highscore", 0))
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }

    void Raycasting()
    {
        Vector2 rayDirection =-transform.up;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, rayDirection,100, LayerMask.GetMask("RoadLayer"));
        Debug.DrawRay(transform.position, rayDirection * 60, Color.red);

        foreach (RaycastHit2D hit in hits)
        {
            Road road = hit.collider.GetComponent<Road>();
            if (road != null)
            {
                road.OnRaycastHit();
            }
        }
    }
}
