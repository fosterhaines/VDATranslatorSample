using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Text.RegularExpressions;

namespace WebApplication
{
    public partial class ShowXMLData : BasePage
    {
        
        protected int _rowId;
        
        protected WebApplication.Models.ProcessTransactions _processTransaction { get; set; }

        protected string _transactionType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["User"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}

            if (this.IsPostBack) return;

            CreateXmlByRowId();
        }

        public void CreateXmlByRowId()
        {

            try
            {
                var showError = false;

                bool processedFlag = false;

                        _processTransaction = new WebApplication.Models.ProcessTransactions();
                        displaytext.InnerText = _processTransaction.DiscoverVDATransactionToXml(ref showError, ref processedFlag);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
               
                displaytext.InnerText = $"An error occurred - Message: {exception.Message}";
            }
        }
        private void AddCloseScript()
        {
            //ClientScript.RegisterStartupScript(typeof(string), "CloseScript", "CloseDialog();", true);
            ClientScript.RegisterStartupScript(typeof(string), "CloseScript", "CloseDialog();", false);

        }
    }
}