using Godot;
using System;

public class minipanel : TextureButton
{
    public override void _Pressed()
    {
        GetNode<Control>("../../minibar").Visible = true;
        GetNode<TextureButton>("../minipanel2").Visible = true;
    }

}
