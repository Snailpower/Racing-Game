using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	// The initial rotation of the ammunition pickups
	void Update ()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
