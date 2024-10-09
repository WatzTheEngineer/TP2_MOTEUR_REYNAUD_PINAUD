using Godot;
using System;

public partial class PlayerCharacter : CharacterBody2D, ISaveable
{
	[Export] public int Speed {get;set;} = 80;
	private AnimatedSprite2D _animationPlayer;
	private Godot.Collections.Dictionary<string, Variant> playerData;
	
	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public Vector2 GetInput()
	{
		return Input.GetVector("Left", "Right", "Up", "Down") * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = GetInput();
		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("Down"))
		{
			_animationPlayer.Play("walk_down");
		}
		else if (Input.IsActionPressed("Up"))
		{
			_animationPlayer.Play("walk_up");
		}
		else if (Input.IsActionPressed("Right"))
		{
			_animationPlayer.Play("walk_right");
		}
		else if (Input.IsActionPressed("Left"))
		{
			_animationPlayer.Play("walk_left");
		}
		else
		{
			_animationPlayer.Play("idle");
		}
	}
	
	public Godot.Collections.Dictionary<string, Variant> Save(){
		return new Godot.Collections.Dictionary<string, Variant>() {
			{ "PosX", Position.X },
			{ "PosY", Position.Y },
			{ "LevelName", CustomMainLoop.Get().CurrentScene.Name },
		};
	}
	
	public void Load(Godot.Collections.Dictionary<string, Variant> data){
		this.playerData = data;
		CallDeferred(nameof(PlacePlayer));
	}
	
	private void PlacePlayer(){
		
		// DO NOT WORK
		if ((string)this.playerData["LevelName"] == "SecondLevel"){
			CustomMainLoop.Get().GetLevelManager().LoadLevel("second_level");
		}
		
		this.GlobalPosition = new Vector2((float)this.playerData["PosX"],(float)this.playerData["PosY"]);
	}
}
