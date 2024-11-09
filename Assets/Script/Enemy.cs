using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 1.5f;
    [SerializeField] int RotateSpeed = 5;
    [SerializeField] GameObject Explosion;
    [SerializeField] Slider slider;
    [SerializeField] GameObject canvas;
    [SerializeField] Camera camera;
    [SerializeField] Transform HealthBarTarget;
    [SerializeField] Vector3 Offset;

    GameObject Target;
    int EnemyHealth ;

    void OnEnable()
    {
        Target = GameObject.FindWithTag("Player");
        EnemyHealth = 100;
    }
    void Update()
    {
        Movement();
        HealthBar();
    }

    void HealthBar()
    {
        slider.value = EnemyHealth;
        canvas.transform.rotation = camera.transform.rotation;
        canvas.transform.position = HealthBarTarget.position + Offset;
    }

    void Movement()
    {
        transform.position = Vector3.Lerp(transform.position, Target.transform.position, Time.deltaTime * PlayerSpeed);

        Vector3 direction = (Target.transform.position - transform.position).normalized;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        float currentAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime * RotateSpeed);
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth--;
            if (EnemyHealth<=0)
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
        Player.score++;
        gameObject.SetActive(false);
    }
}
