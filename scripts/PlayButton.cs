using Godot;
using System;

public partial class PlayButton : Button
{
	public override void _Ready()
	{
		Button playButton = CustomMainLoop.Get().CurrentScene.GetNode<Button>("Panel/PlayButton");
		playButton.Connect("pressed", new Callable(this, nameof(OnPlayButtonPressed)));
	}

	private void OnPlayButtonPressed()
	{
		CustomMainLoop.Get().GetLevelManager().LoadLevel("main_level");
	}
}
