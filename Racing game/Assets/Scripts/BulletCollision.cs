using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    public GameObject obstacle;

    //Bullet speed
    public float speed = 10.0f;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float player_x = player.transform.right.x;
        float player_y = player.transform.up.y;
        float player_z = player.transform.forward.z;

        //Propels the bullet forwards on the Z axis with the player as startposition
        transform.Translate(player_x - player_x, (player_y - player_y) + 0.05f, player_z * speed);

        //Debug.Log(player_y);
    }

    /*
     * Destroys the obstacle the bullet hits and removes the bullet
     */ 
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit");

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            Destroy(bullet);
        }
            

    }

}
