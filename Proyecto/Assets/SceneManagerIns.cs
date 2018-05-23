using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerIns : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.intance.GameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (GameController.intance.ClearedLvl)
        {
            float time = GameController.intance.time;
            if (time < PlayerPrefs.GetFloat("bestTime"))
                PlayerPrefs.SetFloat("bestTime", time);
            SceneManager.LoadScene("ClearedLvl");
        }
    }
    public void onInstructionButton2Press()
    {
        SceneManager.LoadScene("Test_1");
    }
    public void onInstructionButton1Press()
    {
        SceneManager.LoadScene("Instruction_2");
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
