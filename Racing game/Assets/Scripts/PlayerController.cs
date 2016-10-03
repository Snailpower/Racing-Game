using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject player;
    public GameObject bullet;

    public Text countText;
    public Text lifeAmount;
    public float speed;
    public int lives = 8;

    //sounds
    public AudioClip engine1;
    public AudioClip engine2;
    public AudioClip shot;
    public AudioClip crash1;
    public AudioClip crash2;
    public AudioClip crash3;
    public AudioClip crash4;
    public AudioClip crash5;
    public AudioClip pickup;
    public AudioClip youWin;
    public AudioClip youLose;


    // Use this for initialization
    void Start ()
    {
        checkCount = 0;
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
        //audio init
        AudioSource audio = GetComponent<AudioSource>();

        //Player Controls
        //Movement
        float horizontal = Input.GetAxis("Horizontal");

        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        gameObject.transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);

        //limits the movement to between the walls
        float player_x = gameObject.transform.position.x;
        float player_y = gameObject.transform.position.y;
        float player_z = gameObject.transform.position.z;

        gameObject.transform.position = new Vector3(Mathf.Clamp(player_x, 2.0F, 48.0F), player_y, player_z);


        //Shooting
        bool input = Input.GetButtonDown("Fire");

        if (input == true && checkCount >= 1)
        {
            checkCount--;

            SetCountText();

            Instantiate(bullet, transform.position, Quaternion.identity);

            audio.loop = false;
            audio.clip = shot;
            audio.PlayDelayed(0.1f);
        }

        //Checks amount of lives and acts accordingly
        if (lives == 0)
        {
            lives = 8;

            audio.loop = false;
            audio.clip = youLose;
            audio.PlayDelayed(0.1f);
        }

        Debug.Log(lives);
        

    }

    void SetCountText()
    {
        countText.text = "Ammo: " + checkCount.ToString();

        lifeAmount.text = "Lives: " + lives.ToString();
    }

    private int checkCount;

    void OnTriggerEnter(Collider other)
    {
        AudioSource audio = GetComponent<AudioSource>();

        //Debug.Log(checkCount);
        //Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag("Obstacle"))
        {
            transform.position = new Vector3(25, 0, 10);

            other.gameObject.SetActive(false);

            lives--;
            SetCountText();

            audio.loop = false;
            audio.clip = crash2;
            audio.PlayDelayed(0.1f);

        }

        if (other.gameObject.CompareTag("Pickup"))
        {
            checkCount++;

            other.gameObject.SetActive(false);

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
