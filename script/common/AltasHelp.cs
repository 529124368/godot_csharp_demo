using Godot;
using JsonType = Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, float>>>;

namespace diablo2.script.common
{
    
    internal class AltasHelp
    {
        private static AltasHelp my = null;
        public static AltasHelp getInstance()
        {
            if(my is null)
            {
                 my = new AltasHelp();
            }
            return my;
        }

        public AtlasTexture get_img_by_name(Resource tx, JsonType jsonData,string imgName)
        {
            AtlasTexture tool = new AtlasTexture
            {
                Atlas = tx as Texture2D
            };
            Vector2 v2,size;
            v2.x = (float)jsonData[imgName]["frame"]["x"];
            v2.y = (float)jsonData[imgName]["frame"]["y"];
            size.x = (float)jsonData[imgName]["frame"]["w"];
            size.y = (float)jsonData[imgName]["frame"]["h"];
            Rect2 r2 = new Rect2
            {
                Position = v2,
                Size = size
            };
            tool.Region = r2;
            return tool;
        }
    }
}
