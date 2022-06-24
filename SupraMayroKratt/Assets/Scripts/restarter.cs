using System;
using UnityEngine;

public class restarter : MonoBehaviour
{
	// i dont think i need to comment this one
	
	public void OnCollisionEnter(Collision Turder)
	{
		Turder.gameObject.transform.position = this.respawnpoint.position;
		Turder.gameObject.transform.rotation = this.respawnpoint.rotation;
	}

	public Transform respawnpoint;
}
