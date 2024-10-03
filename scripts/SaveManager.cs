using Godot;
using System;

public partial class SaveManager : Node
{
	private static SaveManager instance;
	
	private SaveManager(){
		
	}
	
	public static SaveManager GetInstance() {
		if (instance == null){
			instance = new SaveManager();
		}
		return instance;
	}
	
	public void Loadgame(string filename){
		
	}
	
	public void SaveGame(string filename){
		
		using var saveFile = FileAccess.Open("user://"+filename, FileAccess.ModeFlags.Write);
		
		var saveNodes = GetTree().GetNodesInGroup("SaveMark");
		foreach (Node saveNode in saveNodes)
		{
			if (string.IsNullOrEmpty(saveNode.SceneFilePath))
		{
			GD.Print($"persistent node '{saveNode.Name}' is not an instanced scene, skipped");
			continue;
		}
		if (!saveNode.HasMethod("Save"))
		{
			GD.Print($"persistent node '{saveNode.Name}' is missing a Save() function, skipped");
			continue;
		}
		var nodeData = saveNode.Call("Save");
		var jsonString = Json.Stringify(nodeData);
		saveFile.StoreLine(jsonString);
		}
		
	}
}
