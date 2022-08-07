using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;


public class Gem
{
    protected string Name { get; set; } = "N/A";

    protected string Description { get; set; } = "N/A";

    protected int LevelReq { get; set; } = 1;
    protected int LevelCurrent { get; set; } = 1;

    protected int AttrStrength { get; set; } = 0;
    protected int AttrDexterity { get; set; } = 0;
    protected int AttrIntelligence { get; set; } = 0;
    public GemType Type { get; set; }
    public enum GemType
    {
        active_gem = 1,
        support_gem = 2
    }
    
    public enum GemColor
    {
        green_gem,
        red_gem,
        blue_gem
    }

    public string ListAllData()
    {
        string result = string.Join(';', Name, Description, LevelReq, LevelCurrent, AttrStrength, AttrDexterity, AttrIntelligence, Type);

        return result;
    }
}

public class RedGem : Gem
{
    public RedGem(string inputName, int levelReq)
    {
        Name = inputName;
        LevelReq = levelReq;
        Type = GemType.active_gem;
        AttrStrength = 16;
    }

    
}

public class BlueGem : Gem
{
    public BlueGem(string inputName, int levelReq)
    {
        Name = inputName;
        LevelReq = levelReq;
        Type = GemType.active_gem;
        AttrIntelligence = 16;
    }
}

public class GreenGem : Gem
{
    public GreenGem(string inputName, int levelReq)
    {
        Name = inputName;
        LevelReq = levelReq;
        Type = GemType.active_gem;
        AttrDexterity = 16;
    }


}


    public static class Data
    {
        public static List<Gem> GemList = new();
    }


