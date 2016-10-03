using UnityEngine;
using System.Collections;

public class TriggerEnd : MonoBehaviour {
    public GameObject floor;


	// Use this for initialization
	void Start () {
        float floorEnd = floor.transform.position.z + floor.transform.lossyScale.z / 2;

        transform.Translate(25, 0.5f, floorEnd);
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
