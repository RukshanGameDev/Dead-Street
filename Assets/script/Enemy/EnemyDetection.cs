using UnityEngine;
public class EnemyDetection : MonoBehaviour
{
    [SerializeField]
    private float MaindetectionRadius = 10f;
    [SerializeField]
    private float L1detectionRadius = 5f;
    [SerializeField]
    private Transform player;
    public bool CanDetectPlayer()
    {
        if (player == null)
            return false;
        float distance =
            Vector3.Distance(
            transform.position,
            player.position);
        return distance <= MaindetectionRadius;
    }
    public bool L1CanDetectPlayer()
    {
        if (player == null)
            return false;
        float distance =
            Vector3.Distance(
            transform.position,
            player.position);
        return distance <= L1detectionRadius;
    }
    public Transform GetPlayer()
    {
        return player;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(
        transform.position,
        MaindetectionRadius);
        Gizmos.DrawWireSphere(
        transform.position,
        L1detectionRadius);
    }
}