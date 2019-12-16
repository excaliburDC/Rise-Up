using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public GameObject instructionPanel;
    public GameObject menu;
    public Text countdownText;
    public Text distanceText;
    public GameObject fuelUI;
    public Image fuelBar;
    public GameObject gameOverText;
    
    
    

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        //Instantiate(canvas);
        DontDestroyOnLoad(gameObject);
        
    }

  

    public void StartGame()
    {
        if (GameManager.instance.isGameMenu)
        {
            SceneManager.LoadScene("Game Scene");

            menu.gameObject.SetActive(false);
            
            fuelUI.SetActive(true);
            fuelBar.enabled = true;
            GameManager.instance.isGameMenu = false;
        }
    }

 


    public void GoBackToMenu()
    {

        GameManager.instance.isGameMenu = true;
        GameManager.instance.gameStarted = false;
        gameOverText.SetActive(false);
        fuelUI.SetActive(false);
        //fuelBar.enabled = false;
        SceneManager.LoadScene("Menu Scene");
        menu.SetActive(true);
        GameManager.instance.distanceCovered = 0f;
        distanceText.text = " ";
        GameManager.instance.gameOver = false;
        GameManager.instance.scrollSpeed = 2f;
    }


    public void QuitGame()
    {
        //if (isGameMenu)
        //{
    #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
    #else
                                 Application.Quit();
    #endif
        //}

    }    


}
