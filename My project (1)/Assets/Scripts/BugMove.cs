using UnityEngine;

public class BugMove : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public bool hasReached = true;
    public Vector3[] waypoints = new Vector3[6];
    public int currentWay = 0;
    public GameObject bug;
    
    void Update()
    {
        if (hasReached) return;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWay]/5, speed * Time.deltaTime);
        float stoppingDistance = 1f;
        bug.transform.LookAt(waypoints[currentWay]/5);
        bug.transform.Rotate(0, 180, 0);
        if (Vector3.Distance(transform.position, waypoints[currentWay] / 5) < stoppingDistance)
        {
            OnTargetReached();
        }
    }

    void OnTargetReached()
    {
        hasReached = true;
        currentWay += 1;
        Debug.Log("1");
    }
}
