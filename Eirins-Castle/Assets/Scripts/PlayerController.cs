using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float dodgeSpeed = 10f;
    public float dodgeDuration = 0.5f;
    private bool isDodging = false;

    //idle sprites = array 1
    //walking right sprites = array 2
    //walking left sprites = array 3
    //walking up sprites = array 4
    //walking down sprites = array 5
    //running right sprites = array 6
    //running left sprites = array 7
    //running up sprites = array 8
    //running down sprites = array 9
    //dodging inplace sprites = array 10
    //dodging right sprites = array 11
    //dodging left sprites = array 12
    //dodging up sprites = array 13
    //dodging down sprites = array 14
    //death right sprites = array 15
    //death left sprites = array 16

    public Sprite[][] spriteArray;
    private SpriteRenderer spriteRenderer;
    
    public float stamina = 25f;
    private bool hasStamina = true;
   
    public Heart[] hearts = new Heart[10];
    private int initialHeartCount = 3;
    private bool isAlive = true;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //set inital heart count and fill array with non-null values
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < initialHeartCount)
            {
                hearts[i].setNormStatus(1);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
    }

    //checks to see if player has any hearts left
    private bool lifeStatus(Heart[] currH)
    {
       return isAlive = currH[0].getNormStatus() <= 0 ? isAlive = false : isAlive = true;
    }

    //checks players stamina bar
    private bool staminaStatus(float currS)
    {
        return hasStamina = currS <= 0 ? hasStamina = false : hasStamina = true;
    }

    //decrease stamina
    private float decreaseStamina(float num)
    {
        stamina -= num;
        return stamina;
    }

    //increase Stamina
    private float increaseStamina(float num)
    {
        stamina += num;
        return stamina;
    }

    //healthPool

    //Player movement
    private void playerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            run(horizontalInput, verticalInput, 3f);

            if (Input.GetKey(KeyCode.LeftControl))
            {
                dodge();
            }
        }
        else
        {
            walk(horizontalInput, verticalInput);

            if (Input.GetKey(KeyCode.LeftControl))
            {
                dodge();
            }
        }

    }
    private void walk(float horizontalInput, float verticalInput)
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed;
        rb.velocity = movement;
    }


    //Allows player to run
    private void run(float horizontalInput, float verticalInput, float num)
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * (speed + num);
        rb.velocity = movement;
    }

    //player dodging
    private void leftDodge()
    {
        StartCoroutine(PerformDodge(11));
    }

    private void rightDodge()
    {
        StartCoroutine(PerformDodge(10));
    }

    private void upwardDodge()
    {
        StartCoroutine(PerformDodge(12));
    }

    private void downwardDodge()
    {
        StartCoroutine(PerformDodge(13));
    }

    private void dodgeInPlace()
    {
        StartCoroutine(PerformDodge(9));
    }

    private void dodge()
    {
        if(!isDodging)
        {
            if (Input.GetKey(KeyCode.W))
            {
                upwardDodge();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                downwardDodge();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rightDodge();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                leftDodge();
            }
            else
            {
                dodgeInPlace();
            }
        }
    }

    private IEnumerator PerformDodge(int num)
    {
        isDodging = true;

        float initialSpeed = speed;

        speed = dodgeSpeed;

        //use this once we have sprites to render
        //for(int i = 0; i < spriteArray[num].Length; i++)
        //{
        //    spriteRenderer.sprite = spriteArray[num][i];
        //    yield return new WaitForSeconds(dodgeDuration / spriteArray[num].Length);
        //}

        yield return new WaitForSeconds(dodgeDuration);

        speed = initialSpeed;

        isDodging = false;
    }

    public string heartsLeft()
    {
        float currHealth = 0;

        for(int i = 0; i < initialHeartCount; i++)
        {
            if(hearts[i].getNormStatus() == 1)
            {
                currHealth++;
            }
            else if(hearts[i].getNormStatus() == 0.5f)
            {
                currHealth += 0.5f;
            }
        }

        return currHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player has " + heartsLeft() + " hearts remaining!!!");

        if (lifeStatus(hearts))
        {
            playerMovement();

        }
        else
        {
            //play death animation
        }

    }
}
