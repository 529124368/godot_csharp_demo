using Godot;
using System;

public class loading : AnimatedSprite
{

    public override void _Ready()
    {
        Play("default");
    }
    public override void _Process(float delta)
    {
        if(Frame == 9)
        {

            GetTree().ChangeScene("res://scenes/game/start.tscn");
        }
    }
}
