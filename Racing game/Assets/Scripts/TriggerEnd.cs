using UnityEngine;
using System.Collections;

public class TriggerEnd : MonoBehaviour {
    public GameObject floor;


	// Puts the Finish line at the end of the Floor Prefab
	void Start () {
        float floorEnd = floor.transform.position.z + floor.transform.lossyScale.z / 2;

        transform.Translate(25, 0.5f, floorEnd);
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
