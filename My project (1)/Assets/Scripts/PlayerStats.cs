using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float health = 100f;
    public AudioSource audioSource_hit;
    public float noise = 0f;
    private Vector3 lastPosition;
    public VRScreenFader fader;
    public Menu menu;
    public bool inLight = true;
    public float timeRemaining = 12f;
    public Camera cam;
    public TextMeshProUGUI health_text;

    public void TakeHit(int power)
    {
        health -= 20*power;
        Vector3 originalPosition1 = cam.transform.localPosition;
        //Shake(1f, 1f, originalPosition1);
        audioSource_hit.Play();
    }
    public void CheckPosition()
    {
        if (inLight==false && timeRemaining <= 0.1f)
        {
            menu.ToMenu();
        }
    }
    void Update()
    {
        if (health_text!=null) health_text.text = Mathf.FloorToInt(health).ToString();
        float distance = Vector3.Distance(transform.position, lastPosition);
        if (distance > 0.01)
        {
            noise += 0.1f;
        }
        lastPosition = transform.position;
        noise *= 0.99f;
        //Debug.Log(noise);
        if (health<0)
        {
            StartCoroutine(Death());
        }
        if (inLight==false)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 12f;
        }
    }
    void Start()
    {
        cam = Camera.main;
        StartCoroutine(S());
        StartCoroutine(StartSixMinuteTimer());
    }
    IEnumerator S()
	{
        yield return new WaitForSeconds(0.5f);
		fader.FadeIn(3f);
	}

    IEnumerator StartSixMinuteTimer()
    {
        yield return new WaitForSeconds(360f); 
        PublicInfo.ending = false;
    }
    IEnumerator Death()
    {
        fader.FadeOut(0.2f);
        yield return new WaitForSeconds(0.2f);
        menu.ToMenu();
    }
    public void TriggerShake(float duration, float magnitude, Vector3 originalPosition)
    {
        StartCoroutine(Shake(duration, magnitude, originalPosition));
    }
    private IEnumerator Shake(float duration, float magnitude, Vector3 originalPosition)
    {
        duration = 0.3f;
        magnitude = 0.8f;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // Генерируем случайное смещение
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            cam.transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            // Ждем следующего кадра
            yield return null; 
        }

        // Возвращаем камеру строго на место
        cam.transform.localPosition = originalPosition;
    }
    public void End()
    {
        StartCoroutine(End1());
    }
    public IEnumerator End1()
    {
        fader.FadeOut(5f);
        yield return new WaitForSeconds(5f);
        menu.ToEnd();
    }

}
