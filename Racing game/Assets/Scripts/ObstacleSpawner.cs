using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject floor;
    public GameObject obstacle;
    public GameObject pickup;

    //Amount of obstacles spawned in
    public int obstacleCount = 200;
    
    //Starting Z position of objects spawning in
    public float objStart = 30.0f;

    //Amount of ammunition pickups
    public int ammoCount = 50;

    //Sets the end of the floor the player can drive on
    private float floorEnd;

    // Use this for initialization
    void Start () {
        floorEnd = floor.transform.position.z + floor.transform.lossyScale.z / 2;

        PlaceObj();
        PlaceAmmo();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
     * Instantiates obstacles randomly on:
     * X: between 0 and 50
     * Y = 2
     * Z: between obstacleStart and floorEnd
     */
    void PlaceObj ()
    {

        for (int i = 0; i < obstacleCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(0.0f, 50.0f), 2.0f, Mathf.Round((Random.Range(objStart, floorEnd))));

            Instantiate(obstacle, position, Quaternion.identity);
        }
    }

    /*
     * Instantiates ammunition pickups randomly on:
     * X: between 0 and 50
     * Y = 2
     * Z: between obstacleStart and floorEnd
     */
    void PlaceAmmo ()
    {
        

        for (int i = 0; i < ammoCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(5.0f, 40.0f), 1.0f, Mathf.Round((Random.Range(objStart, floorEnd))));

            //Adds spin to the pickups
            pickup.GetComponent<Rotator>();

            Instantiate(pickup, position, Quaternion.identity);
        }
    }
}
