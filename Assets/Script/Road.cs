using UnityEngine;

public class Road : MonoBehaviour
{
    GameObject Target;

    void Start()
    {
        Target = GameObject.FindWithTag("Player");
    }
    public void OnRaycastHit()
    {
        if (Mathf.Abs(Target.transform.position.y - transform.position.y) >13)
        {
            gameObject.SetActive(false);
        }
    }
}
