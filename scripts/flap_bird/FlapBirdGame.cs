using Godot;
using System;

public partial class FlapBirdGame : Node2D
{
    private String[] projectiles = ["res://scenes/flap_bird/rocket.tscn",
        "res://scenes/flap_bird/fast_rocket.tscn",
        "res://scenes/flap_bird/hard_rocket.tscn",
        "res://scenes/flap_bird/big_rocket.tscn",];

    private Timer spawnTimer;

    public override void _Ready()
    {
        spawnTimer = GetNode<Timer>("SpawnTimer");
    }
    
    void _on_spawn_timer_timeout()
    {
        var projectileScene = GD.Load<PackedScene>(projectiles[0]);
        if (spawnTimer.WaitTime >= 0.25)
        {
            spawnTimer.WaitTime *= 0.95;
            projectileScene = GD.Load<PackedScene>(
                projectiles[GD.Randi() % 3]
            );
        }
        else
        {
            projectileScene = GD.Load<PackedScene>(
                projectiles[GD.Randi() % 4]
            );
        }

        var newProjectile = projectileScene.Instantiate<FlapBirdProjectile>();
        var position = newProjectile.GlobalPosition;
        position.X = 200.0f;
        position.Y = (float)GD.RandRange(-110.0f, 75.0f);
        newProjectile.GlobalPosition = position;
        AddChild(newProjectile);
    }
}
