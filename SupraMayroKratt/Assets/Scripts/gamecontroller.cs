using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour
{
	// leftover thing that causes an error when uncommented.
	// i didnt know if it was important or not so i left it in here to be safe
	
//	public IEnumerator Start()
//	{
//		return new gamecontroller.$Start$1(this).GetEnumerator();
//	}

	public void passed(int passnumber)
	{
		// this is kinda confusing but it works i guess?
		
		// if the player's lap is lower than the current lap
		if (passnumber > gamecontroller.laps - 1)
		{
			gamecontroller.laps = gamecontroller.laps + 1;
		}
		// if current lap is greater than 3?
		if (gamecontroller.laps > 3)
		{
			// end the game and let everyone know who won
			this.GameIsOver = true;
			MonoBehaviour.print("GameOver");
			// player 1
			if (gamecontroller.latestplayerpass == 1)
			{
				kartkontrol.AI = true;
				this.WinCamera1.enabled = true;
				this.GUIText.text = "player 1 has winned!";
			}
			// player 2
			if (gamecontroller.latestplayerpass == 2)
			{
				kartkontrolplayer2.AI = true;
				this.WinCamera2.enabled = true;
				this.GUIText.text = "player 2 has winned!";
			}
			// disable main camera
			this.MainCamera.enabled = false;
			
			// if playing multiplayer, disable the player cameras
			if (gamecontroller.multiplayer)
			{
				this.Player1Camera.enabled = false;
				this.Player2Camera.enabled = false;
			}
		}
	}

	public void Update()
	{
		// if the game isn't over, update the lap count
		if (!this.GameIsOver)
		{
			this.GUIText.text = "lappe " + gamecontroller.laps + "/3";
		}
	}

	public static int laps = 1;
	public static int latestplayerpass;

    public Text GUIText;
	public Camera MainCamera;
	public Camera WinCamera1;
	public Camera WinCamera2;
	public Camera Player1Camera;
	public Camera Player2Camera;

	public static bool multiplayer;


	private bool GameIsOver;
	
	// same story with this 

//	internal sealed class $Start$1 : GenericGenerator<object>
//	{
//		public $Start$1(gamecontroller self_)
//		{
//			this.$self_$3 = self_;
//		}
//
////		public override IEnumerator<object> GetEnumerator()
//		{
//			return new gamecontroller.$Start$1.$(this.$self_$3);
//		}

//		internal gamecontroller $self_$3;
//	}
}
