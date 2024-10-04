using Godot;
using System;

public interface ISaveable
{
	public Godot.Collections.Dictionary<string, Variant> Save();
	public void Load(Godot.Collections.Dictionary<string, Variant> data);
}
