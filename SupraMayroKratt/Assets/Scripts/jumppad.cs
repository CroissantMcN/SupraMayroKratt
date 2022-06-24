using System;
using UnityEngine;

public class jumppad : MonoBehaviour
{
	// if touching *any* object (in this case, should only be the player), send it upwards
	public void OnTriggerEnter(Collider Turd)
	{
		Turd.GetComponent<Rigidbody>().AddForce(Vector3.up * this.upForce);
	}
	
	public float upForce;
}
