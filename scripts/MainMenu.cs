using Godot;
using System;

[GlobalClass]
public partial class MainMenu : Node2D
{
	public void _on_flap_bird_button_pressed() {
		GetTree().ChangeSceneToFile("res://scenes/flap_bird/flap_bird_game.tscn");
	}

	public void _on_chess_timer_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/chess_timer/chess_timer_game.tscn");
	}

	public void _on_parkour_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/parkour_game/parkour_game.tscn");
	}
}
