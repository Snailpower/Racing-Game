using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject player;
    public GameObject bullet;

    public Text ammoCount;
    public Text lifeCount;

    //Sets the car speed, ammo and lives
    public float speed = 10;
    public int lives = 8;
    public int ammo = 0;

    //sounds
    public AudioClip engine1;
    public AudioClip shot;
    public AudioClip crash2;
    public AudioClip pickup;
    public AudioClip youWin;
    public AudioClip youLose;


    // Use this for initialization
    void Start ()
    {
        SetCountText();

        EngineSound();
    }

    void EngineSound()
    {
        AudioSource audio = GetComponent<AudioSource>();

        //engine
        audio.loop = true;
        audio.clip = engine1;
        audio.PlayDelayed(0.0f);

    }

    // Update is called once per frame
    void Update ()
    {
        //audio initialisation
        AudioSource audio = GetComponent<AudioSource>();

        /*
         * Player Controls
         */

        //Movement
        float horizontal = Input.GetAxis("Horizontal");

        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        gameObject.transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);

        //limits the movement to between the walls
        float player_x = gameObject.transform.position.x;
        float player_y = gameObject.transform.position.y;
        float player_z = gameObject.transform.position.z;

        gameObject.transform.position = new Vector3(Mathf.Clamp(player_x, 2.0F, 48.0F), player_y, player_z);

        //Makes the player shoot with spacebar and reduces the ammo count by 1 when doing so (also plays a cool shooting sound)
        bool input = Input.GetButtonDown("Fire");

        if (input == true && ammo >= 1)
        {
            ammo--;

            SetCountText();

            Instantiate(bullet, transform.position, Quaternion.identity);

            audio.loop = false;
            audio.clip = shot;
            audio.PlayDelayed(0.1f);
        }

        //Checks amount of lives and acts accordingly (when your lives reach 0, the game resets it to 8. Yes, this is easy mode)
        if (lives == 0)
        {
            lives = 8;

            audio.loop = false;
            audio.clip = youLose;
            audio.PlayDelayed(0.1f);
        }

        //Debug.Log(lives);
    }

    //Adds the amount of ammo and lives to the UI
    void SetCountText()
    {
        ammoCount.text = "Ammo: " + ammo.ToString();

        lifeCount.text = "Lives: " + lives.ToString();
    }

    /*
     * Lowers the lives count by one when hitting another obstacle and resets the player position to the start
     * Raises the ammo count by one when hitting a pickup
     * Plays a winning sound when hitting the finish and resets the player position to the start
     */ 
    void OnTriggerEnter(Collider other)
    {
        AudioSource audio = GetComponent<AudioSource>();

        //Debug.Log(checkCount);
        //Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag("Obstacle"))
        {
            transform.position = new Vector3(25, 0, 10);

            Destroy(other.gameObject);

            lives--;
            SetCountText();

            audio.loop = false;
            audio.clip = crash2;
            audio.PlayDelayed(0.1f);

        }

        if (other.gameObject.CompareTag("Pickup"))
        {
            ammo++;

            Destroy(other.gameObject);

            SetCountText();

            audio.loop = false;
            audio.clip = pickup;
            audio.PlayDelayed(0.1f);

            //Debug.Log(checkCount);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            transform.position = new Vector3(25, 0, 10);

            audio.loop = false;
            audio.clip = youWin;
            audio.PlayDelayed(0.1f);
        }
    }

    
}
