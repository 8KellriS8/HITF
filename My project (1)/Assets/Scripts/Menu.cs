using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public int menuScene;
	[SerializeField] public GameObject panel;
	public bool isSettingsVisible = false;
	public int gameScene;
	public int difficulty = 1; //1-easy 2-medium 3-hard

	public void ToMenu()
	{
		SceneManager.LoadScene(menuScene, LoadSceneMode.Single);
	}
	public void ToGame()
	{
		SceneManager.LoadScene(gameScene, LoadSceneMode.Single);
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
}
