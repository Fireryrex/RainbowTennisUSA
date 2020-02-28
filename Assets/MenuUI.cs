using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuUI : MonoBehaviour
{
	public static bool isGamePaused = false;
	public GameObject pauseMenuUI;

	public void Start()
	{
		//if(GetComponent<AudioManager>() != null)
			//GetComponent<AudioManager>().Play("music");
	}
    public void PlayGame(string level_to_load)
	{
		//Application.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);\
		//if (GetComponent<AudioManager>() != null)
			//GetComponent<AudioManager>().Play("button_click");
		SceneManager.LoadScene(level_to_load);
		
	}
	
	public void QuitGame()
	{
		print("Quiting..");
		//if (GetComponent<AudioManager>() != null)
			//GetComponent<AudioManager>().Play("button_click");
		Application.Quit();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if (isGamePaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}
	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		isGamePaused = true;
	}
	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		isGamePaused = false;
	}
	public void LoadMenu()
	{
		Time.timeScale = 1f;
		//if (GetComponent<AudioManager>() != null)
			//GetComponent<AudioManager>().Play("button_click");
		SceneManager.LoadScene("Menu");
		print("loading...");
	}
	
}
