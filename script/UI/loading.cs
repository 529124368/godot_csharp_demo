using Godot;
using System;

public partial class loading : AnimatedSprite2D
{

    public override void _Ready()
    {
        Play("default");
    }
    public override void _Process(double delta)
    {
        if(Frame == 9)
        {

            GetTree().ChangeSceneToFile("res://scenes/game/start.tscn");
        }
    }
}
