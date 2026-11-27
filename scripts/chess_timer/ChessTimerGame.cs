using Godot;
using System;

public partial class ChessTimerGame : Node2D
{
    private enum TURN {PLAYER1, PLAYER2}
    
    private LineEdit timerLineEdit1;
    private LineEdit timerLineEdit2;
    private Button startStopButton;
    private AudioStreamPlayer endAudioStreamPlayer;

    private float time1 = 300.0f;
    private float time2 = 300.0f;
    private TURN playerTurn = TURN.PLAYER1;
    private bool running = false;

    public override void _Ready()
    {
        timerLineEdit1 = GetNode<LineEdit>("TimerLineEdit1");
        timerLineEdit2 = GetNode<LineEdit>("TimerLineEdit2");
        startStopButton = GetNode<Button>("StartStopButton");
        endAudioStreamPlayer = GetNode<AudioStreamPlayer>("EndAudioStreamPlayer");
        
        timerLineEdit1.Text = ((int)time1).ToString();
        timerLineEdit2.Text = ((int)time2).ToString();
    }

	public override void _Process(double delta)
    {
        if (running)
        {
            timerLineEdit1.Text = ((int)time1).ToString();
            timerLineEdit2.Text = ((int)time2).ToString();

            if (time1 <= 0.0f || time2 <= 0.0f) {
                running = false;
                endAudioStreamPlayer.Play();
            }

            if (playerTurn == TURN.PLAYER1) {
                time1 -= 1.0f * (float)delta;
                timerLineEdit1.Modulate = Color.Color8(255 ,0 ,0);
                timerLineEdit2.Modulate = Color.Color8(255 ,255 ,255);
            }
            else
            {
                time2 -= 1.0f * (float)delta;
                timerLineEdit1.Modulate = Color.Color8(255 ,255 ,255);
                timerLineEdit2.Modulate = Color.Color8(255 ,0 ,0);
            }
        }
        else
        {
            // set the times to the text
            if (float.TryParse(timerLineEdit1.Text, out float parsedTime1))
                time1 = parsedTime1;

            if (float.TryParse(timerLineEdit2.Text, out float parsedTime2))
                time2 = parsedTime2;
            
            if (playerTurn == TURN.PLAYER1) {
                timerLineEdit1.Modulate = Color.Color8(0,255 ,0);
                timerLineEdit2.Modulate = Color.Color8(255 ,255 ,255);
            }
            else
            {
                timerLineEdit1.Modulate = Color.Color8(255 ,255 ,255);
                timerLineEdit2.Modulate = Color.Color8(0,255 ,0);
            }
        }
    }

    public void _on_swich_button_pressed()
    {
        if (playerTurn == TURN.PLAYER1)
            playerTurn = TURN.PLAYER2;
        else
            playerTurn = TURN.PLAYER1;
    }

    public void _on_start_stop_button_pressed()
    {
        running = !running;

        if (running)
            startStopButton.Text = "Stop";
        else
            startStopButton.Text = "Start";
    }
}
