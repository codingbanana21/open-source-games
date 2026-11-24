using Godot;
using Godot.Collections;

public partial class GameManager : Node
{
    public bool[] Inputs = [false, false, false, false];
    public int Score { get; set; } = 0;
}