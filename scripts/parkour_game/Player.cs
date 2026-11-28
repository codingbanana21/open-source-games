using Godot;
using System;

public partial class Player : CharacterBody2D
{
    private float speed = 20.0f;
    private float jump = -200.0f;
    public Vector2 NewVelocity = Vector2.Zero;

	public override void _Process(double delta)
    {
		if (NewVelocity.Y <= 300.0f) NewVelocity.Y += 400.0f * (float)delta;

        if (Input.IsActionPressed("jump") && IsOnFloor())
        {
            NewVelocity.Y = jump;
        }

        float direction = Input.GetAxis("left", "right");
        NewVelocity.X += direction * speed;

        NewVelocity.X *= 0.85f;
		Velocity = NewVelocity;
        MoveAndSlide();
    }
}
