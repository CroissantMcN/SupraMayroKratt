using System;
using UnityEngine;

public class kartkontrol : MonoBehaviour
{
	// kart controller
	
	public void Start()
	{
		// set material to respective character's on start
		if (GameVars.Player1Character == 0)
		{
			this.charactermodel.GetComponent<Renderer>().material = this.mayro;
		}
		if (GameVars.Player1Character == 1)
		{
			this.charactermodel.GetComponent<Renderer>().material = this.luggy;
		}
		if (GameVars.Player1Character == 2)
		{
			this.charactermodel.GetComponent<Renderer>().material = this.joshy;
		}
	}

	public void passing()
	{
		// this gets called by the finish line script when passing it, changes laps by 1 and updates the ui
		this.laps = this.laps + 1;
		GameObject.Find("gamecontroller").SendMessage("passed", this.laps);
	}

	public void Update()
	{
		// if it's an ai, do ai things
		if (kartkontrol.AI)
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
		// set pich of motor sound based on velocity
		this.GetComponent<AudioSource>().pitch = 0.01f * this.GetComponent<Rigidbody>().velocity.magnitude + 0.5f;
	}

	public void FixedUpdate()
	{
		// input stuff
		if (Input.GetAxis("Vertical") != (float)0)
		{
			this.GetComponent<Rigidbody>().AddForce(this.transform.forward * Input.GetAxis("Vertical") * this.acceleration);
		}
		float yAngle = Input.GetAxis("Horizontal") * this.rotationSpeed;
		this.transform.Rotate((float)0, yAngle, (float)0);
		if (Input.GetButton("Jump"))
		{
			this.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}

	public float maxspeed;
	public float acceleration;
	public float rotationSpeed;


	public static bool AI;


	public Transform[] AIwaypoints;
	public int CurrentWaypoint;
	public float AIspeed;
	private int laps;
	public GameObject charactermodel;
	public Material mayro;
	public Material luggy;
	public Material joshy;
}
