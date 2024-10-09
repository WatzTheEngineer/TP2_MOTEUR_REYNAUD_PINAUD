using Godot;
using System;

public partial class LevelManager : Node
{
	
	private static LevelManager instance;
	
	private LevelManager(){
		
	}
	
	public static LevelManager GetInstance() {
		if (instance == null){
			instance = new LevelManager();
		}
		return instance;
	}
	
	public void LoadLevel(string levelName){
		Godot.PackedScene packed = (Godot.PackedScene) GD.Load("res://level/"+levelName+".tscn");
		if (packed != null){
			CustomMainLoop.Get().ChangeSceneToPacked(packed);
		}
	}
}
