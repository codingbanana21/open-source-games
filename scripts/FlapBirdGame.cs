using Godot;
using System;

public partial class FlapBirdGame : Node2D
{
    void _on_spawn_timer_timeout()
    {
        var projectileScene = GD.Load<PackedScene>(
            "res://scenes/flap_bird_projectile.tscn"
        );
        var newProjectile = projectileScene.Instantiate<FlapBirdProjectile>();
        var position = newProjectile.GlobalPosition;
        position.X = 200.0f;
        position.Y = GD.RandRange(-100, 100);
        newProjectile.GlobalPosition = position;
        AddChild(newProjectile);
    }
}
