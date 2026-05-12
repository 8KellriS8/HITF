using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 100f;
    public float noise = 0f;
    private Vector3 lastPosition;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, lastPosition);
        if (distance > 0.01)
        {
            noise += 0.1f;
        }
        lastPosition = transform.position;
        noise *= 0.99f;
        //Debug.Log(noise);
    }
    void Start()
    {
        
    }

}
