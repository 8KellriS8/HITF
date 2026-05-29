using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabParenter : MonoBehaviour
{
    public PlayerStats playerScript;
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("MainCamera");
        playerScript = playerObject.GetComponent<PlayerStats>();
    }
    public void OnGrab(SelectEnterEventArgs args)
    {
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
        playerScript.noise += 20f;
    }
    public void OnUngrab(SelectExitEventArgs args)
    {
        args.interactableObject.transform.SetParent(null);
    }
}
