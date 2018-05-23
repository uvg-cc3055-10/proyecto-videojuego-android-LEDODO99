using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerOfScenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }
    public void onInstructionButton2Press()
    {
        SceneManager.LoadScene("Test_1");
    }
    public void onInstructionButton1Press()
    {
        SceneManager.LoadScene("Instructions_2");
    }
    public void mainMenuPlayButtonPress()
    {
        SceneManager.LoadScene("Instruction_1");
    }
    public void GameOverButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ClearedLvlButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void onBestRunButtonPress()
    {
        SceneManager.LoadScene("HighScore");
    }
    public void onBackToMainMenuButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
    }
}