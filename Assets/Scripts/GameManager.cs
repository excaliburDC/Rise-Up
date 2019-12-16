using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float scrollSpeed;
    public bool gameOver = false;
    public bool gameStarted = false;
    public bool isGameMenu = true;
    public float startingFuel = 100f;
    public float distanceCovered = 0f;
    private int n = 1;
    




    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        
    }

   

    // Update is called once per frame
    void Update()
    {
        DistanceCovered();

        if(gameOver==true && Input.GetMouseButtonDown(0))
        {
            MenuManager.instance.GoBackToMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void DistanceCovered()
    {
        if (gameOver)
            return;

        if(gameStarted==true)
        {
            
            distanceCovered += Time.deltaTime * scrollSpeed * 2f;
            MenuManager.instance.distanceText.text = "Distance : " + Mathf.Round(distanceCovered).ToString() + " ft";
            ChangeScrollSpeed();

        }
       

    }

   void ChangeScrollSpeed()
    {
        if(distanceCovered > (150f * n * n))
        {
            scrollSpeed+=0.5f;
            n++;
            PoolManager.pInstance.spawnRate--;
            BirdPool.bInstance.birdSpawnRate--;
            if (PoolManager.pInstance.spawnRate < 1)
                PoolManager.pInstance.spawnRate = 1;

            if (BirdPool.bInstance.birdSpawnRate <= 3)
                BirdPool.bInstance.birdSpawnRate = 3;
        }
       
    }

    public void GameOver()
    {
        MenuManager.instance.gameOverText.SetActive(true);
        gameOver = true;
    }
}
