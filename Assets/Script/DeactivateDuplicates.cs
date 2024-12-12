using UnityEngine;

public class DeactivateDuplicates : MonoBehaviour
{
    [SerializeField] private string targetTag = "Road"; // The tag to check for overlaps
    [SerializeField] private float overlapRadius = 0.1f; // Radius to detect overlaps

    void Update()
    {
        CheckAndDeactivateDuplicates();
    }

    void CheckAndDeactivateDuplicates()
    {
        // Find all game objects with the target tag
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (var obj in objectsWithTag)
        {
            // Skip inactive objects
            if (!obj.activeInHierarchy) continue;

            // Check for overlaps with other objects of the same tag
            Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(obj.transform.position, overlapRadius);

            int count = 0;
            foreach (var collider in overlappingColliders)
            {
                if (collider.CompareTag(targetTag) && collider.gameObject.activeInHierarchy)
                {
                    count++;
                    if (count > 1)
                    {
                        collider.gameObject.SetActive(false); // Deactivate duplicate
                    }
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        // Draw a sphere in the editor to visualize overlap radius
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, overlapRadius);
    }
}
