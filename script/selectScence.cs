using Godot;


public class selectScence: TextureButton
{
    public override void _Pressed()
    {
        GetTree().ChangeScene("res://scenes/game/selectRole.tscn");
    }
}
