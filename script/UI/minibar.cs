using Godot;
using System;

public partial class minibar : Control
{
    [Signal]
    public delegate void move_mini_panel_to_leftEventHandler();

    [Signal]
    public delegate void move_mini_panel_to_rightEventHandler();

    private double offset;
    private Control rightSide;
    private Control leftSide;
    public override void _Ready()
    {
        offset = GetViewportRect().Size.x / 6.5;

        rightSide = GetNode<Control>("../rightSide");

        leftSide = GetNode<Control>("../leftSide");
    }
    public void _on_textureButton2_pressed() {
        Vector2 v2 = Position;
        //显示装备栏
        if (rightSide.Visible)
        {
            rightSide.Visible = false;
            //移动minibar位置
            v2.x += (float)offset;
            Position = v2;
            EmitSignal("move_mini_panel_to_rightEventHandler");
        }
        else
        {
            rightSide.Visible = true;
            //移动minibar位置
            v2.x -= (float)offset;
            Position = v2;
            EmitSignal("move_mini_panel_to_leftEventHandler");
        }
    }

    public void _on_textureButton_pressed()
    {
        Vector2 v2 = Position;
        //显示装备栏
        if (leftSide.Visible)
        {
            leftSide.Visible = false;
            //移动minibar位置
            v2.x -= (float)offset;
            Position = v2;
            EmitSignal("move_mini_panel_to_leftEventHandler");
        }
        else
        {
            leftSide.Visible = true;
            //移动minibar位置
            v2.x += (float)offset;
            Position = v2;
            EmitSignal("move_mini_panel_to_rightEventHandler");
        }
    }

    public void _on_closeleft_pressed()
    {
        Vector2 v2 = Position;
        EmitSignal("move_mini_panel_to_leftEventHandler");
        //显示装备栏
        //移动minibar位置
        v2.x -=(float) offset;
        Position = v2;
        leftSide.Visible = false;
    }


    public void _on_closeright_pressed()
    {
        Vector2 v2 = Position;
        EmitSignal("move_mini_panel_to_rightEventHandler");
        //显示装备栏
        //移动minibar位置
        v2.x += (float)offset;
        Position = v2;
        rightSide.Visible = false;
    }
}
