using Godot;
using System;

[GlobalClass]
public partial class MainMenu : Node2D
{
	[Export]
	int hp = 100;

	private void _on_flap_bird_button_pressed() {
		GD.Print("Hello!");
	}
}
