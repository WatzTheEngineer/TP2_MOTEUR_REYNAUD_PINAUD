using Godot;
using System;

public partial class SaveManager : GodotObject
{
	private static SaveManager instance;
	
	private SaveManager(){
		
	}
	
	public static SaveManager getInstance() {
		if (instance == null){
			instance = new SaveManager();
		}
		return instance;
	}
	
	public void Loadgame(){
		
	}
	
	public void SaveGame(){
		
	}
}
