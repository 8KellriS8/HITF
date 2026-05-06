using UnityEngine;

public class BugMove : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    private bool hasReached = true;
    public Vector3[] waypoints = new Vector3[6];
    public int currentWay = 0;

    
    void Update()
    {
        if (hasReached) return;

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWay], speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            OnTargetReached();
        }
    }

    void OnTargetReached()
    {
        hasReached = true;
        currentWay += 1;
        Debug.Log("Объект пришел в цель!");
    }
}
