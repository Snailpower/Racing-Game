using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject floor;
    public GameObject obstacle;
    public GameObject ammo;

    public int objCount = 200;
    public float floorEnd;
    public float obstacleStart = 30.0f;

    public int ammoCount = 50;



	// Use this for initialization
	void Start () {
        floorEnd = floor.transform.position.z + floor.transform.lossyScale.z / 2;

        PlaceObj();
        PlaceAmmo();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PlaceObj ()
    {

        for (int i = 0; i < objCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(0.0f, 50.0f), 2.0f, Mathf.Round((Random.Range(obstacleStart, floorEnd))));

            Instantiate(obstacle, position, Quaternion.identity);
        }
    }

    void PlaceAmmo ()
    {
        for (int i = 0; i < ammoCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(5.0f, 40.0f), 1.0f, Mathf.Round((Random.Range(obstacleStart, floorEnd))));

            Instantiate(ammo, position, Quaternion.identity);
        }
    }
}
