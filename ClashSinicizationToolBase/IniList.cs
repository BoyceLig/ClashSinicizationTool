namespace ClashSinicizationToolBase
{
    public class IniList
    {
        public List<string> GetSectionValue(string section, string iniFilePath)
        {
            string[] iniFileTexts = File.ReadAllLines(iniFilePath);
            List<string> currentSectionTexts = new List<string>();
            int currentSectionValue = 100;
            for (int i = 0; i < iniFileTexts.Length; i++)
            {
                if (iniFileTexts[i] == $"[{section}]")
                {
                    currentSectionValue = i;
                }
                if (currentSectionValue < i)
                {
                    if (iniFileTexts[i].StartsWith('['))
                    {
                        break;
                    }
                    if (iniFileTexts[i] != string.Empty)
                    {
                        currentSectionTexts.Add(iniFileTexts[i]);
                    }
                }
            }
            return currentSectionTexts;
        }

        public void AddSectionValue(string section, string iniFilePath, string value)
        {
            List<string> iniFileTexts = new List<string>();
            iniFileTexts = File.ReadAllLines(iniFilePath).ToList();
            bool isSection = false;
            int currentSectionValue = 100;
            for (int i = 0; i < iniFileTexts.Count; i++)
            {
                if (iniFileTexts[i] == $"[{section}]")
                {
                    isSection = true;
                    currentSectionValue = i;
                }
                if (currentSectionValue < i)
                {
                    if (iniFileTexts[i] == value)
                    {
                        return;
                    }
                    if (iniFileTexts[i].StartsWith('['))
                    {
                        break;
                    }
                }
            }
            if (isSection)
            {
                iniFileTexts.Insert(currentSectionValue + 1, value);
                isSection = false;
            }
            else
            {
                iniFileTexts.Add($"[{section}]");
                iniFileTexts.Add(value);
                iniFileTexts.Add(string.Empty);
            }
            File.WriteAllLines(iniFilePath, iniFileTexts);
        }

        public void AddSectionValue(string section, string iniFilePath, string[] values)
        {
            foreach (string item in values)
            {
                AddSectionValue(section, iniFilePath, item);
            }
        }

        public void CleanSectionValue(string section, string iniFilePath)
        {
            List<string> iniFileTexts = new List<string>();
            iniFileTexts = File.ReadAllLines(iniFilePath).ToList();
            int currentSectionValue = 100;
            for (int i = 0; i < iniFileTexts.Count; i++)
            {
                if (iniFileTexts[i] == $"[{section}]")
                {
                    currentSectionValue = i;
                }
                else if (currentSectionValue < i)
                {
                    if (iniFileTexts[i].StartsWith('['))
                    {
                        break;
                    }
                    else if (!File.Exists(iniFileTexts[i]) && !Directory.Exists(iniFileTexts[i]))
                    {
                        if (iniFileTexts[i] != string.Empty)
                        {
                            iniFileTexts.Remove(iniFileTexts[i]);
                        }
                    }
                }
            }
            File.WriteAllLines(iniFilePath, iniFileTexts);
        }
    }
}
