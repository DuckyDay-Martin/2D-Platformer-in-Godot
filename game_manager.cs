using Godot;
using System;

public partial class game_manager : Node
{
    int gameScore = 0;

    Label scoreLabel;

    public void AddPoint()
    {
        scoreLabel = GetNode<Label>("ScoreLabel");

        gameScore += 1;
        GD.Print(gameScore);

        scoreLabel.Text = "Great! You have collected " + gameScore.ToString() + " coins";
    }

}
