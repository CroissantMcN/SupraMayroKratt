using System;
using UnityEngine;

public class settings : MonoBehaviour
{
	public string[] characterStrings;
	public int Player1;
	public int LevelSelectionVar;
	public string[] LevelSelectionStrings;

	public settings()
	{
		// names for everything
		
		this.characterStrings = new string[]
		{
			"mayro",
			"luggy",
			"joshy"
		};
		this.Player1 = 2;
		this.LevelSelectionStrings = new string[]
		{
			"dessert rumble",
			"musshrom villadge"
		};
	}

	public void OnGUI()
	{
		// they crafted the entire menu ui using a script.. mad respect
		
		GUI.Box(new Rect((float)(Screen.width / 2 - 100), (float)(Screen.height / 2), (float)400, (float)200), "setting");
		GUI.Label(new Rect((float)(Screen.width / 2 - 100 + 10), (float)(Screen.height / 2 + 20), (float)100, (float)20), "track:");
		this.LevelSelectionVar = GUI.Toolbar(new Rect((float)(Screen.width / 2 - 100 + 50), (float)(Screen.height / 2 + 20), (float)300, (float)20), this.LevelSelectionVar, this.LevelSelectionStrings);
		GUI.Label(new Rect((float)(Screen.width / 2 - 100 + 10), (float)(Screen.height / 2 + 50), (float)100, (float)20), "player:");
		GameVars.Player1Character = GUI.Toolbar(new Rect((float)(Screen.width / 2 - 100 + 60), (float)(Screen.height / 2 + 50), (float)300, (float)20), GameVars.Player1Character, this.characterStrings);
		GUI.Label(new Rect((float)(Screen.width / 2 - 100 + 10), (float)(Screen.height / 2 + 80), (float)100, (float)20), "player2:");
		GameVars.Player2Character = GUI.Toolbar(new Rect((float)(Screen.width / 2 - 100 + 60), (float)(Screen.height / 2 + 80), (float)300, (float)20), GameVars.Player2Character, this.characterStrings);
		GameVars.multiplayer = GUI.Toggle(new Rect((float)(Screen.width / 2 - 100 + 30), (float)(Screen.height / 2 + 110), (float)100, (float)20), GameVars.multiplayer, "multiplayer");
		GUI.Label(new Rect((float)(Screen.width / 2 - 100 + 170), (float)(Screen.height / 2 + 110), (float)300, (float)20), "playre 1 move: wasd break: space");
		GUI.Label(new Rect((float)(Screen.width / 2 - 100 + 170), (float)(Screen.height / 2 + 130), (float)300, (float)20), "playre 2 move: arrows break: p");
		GUI.Label(new Rect((float)(Screen.width / 2 - 100 + 170), (float)(Screen.height / 2 + 155), (float)300, (float)20), "ai difficulty:");
		GameVars.AIdifficulty = (int)GUI.HorizontalSlider(new Rect((float)(Screen.width / 2 - 100 + 170), (float)(Screen.height / 2 + 170), (float)100, (float)30), (float)GameVars.AIdifficulty, (float)1, (float)50);
		
		// load track on play
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 100 + 30), (float)(Screen.height / 2 + 150), (float)100, (float)20), "play"))
		{
			if (this.LevelSelectionVar == 0)
			{
				Application.LoadLevel(1); // dessert rumble
			}
			if (this.LevelSelectionVar == 1)
			{
				Application.LoadLevel(2); // musshrom villadge
			}
		}
	}

}
