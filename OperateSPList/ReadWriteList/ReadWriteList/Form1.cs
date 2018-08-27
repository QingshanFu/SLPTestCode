using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm = System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace ReadWriteList
{
    public partial class Form1 : WinForm.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            Microsoft.SharePoint.Client.

            string sQuery = @"<Query><Where><BeginsWith><FieldRef Name=""Title""></FieldRef><Value Type=""Text"">Test</Value></BeginsWith></Where></Query>";
            string sViewFields = @"<FieldRef Name=""Title"" />";
            string sViewAttrs = @"Scope=""Recursive""";
            uint iRowLimit = 100;

            var oQuery = new SPQuery();
            oQuery.Query = sQuery;
            oQuery.ViewFields = sViewFields;
            oQuery.ViewAttributes = sViewAttrs;
            oQuery.RowLimit = iRowLimit;

            SPListItemCollection collListItems = oList.GetItems(oQuery);

            foreach (SPListItem oListItem in collListItems)
            {
            }

        }
    }
}
