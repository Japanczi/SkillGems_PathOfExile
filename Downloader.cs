using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;


public static class Downloader
{
    
public static string _url = "https://www.poewiki.net/wiki/List_of_skill_gems";

    public static void DownloadContent()
    {
        HttpClient client = new HttpClient();
        var content = client.GetStringAsync(_url).Result;

        HtmlDocument document = new HtmlDocument();
        document.LoadHtml(content);

        ParseAllGems(document);
        FileHandler.CreateFile();

    }

    private static void ParseAllGems(HtmlDocument document)
    {
        var tables = document.DocumentNode.SelectNodes(".//table");
        for (int index = 0; index < tables.Count; index++)
        {
            var table = tables[index];
            var row = table.SelectNodes("*/tr");
            switch (index)
            {
                case 0:
                    CreateGem(row, Gem.GemColor.green_gem); // class: GreenGem
                    break;
                case 1:
                    CreateGem(row, Gem.GemColor.red_gem); // class: RedGem
                    break;
                case 2:
                    CreateGem(row, Gem.GemColor.blue_gem); // class: BlueGem
                    break;
                case 3:
                    Console.WriteLine("Nothing to see here");
                    break;
            }
        }
    }

    private static void CreateGem(HtmlNodeCollection row, Gem.GemColor gemColor)
    {
        foreach (var item in row)
        {
            if (item.InnerHtml.Contains("<th>Gem</th>"))
                continue;
            var gemName = item.SelectNodes("td/*//a")[0].InnerText;
            int.TryParse(item.SelectSingleNode("td/em").InnerText, out int levelReq);

            switch (gemColor)
            {
                case Gem.GemColor.green_gem:
                    Data.GemList.Add(new GreenGem(gemName, levelReq));
                    break;
                case Gem.GemColor.red_gem:
                    Data.GemList.Add(new RedGem(gemName, levelReq));
                    break;
                case Gem.GemColor.blue_gem:
                    Data.GemList.Add(new BlueGem(gemName, levelReq));
                    break;

            }
            gemName = null;
            levelReq = 1;
            
        }

    }


}

public static class FileHandler
{
    public static void CreateFile()
    {
        using (StreamWriter sw = new StreamWriter("GemData.txt"))
        {
            if (!File.Exists("GemData.txt"))
                File.Create("GemData.txt");

            foreach (var gem in Data.GemList)
            {
                
                sw.WriteLine(gem.ListAllData());
            }

        }
        

        
        
    }
}
