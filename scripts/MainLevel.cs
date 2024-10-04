using Godot;
using System;

public partial class MainLevel : Node2D
{
	public override void _Ready(){
		base._Ready();
		CustomMainLoop.Get().GetSaveManager().LoadGame("save.json");
	}
	
	public override void _Notification(int what){
		if (what == NotificationWMCloseRequest){
			CustomMainLoop.Get().GetSaveManager().SaveGame("save.json");
			CustomMainLoop.Get().Quit();
		}
	}
}
