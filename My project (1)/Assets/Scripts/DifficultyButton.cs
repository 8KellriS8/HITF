using UnityEngine;
using TMPro; // Обязательно для работы с TextMeshPro

public class DifficultyButton : MonoBehaviour
{
    // Массив с текстами для циклического переключения
    private readonly string[] difficultyTexts = {
        "Легко",
        "Нормально",
        "Сложно"
    };

    private int currentIndex = 1; // Индекс текущей сложности
    private TextMeshProUGUI buttonText; // Ссылка на компонент текста

    private void Awake()
    {
        // Автоматически находим компонент текста внутри кнопки или на ней самой
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        
        // Устанавливаем начальный текст при старте
        UpdateButtonText();
    }

    // Этот метод нужно привязать к событию OnClick кнопки в инспекторе
    public void SwitchDifficulty()
    {
        // Увеличиваем индекс на 1, а оператор % возвращает его в 0 при достижении конца массива
        currentIndex = (currentIndex + 1) % difficultyTexts.Length;
        
        // Обновляем текст на кнопке
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        if (buttonText != null)
        {
            buttonText.text = difficultyTexts[currentIndex];
        }
    }
}