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
		if(NewVelocity.Y <= 5.0f) NewVelocity.Y += 7.0f * (float)delta;

		if(gameManager.Inputs[playerNumber])
		{
			gameManager.Inputs[playerNumber] = false;
			NewVelocity.Y = -4.0f;
		}

		// hit top screen
		if(GlobalPosition.Y >= 100.0f) {
			NewVelocity.Y = -3.5f;
			NewVelocity.X = -4.0f;
		}

		// hit bottem screen
		if(GlobalPosition.Y <= -100.0f) {
			NewVelocity.Y = 1.5f;
			NewVelocity.X = -4.0f;
		}

		if(GlobalPosition.X <= -180.0f) {
			QueueFree();
		}

		NewVelocity.X *= 0.95f;
		GlobalPosition += NewVelocity;
		Rotation = NewVelocity.Y / 10.0f;
	}
}
