using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToStart : MonoBehaviour
{
    private Vector2 touchposition;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchposition = touch.position;
            }
        }

        if (touchposition.y > 300)
        {
            SceneManager.LoadScene(2);
        }

    }
}
