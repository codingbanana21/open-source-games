using Godot;
using System;
using System.Threading.Tasks.Dataflow;

[GlobalClass]
public partial class FlapBird : CharacterBody2D
{
    [Export]
    public int playerNumber = 0;
	public Vector2 NewVelocity = Vector2.Zero;

    private GameManager gameManager;
    public override void _Ready()
    {
    	gameManager = GetNode<GameManager>("/root/GameManager");
    }

	public override void _Process(double delta)
	{
		if (NewVelocity.Y <= 300.0f) NewVelocity.Y += 400.0f * (float)delta;

		// jumping
		if (gameManager.Inputs[playerNumber])
		{
			gameManager.Inputs[playerNumber] = false;
			NewVelocity.Y = -240.0f;
		}

		// hit bottem screen
		if (GlobalPosition.Y >= 80.0f) {
			NewVelocity.Y = -200.0f;
			NewVelocity.X = -180.0f;
		}

		// hit top screen
		if (GlobalPosition.Y <= -110.0f) {
			NewVelocity.Y = 100.0f;
			NewVelocity.X = -180.0f;
		}

		if (GlobalPosition.X <= -190.0f) {
			QueueFree();
		}

		NewVelocity.X *= 0.95f;
		Velocity = NewVelocity;
        MoveAndSlide();

		Rotation = Velocity.Y / 600.0f;
	}
}
