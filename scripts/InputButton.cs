using Godot;
using System;

[GlobalClass]
public partial class InputButton : Button
{
    [Export]
    private int playerButtonNumber = 0;

    private GameManager gameManager;
    public override void _Ready()
    {
    	gameManager = GetNode<GameManager>("/root/GameManager");
    }

    private void _on_pressed()
    {
        gameManager.Inputs[playerButtonNumber] = !gameManager.Inputs[playerButtonNumber];
    }
}
