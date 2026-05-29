using UnityEngine;
using TMPro; // Обязательно для работы с TextMeshPro
using UnityEngine.Audio;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Массив с текстами для циклического переключения
    private readonly string[] difficultyTexts = {
        "Легко",
        "Нормально",
        "Сложно"
    };
    [SerializeField] private AudioMixer myAudioMixer;
    [SerializeField] private Slider volumeSlider;
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
        PublicInfo.difficulty = 1+currentIndex;
        
        // Обновляем текст на кнопке
        UpdateButtonText();
    }
    public void SetVolume(float sliderValue)
    {
        // Преобразуем линейное значение слайдера в логарифмическое для dB
        float dB = sliderValue;
    
        // Если слайдер может быть равен 0, вручную ставим -80 dB, чтобы звук полностью пропадал
        if (dB == -20) dB = -80;
    
        myAudioMixer.SetFloat("MasterValue", dB);
    }
    private void UpdateButtonText()
    {
        if (buttonText != null)
        {
            buttonText.text = difficultyTexts[currentIndex];
        }
    }
}