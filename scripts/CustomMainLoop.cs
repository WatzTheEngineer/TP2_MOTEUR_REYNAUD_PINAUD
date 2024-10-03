using Godot;
using System;

[GlobalClass]
public partial class CustomMainLoop : SceneTree
{
	private static CustomMainLoop instance;
	
	public override void _Initialize()
	{
		base._Initialize();
		instance = this;
	}
	
	public static CustomMainLoop Get()
	{
		return instance;
	}
	
	public LevelManager GetLevelManager(){
		// SIGNATURE A CHANGER - DOIT RETOURNER LE SINGLETON LEVEL MANAGER
		return null;
	}
	
	public SaveManager GetSaveManager(){
		// SIGNATURE A CHANGER - DOIT RETOURNER LE SINGLETON LEVEL MANAGER
		return null;
	}
	
	public override void _Finalize(){
		base._Finalize();
		SaveManager.GetInstance().SaveGame("save.json");
	}
}
