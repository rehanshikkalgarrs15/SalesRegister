using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRegister.Models {
     class SalesRegisterModel {
        public string billno, partyname, item, bags, rate, amount, gst, sgst, cgst, total;

        public SalesRegisterModel(string billno, string partyname, string item, string bags, string rate, string amount, string gst, string sgst, string cgst, string total)
        {
            this.billno = billno;
            this.partyname = partyname;
            this.item = item;
            this.bags = bags;
            this.rate = rate;
            this.amount = amount;
            this.gst = gst;
            this.sgst = sgst;
            this.cgst = cgst;
            this.total = total;
            getSalesRegisterItem();
        }



        public string BillNo
        {
            get => billno;
            set => billno = value;
        }

        public string PartyName
        {
            get => partyname;
            set => partyname = value;
        }

        public string Item
        {
            get => item;
            set => item = value;
        }

        public string Bags
        {
            get => bags;
            set => bags = value;
        }

        public string Rate
        {
            get => rate;
            set => rate = value;
        }

        public string Amount
        {
            get => amount;
            set => amount = value;
        }

        public string Gst
        {
            get => gst;
            set => gst = value;
        }

        public string SGst
        {
            get => sgst;
            set => sgst = value;
        }

        public string CGst
        {
            get => cgst;
            set => cgst = value;
        }

        public string Total
        {
            get => total;
            set => total = value;
        }

        public List<string> getSalesRegisterItem()
        {
            List<string> salesItem = new List<string>();
            salesItem.Add(billno);
            salesItem.Add(partyname);
            salesItem.Add(item);
            salesItem.Add(bags);
            salesItem.Add(rate);
            salesItem.Add(amount);
            salesItem.Add(gst);
            salesItem.Add(sgst);
            salesItem.Add(cgst);
            salesItem.Add(total);
            return salesItem;
        }

    }
}
