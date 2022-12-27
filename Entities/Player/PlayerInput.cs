using Godot;
using System;

public class PlayerInput : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private HumanMovement human;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        this.human = GetNode<HumanMovement>("HumanMovement");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta){
        this.human.targetVelocity = Input.GetAxis("move_left", "move_right");
        this.human.lookTarget = base.GetGlobalMousePosition();
    }
}
