using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public GameObject MainMenuUI, OptionsMenuUI;

	void Start()
	{
		Time.timeScale = 1;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	//Play
	public void PlayGame()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		SceneManager.LoadScene("Main");
		SceneManager.UnloadScene("Menu");
	}

	//Options
	public void OpenOptionsMenu()
	{
		OptionsMenuUI.SetActive(true);
		MainMenuUI.SetActive(false);
	}

	//Back
	public void ReturnToMainMenu()
	{
		OptionsMenuUI.SetActive(false);
		MainMenuUI.SetActive(true);
	}

	//Menu
	public void GameToMenu()
	{
		SceneManager.LoadScene("Menu");
		SceneManager.UnloadScene("Main");
	}

	//Quit
	public void QuitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
	}
}
