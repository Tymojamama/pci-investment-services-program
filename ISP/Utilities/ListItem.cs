using System;

namespace ISP.Presentation.Utilities
{
    public class ListItem
    {
        string displayValue;
        string hiddenValue;
        object hiddenObject;

        //Constructor
        public ListItem(string d, string h)
        {
            displayValue = d;
            hiddenValue = h;
        }

        //Constructor
        public ListItem(string d, object o)
        {
            displayValue = d;
            hiddenObject = o;
        }

        //Accessor
        public string HiddenValue
        {
            get
            {
                return hiddenValue;
            }
        }

        //Accessor
        public object HiddenObject
        {
            get
            {
                return hiddenObject;
            }
        }

        //Override ToString method
        public override string ToString()
        {
            return displayValue;
        }
    }
}
