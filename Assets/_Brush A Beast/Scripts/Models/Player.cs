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

    public string Name => name;

    public int Score => score;
}