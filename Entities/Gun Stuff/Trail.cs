using Godot;
using System;

public class Trail : Line2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override async void _Ready()
    {
        await ToSignal(this.GetTree().CreateTimer(0.5f), "timeout");
        this.QueueFree();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
