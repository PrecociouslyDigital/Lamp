using System;
using Godot;

public class MouseTracker : Node2D
{
    public override void _Process(float delta)
    {
        this.GlobalPosition = base.GetGlobalMousePosition();
    }
}

