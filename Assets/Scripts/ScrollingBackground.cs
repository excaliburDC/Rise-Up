using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollingBackground : MonoBehaviour
{
    
    private int timer=3;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        CheckifinMenu();
    }

    void CheckifinMenu()
    {
        if (GameManager.instance.isGameMenu == true)
            BeginScrolling();


        else if (GameManager.instance.isGameMenu == false && GameManager.instance.gameStarted==false)
        {
            StartCoroutine(CountDown(timer));
           
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameStarted == true)
            BeginScrolling();
        

        if (GameManager.instance.gameOver==true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    void BeginScrolling()
    {
      
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, -GameManager.instance.scrollSpeed);
    }

    IEnumerator CountDown(int seconds)
    {
        int count = seconds;
        while(count>0)
        {
            MenuManager.instance.countdownText.fontSize = 300;
            MenuManager.instance.countdownText.text = count.ToString();
            yield return new WaitForSeconds(1f);
            --count;
            if (count == 0)
            {
                MenuManager.instance.countdownText.fontSize = 150;
                MenuManager.instance.countdownText.text = "Let's Rise !";
                yield return new WaitForSeconds(1f);
            }
                

        }

        MenuManager.instance.countdownText.text = " ";
        GameManager.instance.gameStarted = true;
    }
}
