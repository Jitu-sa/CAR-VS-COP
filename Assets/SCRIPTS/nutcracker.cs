using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nutcracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(1);
    }
}
