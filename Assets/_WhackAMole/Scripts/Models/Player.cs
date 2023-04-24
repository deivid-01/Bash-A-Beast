using System;
using UnityEngine;

[Serializable]
public class Player  
{
    [SerializeField] private string name;
    [SerializeField] private int score;

    public Player(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Score
    {
        get => score;
        set => score = value;
    }
}