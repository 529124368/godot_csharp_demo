
using diablo2.script.common;
using Godot;
using Newtonsoft.Json.Linq;
using System.Text;

enum State
{
    // 站立 跑步 攻击
    idle, run,attack
}

public class player : Area2D
{

    [Export(PropertyHint.Range, "0,14")]
    private int direction = 0;
    [Export]
    private float timer_idel = 0.2f;
    [Export]
    private float timer_attack = 0.2f;
    [Export]
    private float timer_run = 0.2f;
    [Export]
    private float timer_flg = 0.2f;
    [Export]
    private float move_speed = 100.0f;
    [Export]
    private float shadow_offset_x = 0.0f;
    [Export]
    private float shadow_offset_y = 0.0f;
    private State state, currenState;
    private JObject json_data = null;
    private Resource img_asset = null;
    private bool is_block = false;
    private int currentSprite = 0;
    private float TIMER_TICK = 0.0f;
    // 站立 跑步 攻击 ->帧数
    private int[] step_nums = { 16, 8, 15};
    //
    private Sprite selfSprite;
    private Sprite selfShadow;
    //
    private StringBuilder stringBox = new StringBuilder();


    //初始化
    public override void _Ready()
    {
        currenState = state = State.run;
        //加载资源
        load_assets("man/ba");
        //获取节点
        selfSprite =  GetNode<Sprite>("Sprite");
        selfShadow = GetNode<Sprite>("shadow");
    }


    //update
    public override void _Process(float delta)
    {
        TIMER_TICK += delta;
        if(TIMER_TICK > timer_flg)
        {
            currentSprite++;
            currentSprite %= step_nums[(int)state];
            render_sprite_and_shadow();
            TIMER_TICK = 0.0f;
        }
        if (Input.IsMouseButtonPressed(2))
        {
            state = State.attack;        
        }
    }

    //加载资源
    public void load_assets(string fileName)
    {
        //json文件加载
        using (File file = new File())
        {
            file.Open("res://assets/"+fileName+ ".json", File.ModeFlags.Read);
            string content = file.GetAsText();
            json_data = JObject.Parse(content);
        }
        //图片加载
        img_asset = ResourceLoader.Load("res://assets/" + fileName + ".png");  
    }

    //渲染精灵和影子
    private void render_sprite_and_shadow(){
        stringBox.Clear();
        stringBox.Append(direction);
        if (!currenState.Equals(state))
        {
            currentSprite = 0;
            currenState = state;
        }
        switch (state)
        {
            case State.idle:
                timer_flg = timer_idel;
                stringBox.Append("_stand_");
                break;
            case State.run:
                timer_flg = timer_run;
                stringBox.Append("_run_");
                break;
            case State.attack:
                timer_flg = timer_attack;
                stringBox.Append("_attack_");
                break;
        }
        stringBox.Append(currentSprite);
        stringBox.Append(".png");
        //获取图片
        selfShadow.Texture = selfSprite.Texture = AltasHelp.getInstance().get_img_by_name(img_asset, json_data, stringBox.ToString()); ;
        //偏移设置
        selfShadow.Position = selfSprite.Position =new Vector2{ 
            x= (float)json_data[stringBox.ToString()]["spriteSourceSize"]["x"]+ (state == State.attack ?-45:0), 
            y= (float)json_data[stringBox.ToString()]["spriteSourceSize"]["y"] + (state == State.attack ? -15 : 0)
        };
    }

    
}
