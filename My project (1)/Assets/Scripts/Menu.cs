using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
	public VRScreenFader fader;
	public int menuScene;
	[SerializeField] public GameObject panel;
	public bool isSettingsVisible = false;
	public int gameScene;
	public int difficulty = 1; //1-easy 2-medium 3-hard

	public void ToMenu()
	{
		StartCoroutine(Menu1());
	}
	public void ToGame()
	{
		StartCoroutine(GameStart());
	}
	public void ToEnd()
	{
		SceneManager.LoadScene(2, LoadSceneMode.Single);
	}
	public void Exit()
	{
		Application.Quit();
	}
	public void Settings()
	{
		isSettingsVisible = (!isSettingsVisible);
		panel.SetActive(isSettingsVisible);
	}
	IEnumerator GameStart()
	{
		fader.FadeOut(1f); // Ёкран гаснет за 0.5 секунды
		PublicInfo.ending = true;
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
	}
	IEnumerator Menu1()
	{
		fader.FadeOut(1f); // Ёкран гаснет за 0.5 секунды
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(menuScene, LoadSceneMode.Single);
	}
}
