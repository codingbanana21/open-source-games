using Godot;
using System;

[GlobalClass]
public partial class FlapBirdProjectile : Area2D
{
    [Export]
    float speed = 100.0f;
    [Export]
    float knockback = 4.0f;
    [Export]
    int health = 1;

    public Vector2 NewVelocity = Vector2.Zero;

    public override void _Ready()
    {
        NewVelocity.X = -speed;
    }

	public override void _Process(double delta)
    {
        GlobalPosition += NewVelocity * (float)delta;
    }

    void _on_body_entered(Node2D body)
    {
        if (body is FlapBird flapBird)
        {
            flapBird.NewVelocity.X = -knockback;
            health--;

            if (health <= 0)
            {
                QueueFree();
            }
        }
    }
}
