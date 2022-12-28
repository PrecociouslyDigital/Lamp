using Godot;
using System;

public class HumanMovement : KinematicBody2D
{
    private const float lookSpeed = 5f;

    private float acceleration = 500f;
    private float topSpeed = 70f;

    private Vector2 velocity = new Vector2(0.0f, 0.0f);
    public Vector2 targetVelocity = new Vector2(0.0f, 0.0f);
    public Vector2 lookTarget = new Vector2(20f,0f);

    private Node2D Arm;

    private RichTextLabel DebugText;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        this.Arm = GetNode<Node2D>("Arm");
        this.DebugText = GetNode<RichTextLabel>("DebugText");
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta) {
        base._Process(delta);
        this.velocity = this.velocity.MoveToward(this.targetVelocity * topSpeed, acceleration * delta);
        base.MoveAndCollide(this.velocity * delta);


        var lookTargetRelative = this.lookTarget - this.GlobalPosition;

        var targetAngle = Mathf.Wrap(lookTargetRelative.Angle() - Mathf.Pi/2, -Mathf.Pi, Mathf.Pi);

        this.DebugText.Text = $"     target: {targetAngle} current: {this.Arm.GlobalRotation}";

        this.Arm.GlobalRotation = Mathf.LerpAngle(this.Arm.GlobalRotation, targetAngle, lookSpeed*delta);
        // If we naively would wrap around, go the other direction until we wrap around and can begin doing the math the same
        if(Math.Abs(targetAngle - this.Arm.GlobalRotation) > Mathf.Pi)
        {
            this.Arm.GlobalRotation = Mathf.MoveToward(this.Arm.GlobalRotation, targetAngle, -lookSpeed * delta);
        }
        else
        {
            this.Arm.GlobalRotation = Mathf.MoveToward(this.Arm.GlobalRotation, targetAngle, lookSpeed * delta);
        }

    }

}
