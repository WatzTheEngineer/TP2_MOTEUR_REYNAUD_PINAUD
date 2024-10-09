using Godot;
using System;

public partial class TP : Area2D
{
	public override void _Ready()
	{
		Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}
	
	private void OnBodyEntered(Node body)
	{
		this.CallDeferred(nameof(SwitchLevels));
	}
	
	private void SwitchLevels(){
		if (CustomMainLoop.Get().CurrentScene.Name == "SecondLevel"){
			CustomMainLoop.Get().GetLevelManager().LoadLevel("main_level");
		}
		else{
			CustomMainLoop.Get().GetLevelManager().LoadLevel("second_level");
		}
	}
}
