using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    private readonly string[] Texts = {
        "Вы проводите в лесу ещё некоторое время, однако ваши поиски не увенчались успехом.\nС камнем на сердце вы выходите из леса живым, но, кажется, всё было зря.\n\nМожет быть, если бы вы были быстрее, всё было бы иначе...",
        "После долгих поисков вы находите костёр и слышите знакомый голос,\nваш сын окликает вас, чтобы вы его заметили. Он подбегает к вам радостный,\nно тут же меняется в лице, чтобы извиниться за свои действия.\nНо времени на это нет, вы хватаете его за руку и выводите из этого проклятого места.\nВсё наконец-то закончилось"
    };
    public TextMeshProUGUI Text1; // Ссылка на компонент текста

    private void Awake()
    {
        UpdateButtonText();
    }
    private void UpdateButtonText()
    {
        if (PublicInfo.good_ending) Text1.text = Texts[1];
        else Text1.text = Texts[0];
    }
}
