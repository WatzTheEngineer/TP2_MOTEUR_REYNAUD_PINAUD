using Godot;
using Godot.Collections;
using System.Collections.Generic;

public partial class LevelManager : Node
{
	[Export] int firstSceneIndex = 0;
	[Export] Array<PackedScene> editorScenes;
	
	private static LevelManager instance;
	
	private LevelManager()
	{
		
	}
	
	public static LevelManager GetInstance() {
		if (instance == null){
			instance = new LevelManager();
		}
		return instance;
	}
	
	public override void _Ready()
	{

	}
	
	
}
