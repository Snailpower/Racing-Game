using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    public GameObject obstacle;

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

        bullet.transform.Translate(player_x - player_x, player_y - player_y, player_z * speed);
    }

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
