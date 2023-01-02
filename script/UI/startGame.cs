using Godot;

public class startGame : TextureButton
{

    public override void _Pressed()
    {
        GetTree().ChangeScene("res://scenes/game/opendoor.tscn");
    }

}
