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
		return LevelManager.GetInstance();
	}
	
	public SaveManager GetSaveManager(){
		return SaveManager.GetInstance();
	}
}
