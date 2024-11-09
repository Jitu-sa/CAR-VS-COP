using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        Movement();
        Raycasting();
        if (Input.touchCount > 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    void Movement()
    {
        transform.Translate(Vector2.up * Time.deltaTime);
    }

    void Raycasting()
    {
        Vector2 rayDirection = -transform.up;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, rayDirection, 100, LayerMask.GetMask("RoadLayer"));
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
