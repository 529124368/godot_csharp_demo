using Godot;
using System;

public partial class minipanel2 : TextureButton
{

    public override void _Pressed()
    {
        GetNode<Control>("../../minibar").Visible = false;
        GetNode<TextureButton>("../minipanel").Visible = true;
        Visible = false;
    }
}
