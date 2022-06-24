using System;
using UnityEngine;

public class kartkontrolplayer2 : MonoBehaviour
{
	// i genuinely have no idea why they made a duplicate of the main controller and just added a single variable for ai at start
	// because it's basically the same, i wont add comments to the script. (if you need comments go check player 1's controller)
	
	public kartkontrolplayer2()
	{
		this.StartWithAI = true;
	}

	public void Start()
	{
		if (GameVars.Player2Character == 0)
		{
			this.charactermodel.GetComponent<Renderer>().material = this.mayro;
		}
		if (GameVars.Player2Character == 1)
		{
			this.charactermodel.GetComponent<Renderer>().material = this.luggy;
		}
		if (GameVars.Player2Character == 2)
		{
			this.charactermodel.GetComponent<Renderer>().material = this.joshy;
		}
		if (!this.StartWithAI)
		{
			kartkontrolplayer2.AI = false;
		}
		this.AIspeed = (float)GameVars.AIdifficulty;
	}

	public void passing()
	{
		this.laps = this.laps + 1;
		GameObject.Find("gamecontroller").SendMessage("passed", this.laps);
	}

	public void Update()
	{
		if (kartkontrolplayer2.AI)
		{
			this.GetComponent<Rigidbody>().isKinematic = true;
			if (this.transform.position == this.AIwaypoints[this.CurrentWaypoint].position)
			{
				if (this.CurrentWaypoint < this.AIwaypoints.Length - 1)
				{
					this.CurrentWaypoint++;
				}
				else
				{
					this.CurrentWaypoint = 0;
				}
			}
			this.transform.LookAt(this.AIwaypoints[this.CurrentWaypoint]);
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.AIwaypoints[this.CurrentWaypoint].position, this.AIspeed * Time.deltaTime);
		}
		else
		{
			this.GetComponent<Rigidbody>().isKinematic = false;
		}
		this.GetComponent<AudioSource>().pitch = 0.01f * this.GetComponent<Rigidbody>().velocity.magnitude + 0.5f;
	}

	public void FixedUpdate()
	{
		if (Input.GetAxis("Vertical2") != (float)0)
		{
			this.GetComponent<Rigidbody>().AddForce(this.transform.forward * Input.GetAxis("Vertical2") * this.acceleration);
		}
		float yAngle = Input.GetAxis("Horizontal2") * this.rotationSpeed;
		this.transform.Rotate((float)0, yAngle, (float)0);
		if (Input.GetButton("Jump2"))
		{
			this.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}

	public float maxspeed;
	public float acceleration;
	public float rotationSpeed;

	public static bool AI = true;

	public bool StartWithAI;
	public Transform[] AIwaypoints;
	public int CurrentWaypoint;
	public float AIspeed;
	private int laps;
	public GameObject charactermodel;
	public Material mayro;
	public Material luggy;
	public Material joshy;
}
