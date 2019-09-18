using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SnakeController : MonoBehaviour
{

    public float repeatRateDelay;

    public float moveSpeed;
    Vector3 movement = Vector2.up;

    public List<Transform> tail;

    bool ate = false;

    public GameObject tailPrefab;
    public VirtualJoystick joystick;

    [SerializeField]
    private bool walled;
    public Transform wallCheckObj;
    public float wallCheckRadius;
    public LayerMask whatIswall;

    public GameObject greenTile;
    public AudioClip eat;



    void Start()
    {
        InvokeRepeating("Move", .1f, repeatRateDelay);
        tail = new List<Transform>();
        GetComponent<AudioSource>().clip = eat;
    }


    void Update()
    {
        //Better than OnTiggerEnter2d() checking because continous draggin on hitting wall cause snake to walk over the wall :)
        walled = Physics2D.OverlapCircle(wallCheckObj.position, wallCheckRadius, whatIswall);
        
        // Setting speed range
        if (moveSpeed < 40)
        {
            moveSpeed = 40; 
        }
        if(moveSpeed > 100)
        {
            moveSpeed = 100;
        }
    }



    private void Move()
    {
        //if snake hit a wall
        if (walled)
        {
            // when hitting the border mirror the movement
            //   |0<<<<<< to >>>>>>0    
            if (tail.Count > 0)
            {
                transform.position = (tail[tail.Count - 1]).position;
                tail.Reverse();     //also reverse the transfrom of all tail else gap forms
            }
            //moveDir *= -1;   //so that the mirror movement happens else the snake goes to the last moveDir position
            movement *= -1;
            transform.Translate(movement * moveSpeed * Time.deltaTime);  
        }


        //get current positin of the snake head
        Vector2 currPos = transform.position;

        //SNAKE MOVEMENT
        // transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        if (joystick.Horizontal() > 0.7f || joystick.Horizontal() < -0.7f)
        {
            movement = Vector2.zero;
            movement = new Vector2(joystick.Horizontal(), 0f);
        }
        else if (joystick.Vertical() > 0.5f || joystick.Vertical() < -0.5f)
        {
            movement = Vector2.zero;
            movement = new Vector2(0f, joystick.Vertical());
        }
       


        if (!walled)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }


        //IF SNAKE EAT PIZZA ;)
        if (ate)
        {
            //spawn the body of snake 
            GameObject body = (GameObject)Instantiate(tailPrefab, currPos, transform.rotation);

            //add body to the begining of the lise i.e at 0
            tail.Insert(0, body.transform);
            ate = false;
        }
        //if snake already has a body then rearranging on each loop
        else if (tail.Count > 0)
        {
            //Add the current position of the snake head to the end of the tail
            tail.Last().position = currPos;

            // Add above added current position of the snake head to the begining of the list
            tail.Insert(0, tail.Last());
            //Remove the above added current position from the end of the tail
            tail.RemoveAt(tail.Count - 1);
        }

        //showing green tile path through which the snake went
        GameObject tile = (GameObject)Instantiate(greenTile, transform.position, Quaternion.identity);
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        // to check whether the snake ate the food
        if (other.tag == "Food")
        {
            ate = true;
            ScoreManager.AddPoints(FindObjectOfType<SpawnPizza>().points);

            //playing audio attached to other wont work as we are deleting the game object
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }

        // UNCOMMENT THE BELOW CODE TO
        // 1) WHEN SNAKE HITS ANY OF ITS BODY PART ITS BODY IS REVERESED
        // 2) IF THE SNAKE IS NOT LYING STRIGHT THEN THE SNAKE CAN GO IN REVERSE ON BUTTON CLICK

        // IF THE BELOW CODE IS UNCOMMENTED THEN WHEN THE SNAKE IS LYING STRAIGHT IT CANNOT GO REVERSE
       /* else if (other.tag == "Tail")
        {
            if (tail.Count > 0)
            { 
                //for opp movement head goes to tail
                //condition so then when hitting the wall it wont got right
                    if (transform.position.x != tail[0].position.x ||
                        other.transform.position.y != tail[0].position.y)
                    {
                         Debug.Log("Neck Hit>>>>>>>>>>");
                         transform.position = (tail[tail.Count - 1]).position;
                          tail.Reverse();
                          movement *= -1;
                          transform.Translate(movement * moveSpeed * Time.deltaTime);
                    }                            
            }
        }
        */
    }
}
