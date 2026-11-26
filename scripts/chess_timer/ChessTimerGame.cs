using Godot;
using System;

public partial class ChessTimerGame : Node2D
{
    private enum TURN {PLAYER1, PLAYER2}
    
    private Label timerLabel1;
    private Label timerLabel2;
    private Button startStopButton;

    private float time1 = 300.0f;
    private float time2 = 300.0f;
    private TURN player_turn = TURN.PLAYER1;
    private bool running = false;

    public override void _Ready()
    {
        timerLabel1 = GetNode<Label>("TimerLabel1");
        timerLabel2 = GetNode<Label>("TimerLabel2");
        startStopButton = GetNode<Button>("StartStopButton");
    }

	public override void _Process(double delta)
    {
        timerLabel1.Text = ((int)time1).ToString();
        timerLabel2.Text = ((int)time2).ToString();

        if(running)
        {
            if(player_turn == TURN.PLAYER1) {
                time1 -= 1.0f * (float)delta;
                timerLabel1.Modulate = Color.Color8(255 ,0 ,0);
                timerLabel2.Modulate = Color.Color8(255 ,255 ,255);
            }
            else
            {
                time2 -= 1.0f * (float)delta;
                timerLabel1.Modulate = Color.Color8(255 ,255 ,255);
                timerLabel2.Modulate = Color.Color8(255 ,0 ,0);
            }
        }
        else
        {
            if(player_turn == TURN.PLAYER1) {
                timerLabel1.Modulate = Color.Color8(0,255 ,0);
                timerLabel2.Modulate = Color.Color8(255 ,255 ,255);
            }
            else
            {
                timerLabel1.Modulate = Color.Color8(255 ,255 ,255);
                timerLabel2.Modulate = Color.Color8(0,255 ,0);
            }
        }
    }

    public void _on_swich_button_pressed()
    {
        if(player_turn == TURN.PLAYER1)
        {
            player_turn = TURN.PLAYER2;
        }
        else
        {
            player_turn = TURN.PLAYER1;
        }
    }

    public void _on_start_stop_button_pressed()
    {
        running = !running;

        if (running)
        {
            startStopButton.Text = "Stop";
        }
        else
        {
            startStopButton.Text = "Start";
        }
    }
}
