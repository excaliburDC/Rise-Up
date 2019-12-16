using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public MobileControls mobileControls;
    private bool isBlown = false;
    private Animator anim;
    private float fuel;
    private Vector2 movePos=new Vector2(-3f,-1.484f);





    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fuel = GameManager.instance.startingFuel;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameStarted==true)
        {
            DecreaseFuel();
            if (isBlown == false)
            {
                ChoosePlatformForControls();
                BoundFromGoingOffScreen();
            }
        }
      
       

    }

    private void ChoosePlatformForControls()
    {

#if UNITY_STANDALONE || UNITY_WEBPLAYER
         StandaloneInput();  
#else
         MobileMovement();
#endif
    }

    private void StandaloneInput()
    {
        this.transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime,
            Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime, 0);
    }

    private void MobileMovement()
    {
        if (mobileControls.swipeLeft)
            movePos += Vector2.left;

        if (mobileControls.swipeRight)
            movePos += Vector2.right;

        if (mobileControls.swipeUp)
            movePos += Vector2.up;

        if (mobileControls.swipeDown)
            movePos += Vector2.down;


        transform.position = Vector2.Lerp(transform.position, movePos, moveSpeed * Time.deltaTime);


        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
        //    if (touch.phase == TouchPhase.Moved)
        //    {

        //        // get the touch position from the screen touch to world point
        //       Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,10));



        //        // lerp and set the position of the current object to that of the touch, but smoothly over time.
        //         transform.position = Vector3.Lerp(transform.position, touchedPos, moveSpeed * Time.deltaTime);
        //    }
        //}


    }





    private void BoundFromGoingOffScreen()
    {
        //Prevents the balloon from going offscreen 
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

    }

    public void DecreaseFuel()
    {
        if (GameManager.instance.gameOver)
            return;

        if(GameManager.instance.gameStarted==true)
        {
            if(fuel>100)
                fuel = GameManager.instance.startingFuel;

            fuel -= Time.deltaTime;
            MenuManager.instance.fuelBar.fillAmount = fuel / GameManager.instance.startingFuel;

            if (fuel <= 0)
            {
                isBlown = true;
                anim.SetTrigger("Boom");
                GameManager.instance.GameOver();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Box")
        {
            isBlown = true;
            anim.SetTrigger("Boom");
            GameManager.instance.GameOver();
        }

        else if (col.gameObject.tag == "Bird")
        {
            isBlown = true;
            anim.SetTrigger("Boom");
            GameManager.instance.GameOver();
        }

        else if(col.gameObject.tag=="Collectible")
        {
            col.gameObject.SetActive(false);
            fuel += 10f;
            MenuManager.instance.fuelBar.fillAmount = fuel;
            Debug.Log("Fuel Collected");
        }

      
    }
}
