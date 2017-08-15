using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRegister.Models {
    class Item {

        string itemName;
        public Item(string itemName)
        {
            this.itemName = itemName;
        }

        public string ItemName
        {
            get => itemName;
            set => itemName = value;
        }
    }
}
