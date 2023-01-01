using Godot;
using System;

public class minibar : Control
{
    [Signal]
    public delegate void  move_mini_panel_to_left();

    [Signal]
    public delegate void move_mini_panel_to_right();

    private double offset;
    private Control rightSide;
    private Control leftSide;
    public override void _Ready()
    {
        offset = GetViewportRect().Size.x / 6.5;

        rightSide = GetNode<Control>("../rightSide");

        leftSide = GetNode<Control>("../leftSide");
    }
    public void _on_TextureButton2_pressed() {
        Vector2 v2 = RectPosition;
        //显示装备栏
        if (rightSide.Visible)
        {
            rightSide.Visible = false;
            //移动minibar位置
            v2.x += (float)offset;
            RectPosition = v2;
            EmitSignal("move_mini_panel_to_right");
        }
        else
        {
            rightSide.Visible = true;
            //移动minibar位置
            v2.x -= (float)offset;
            RectPosition = v2;
            EmitSignal("move_mini_panel_to_left");
        }
    }

    public void _on_TextureButton_pressed()
    {
        Vector2 v2 = RectPosition;
        //显示装备栏
        if (leftSide.Visible)
        {
            leftSide.Visible = false;
            //移动minibar位置
            v2.x -= (float)offset;
            RectPosition = v2;
            EmitSignal("move_mini_panel_to_left");
        }
        else
        {
            leftSide.Visible = true;
            //移动minibar位置
            v2.x += (float)offset;
            RectPosition = v2;
            EmitSignal("move_mini_panel_to_right");
        }
    }

    public void _on_closeleft_pressed()
    {
        Vector2 v2 = RectPosition;
        EmitSignal("move_mini_panel_to_left");
        //显示装备栏
        //移动minibar位置
        v2.x -=(float) offset;
        RectPosition = v2;
        leftSide.Visible = false;
    }


    public void _on_closeright_pressed()
    {
        Vector2 v2 = RectPosition;
        EmitSignal("move_mini_panel_to_right");
        //显示装备栏
        //移动minibar位置
        v2.x += (float)offset;
        RectPosition = v2;
        rightSide.Visible = false;
    }
}
