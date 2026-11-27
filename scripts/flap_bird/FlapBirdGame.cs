using Godot;
using System;

public partial class FlapBirdGame : Node2D
{
    private String[] projectiles = ["res://scenes/flap_bird/rocket.tscn",
        "res://scenes/flap_bird/fast_rocket.tscn",
        "res://scenes/flap_bird/hard_rocket.tscn",];

    private Timer spawnTimer;

    public override void _Ready()
    {
        spawnTimer = GetNode<Timer>("SpawnTimer");
    }
    
    void _on_spawn_timer_timeout()
    {
        spawnTimer.WaitTime *= 0.95;

        var projectileScene = GD.Load<PackedScene>(
            projectiles[GD.Randi() % 3]
        );
        var newProjectile = projectileScene.Instantiate<FlapBirdProjectile>();
        var position = newProjectile.GlobalPosition;
        position.X = 200.0f;
        position.Y = (float)GD.RandRange(-110.0f, 110.0f);
        newProjectile.GlobalPosition = position;
        AddChild(newProjectile);
    }
}
