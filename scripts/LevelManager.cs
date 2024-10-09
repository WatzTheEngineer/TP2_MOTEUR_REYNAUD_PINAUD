using Godot;
using System;

public partial class LevelManager : GodotObject
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
	
	public void Loadlevel(string levelName){
		return ;
	}
}
