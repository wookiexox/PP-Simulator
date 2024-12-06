using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

internal class Animals
{
    private string _description = "";
    public uint Size { get; set; } = 3;

    public string Description
    {
        get { return _description; }
        init
        {
            string trimmedDesc = value.Trim();

            if (string.IsNullOrEmpty(trimmedDesc))
            {
                _description = "Unknown";
            }
            else
            {
                if (trimmedDesc.Length < 3)
                {
                    trimmedDesc = trimmedDesc.PadRight(3, '#');
                }
                else if (trimmedDesc.Length > 15)
                {
                    trimmedDesc = trimmedDesc.Substring(0, 15).TrimEnd();
                    if (trimmedDesc.Length < 3) trimmedDesc.PadRight(3, '#');
                }

                if (char.IsLower(trimmedDesc[0]))
                {
                    trimmedDesc = char.ToUpper(trimmedDesc[0]) + trimmedDesc.Substring(1);
                }

                _description = trimmedDesc;
            }
        }
    }

    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
