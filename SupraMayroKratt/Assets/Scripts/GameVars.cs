using System;
using UnityEngine;

public class GameVars : MonoBehaviour
{
	// pretty much playerprefs before they were cool
	
	public void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this.transform.gameObject);
	}

	public static bool multiplayer;
	public static int Player1Character;
	public static int Player2Character = 2;
	public bool multiplayerpoo;
	public static int AIdifficulty = 20;
}
