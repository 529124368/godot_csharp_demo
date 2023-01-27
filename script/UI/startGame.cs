using Godot;

public partial class startGame : TextureButton
{

    public override void _Pressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/game/opendoor.tscn");
    }

}
