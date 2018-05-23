using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController intance;
    public float time=0;
    public float PlayerLife = 100;
    public int puntos = 0;
    public bool GameOver = false;
    public bool ClearedLvl = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (PlayerLife <= 0)
        {
            GameOver = true;
        }
        if (GameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (ClearedLvl)
        {
            SceneManager.LoadScene("ClearedLvl");
        }
    }
    public void getHit()
    {
        PlayerLife -= 10;
    }

}
