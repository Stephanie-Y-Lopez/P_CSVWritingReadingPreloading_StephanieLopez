using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_CSVWritingReadingPreloading_StephanieLopez
{
    internal class Creature
    {
        //Fields
        public string _Type;
        public string _Element;
        public string _Weapon;

        //Default Constructor
        public Creature() { }

        //Constructor
        public Creature(string type, string element, string weapon)
        {
            _Type = type;
            _Element = element;
            _Weapon = weapon;
        }

        //Properties
        public string Type { get => _Type; set => _Type = value; }
        public string Element { get => _Element; set => _Element = value; }
        public string Weapon { get => _Weapon; set => _Weapon = value; }

        ////Display
        //public override string ToString()
        //{
        //    return $"Creature Type: {_Type} - Element Type: {_Element} - Weapon Type: {_Weapon}";
        //}
    }
}
