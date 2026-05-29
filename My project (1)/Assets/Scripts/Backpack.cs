using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
public class Backpack : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    public void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public void OnEnable()
    {
        // Подписываемся на событие захвата
        grabInteractable.selectEntered.AddListener(DestroyObject);
    }

    public void OnDisable()
    {
        // Отписываемся, чтобы избежать утечек памяти
        grabInteractable.selectEntered.RemoveListener(DestroyObject);
    }

    public void DestroyObject(SelectEnterEventArgs args)
    {
        // Удаляем объект из сцены
        object1.SetActive(false);
        playerScript.noise += 20f;
        playerScript.health += Random.Range(10f, 40f);
        if (playerScript.health > 100) playerScript.health = 100;
    }
    public PlayerStats playerScript;
    public GameObject object1;
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("MainCamera");
        playerScript = playerObject.GetComponent<PlayerStats>();
    }
}
