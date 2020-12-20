using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class note
    {
        public string Name { get; private set; }
        public string Text { get; private set; }

        public note(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }
}
