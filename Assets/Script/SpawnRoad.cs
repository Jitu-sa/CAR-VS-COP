using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    [SerializeField] GameObject[] Roads;
    [SerializeField] int YSpawnPoint = 0;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            foreach (var road in Roads)
            {
                if (!road.activeInHierarchy)
                {
                    UpdateRoadPosition(road);
                    return;
                }
            }
        }
    }

    void UpdateRoadPosition(GameObject road)
    {
        if (IsRotationBetween(90, 270))
        {
            YSpawnPoint -= 13;
        }
        else
        {
            YSpawnPoint += 13;
        }

        road.transform.position = new Vector3(0, YSpawnPoint, 0);
        road.SetActive(true);
    }

    bool IsRotationBetween(float min, float max)
    {
        float rotation = Mathf.Abs(Mathf.RoundToInt(transform.rotation.eulerAngles.z)) % 360;
        return rotation > min && rotation < max;
    }
}
