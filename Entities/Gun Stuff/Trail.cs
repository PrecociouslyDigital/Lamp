using Godot;
using System;

public class Trail : Line2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    const float trailTime = 1/45;
    // Called when the node enters the scene tree for the first time.
    public override async void _Ready()
    {
        await ToSignal(this.GetTree().CreateTimer(trailTime), "timeout");
        this.QueueFree();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
