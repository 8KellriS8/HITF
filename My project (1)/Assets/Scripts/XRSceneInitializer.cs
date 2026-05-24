using UnityEngine;
using UnityEngine.SceneManagement;

public class XRSceneInitializer : MonoBehaviour
{
    [Header("Ссылки на компоненты")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private GameObject locomotionSystem;

    void OnEnable()
    {
        // Подписываемся на событие загрузки сцены
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Отписываемся при уничтожении объекта
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Включаем Character Controller
        if (characterController != null)
        {
            characterController.enabled = true;
            Debug.Log($"Character Controller успешно включен в сцене: {scene.name}");
        }

        // Включаем дочерний объект Locomotion
        if (locomotionSystem != null)
        {
            locomotionSystem.SetActive(true);
            Debug.Log($"Locomotion System успешно включена в сцене: {scene.name}");
        }
    }
}