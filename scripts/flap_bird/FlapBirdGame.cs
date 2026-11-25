using Godot;
using System;

public partial class FlapBirdGame : Node2D
{
    String[] projectiles = ["res://scenes/flap_bird/fb_rocket.tscn",
        "res://scenes/flap_bird/fb_fast_rocket.tscn",];

    void _on_spawn_timer_timeout()
    {
        var projectileScene = GD.Load<PackedScene>(
            projectiles[GD.Randi() % 2]
        );
        var newProjectile = projectileScene.Instantiate<FlapBirdProjectile>();
        var position = newProjectile.GlobalPosition;
        position.X = 200.0f;
        position.Y = GD.RandRange(-100, 100);
        newProjectile.GlobalPosition = position;
        AddChild(newProjectile);
    }
}
