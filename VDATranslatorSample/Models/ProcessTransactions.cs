using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Globalization;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using nsoftware.IPWorksEDITranslator;
using Vdatranslator = nsoftware.IPWorksEDITranslator.Vdatranslator;
using VdatranslatorOutputFormats = nsoftware.IPWorksEDITranslator.VdatranslatorOutputFormats;
using VdatranslatorSchemaFormats = nsoftware.IPWorksEDITranslator.VdatranslatorSchemaFormats;
using nsoftware.async.IPWorksEDITranslator;
using VdatranslatorInputFormats = nsoftware.IPWorksEDITranslator.VdatranslatorInputFormats;

namespace WebApplication.Models
{

    public class ProcessTransactions
    {
        public string DiscoverVDATransactionToXml(ref bool showError, ref bool processedFlag)
        {
            string displayText = string.Empty;
            string transactionType = string.Empty;
            string transactionVersion = string.Empty;

            try
            {
                var rawEdi = "71103E75      16079712 0732107322170707                                                                                         \n7120300605592160             17070716000009830000349401 0048001LKW                                            1707081200000     \n7130300605592170707E75 03    8659231     18               000000000                                                             \n714037380285-06 7380285-060610000000040000ST0000006260000ST 001 S T                                                             \n71602                                                                                                                           \n715036207708 6207708000000000000200100000000200000039318410039318420000000000000 S                                              \n7130300605592170707E75 03 8659260 180                                                                                           \n714037380286-06 7380286-060610000000160000ST0000006980000ST 002 S T                                                             \n71602                                                                                                                           \n715036207708 6207708000000000000800200000000200000039318430039318500000000000000 S                                              \n7130300605592170707E75 03 8659314 180                                                                                           \n714037380287-06 7380287-060610000000040000ST0000011440000ST 003 S T                                                             \n71602                                                                                                                           \n715036207708 6207708000000000000200300000000200000039318510039318520000000000000 S                                              \n7130300605592170707E75 03 8659348 180                                                                                           \n714037380288-06 7380288-060610000000720000ST0000030060000ST 004 S T                                                             \n71602                                                                                                                           \n715036207708 6207708000000000003600400000000200000039318530039318880000000000000 S                                              \n71902000000100000010000004000000400000040000004000000000000010000000                                                           ";

                    transactionType = "4913";

                    Vdatranslator vdatranslator = new Vdatranslator();

                    //vdatranslator.SchemaFormat = VdatranslatorSchemaFormats.schemaAltova;
                    //vdatranslator.LoadSchema(HttpContext.Current.Server.MapPath($@".\Models\{transactionType}.Config"));
                    
                    vdatranslator.SchemaFormat = VdatranslatorSchemaFormats.schemaJSON;
                    vdatranslator.LoadSchema(HttpContext.Current.Server.MapPath($@".\Models\{transactionType}.json"));

                    var schemaInfo = vdatranslator.DisplaySchemaInfo();

                    vdatranslator.InputData = rawEdi;
                    vdatranslator.InputFormat = VdatranslatorInputFormats.vifVDA;
                    vdatranslator.OutputFormat = VdatranslatorOutputFormats.vofXML;

                    // This is supposed to remove the xmlns attribute
                    vdatranslator.Config("Namespace=");

                    vdatranslator.Translate();
                    
                    displayText = vdatranslator.OutputData;
                
            }
            catch (Exception ex)
            {
                displayText =
                    $"Exception Information: {ex.Message}\nStack Trace: {ex.StackTrace}";
                //throw;
            }
            finally
            {

            }

            return displayText;
        }

    }
}
