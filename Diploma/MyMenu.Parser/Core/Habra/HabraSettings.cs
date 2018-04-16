﻿using WindowsFormsApp1.Core;

namespace WindowsFormsApp1.Habra
{
    class HabraSettings : IParserSettings
    {
        public RecipiesSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }


        public string BaseUrl { get; set; } = "https://arborio.ru/recepty/";
        public string Prefix { get; set; } = "page/{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
