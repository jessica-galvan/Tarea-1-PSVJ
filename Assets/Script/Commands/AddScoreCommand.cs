using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreCommand : ICommand
{
    private int score;

    public AddScoreCommand(int score)
    {
        this.score = score;
    }

    public void Do()
    {
        ScoreManager.instance.AddScore(score);
    }
}
