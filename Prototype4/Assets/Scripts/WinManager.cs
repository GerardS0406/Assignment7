/*
* Gerard Lamoureux
* Assignment 7
* Handles Game Over and Win Text/Restart
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool win = false;
    public GameObject gameOverText;

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
            if(win)
            {
                gameOverText.GetComponent<Text>().text = "You Win!\nPress R to Restart!";
            }
            else
            {
                gameOverText.GetComponent<Text>().text = "You Lose!\nPress R to Restart!";
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
