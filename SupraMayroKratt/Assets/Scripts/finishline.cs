using System;
using UnityEngine;

public class finishline : MonoBehaviour
{
	//finish line script
	
	public int latestpasser;
	public AudioClip[] PassClips;
	
	public void OnTriggerEnter(Collider Playerboy)
	{
		// check if the thing it collided with is player 1 or player 2, and update the lap count for the respective player if so
		if (Playerboy.gameObject.CompareTag("Player1"))
		{
			gamecontroller.latestplayerpass = 1;
		}
		if (Playerboy.gameObject.CompareTag("Player2"))
		{
			gamecontroller.latestplayerpass = 2;
		}
		
		// call lap pass function for what player touched it
		Playerboy.gameObject.SendMessage("passing", SendMessageOptions.DontRequireReceiver);
		
		// play one of the defined audioclips,
		int num = UnityEngine.Random.Range(0, PassClips.Length);
		this.GetComponent<AudioSource>().PlayOneShot(this.PassClips[num]);
	}

}
