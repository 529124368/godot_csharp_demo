using Godot;


public partial class selectScence: TextureButton
{
    public override void _Pressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/game/selectRole.tscn");
    }
}
