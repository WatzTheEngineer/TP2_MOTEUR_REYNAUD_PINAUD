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
	
	
	public void LoadGame(string filename){
		if (!FileAccess.FileExists("user://"+filename))
		{
			return;
		}
		using var saveFile = FileAccess.Open("user://"+filename, FileAccess.ModeFlags.Read);
		Godot.Collections.Array<Node> saveNodes = CustomMainLoop.Get().GetNodesInGroup("SaveMark");
		while (saveFile.GetPosition() < saveFile.GetLength())
		{
			var jsonString = saveFile.GetLine();
			var json = new Json();
			json.Parse(jsonString);
			var jsonData = json.GetData();
			
			foreach (Node node in saveNodes){
				var nodeData = node.Call("Load",jsonData);
			}
		}
	}
	
	
	public void SaveGame(string filename){
		using var saveFile = FileAccess.Open("user://"+filename, FileAccess.ModeFlags.Write);
		Godot.Collections.Array<Node> saveNodes = CustomMainLoop.Get().GetNodesInGroup("SaveMark");
		foreach (Node node in saveNodes)
		{
			var nodeData = node.Call("Save");
			var jsonString = Json.Stringify(nodeData);
			saveFile.StoreLine(jsonString);
		}
	}
	
	
}
