using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject On_Game_Canvas;
    [SerializeField] GameObject Pause_And_resume_canvas;

    public void Pause()
    {
        On_Game_Canvas.SetActive(false);
        Time.timeScale = 0;
        Pause_And_resume_canvas.SetActive(true);
    }

    public void Resume()
    {
        Pause_And_resume_canvas.SetActive(false);
        On_Game_Canvas.SetActive(true);
        Time.timeScale = 1;
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
