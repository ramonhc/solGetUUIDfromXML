using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace frmGetUUIDfromXML
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }
    //----------------------------------------------------------------------------------------------------
    private void btnGo_Click(object sender, EventArgs e)
    {
      string msj;
      msj = "Espere...";
      lblMessage.Text = msj;

      if (txtPath.Text.Trim() != string.Empty)
      {
        StringBuilder sb = new StringBuilder();
        DirectoryInfo dir = new DirectoryInfo(txtPath.Text.Trim());
        FileInfo[] files;

        files = dir.GetFiles("*.xml");

        foreach (FileInfo file in files)
        {
          sb.Append(ParseXml(file) + "\r\n");
          //sb.Append(File.ReadAllText(file.FullName).Replace('|',','));
        }

        TextWriter sw = new StreamWriter(txtPath.Text.Trim() + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_UUIDList.csv", false, Encoding.GetEncoding(1252), 512);
        sw.Write(sb.ToString());
        sw.Close();
        msj = "Done!";
      }
      else
      {
        msj = "Seleccione una ruta válida";
      }

      lblMessage.Text = msj;
    }

    //----------------------------------------------------------------------------------------------------
    private static string ParseXml(FileInfo file)
    {
      //H1-DATOS GENERALES DE LOS CFDI´S

      XNamespace cfdi = "http://www.sat.gob.mx/cfd/3";
      XNamespace nomina = "http://www.sat.gob.mx/nomina";
      XNamespace tfd = "http://www.sat.gob.mx/TimbreFiscalDigital";

      XElement root = XElement.Load(file.FullName);
      //var comprobante = (from c in root.Elements(cfdi + "Comprobante") select c).FirstOrDefault();

      var TimbreFiscalDigital = (from c in root.Elements(cfdi + "Complemento").Elements(tfd + "TimbreFiscalDigital") select c).FirstOrDefault();

      string UUID = TimbreFiscalDigital.Attribute("UUID").Value; //0
      string FechaTimbrado = TimbreFiscalDigital.Attribute("FechaTimbrado").Value; //0

      var Emisor = (from c in root.Elements(cfdi + "Emisor") select c).FirstOrDefault();
      string rfcEmisor = Emisor.Attribute("rfc").Value;

      var Receptor = (from c in root.Elements(cfdi + "Emisor") select c).FirstOrDefault();
      string rfcReceptor = Receptor.Attribute("rfc").Value;

      //var Base = (from c in root select c).FirstOrDefault();
      string serie = root.Attribute("serie").Value;
      string folio = root.Attribute("folio").Value;
      string subTotal = root.Attribute("subTotal").Value;
      string Total = root.Attribute("total").Value;

      return FechaTimbrado + "," + UUID + "," + rfcEmisor + "," + rfcReceptor + "," + serie + "," + folio + "," + subTotal + "," + Total;
    }
    //---------------------------------------------------------------------------------------------------------
    private void button1_Click(object sender, EventArgs e)
    {
      string msj;
      msj = "Espere...";
      lblMessage.Text = msj;

      if (txtPath.Text.Trim() != string.Empty)
      {
        StringBuilder sb = new StringBuilder();
        DirectoryInfo dir = new DirectoryInfo(txtPath.Text.Trim());
        FileInfo[] files;

        files = dir.GetFiles("*.xml");

        foreach (FileInfo file in files)
        {
          sb.Append(ParseXmlRetenciones(file) + "\r\n");
          //sb.Append(File.ReadAllText(file.FullName).Replace('|',','));
        }

        TextWriter sw = new StreamWriter(txtPath.Text.Trim() + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_UUIDList.csv", false, Encoding.GetEncoding(1252), 512);
        sw.Write(sb.ToString());
        sw.Close();
        msj = "Done!";
      }
      else
      {
        msj = "Seleccione una ruta válida";
      }

      lblMessage.Text = msj;
    }
    //----------------------------------------------------------------------------------------------------
    private static string ParseXmlRetenciones(FileInfo file)
    {
      //H1-DATOS GENERALES DE LOS CFDI´S

      XNamespace cfdi = "http://www.sat.gob.mx/cfd/3";
      XNamespace nomina = "http://www.sat.gob.mx/nomina";
      XNamespace tfd = "http://www.sat.gob.mx/TimbreFiscalDigital";
      XNamespace retenciones = "http://www.sat.gob.mx/esquemas/retencionpago/1";

      XElement root = XElement.Load(file.FullName);
      //var comprobante = (from c in root.Elements(cfdi + "Comprobante") select c).FirstOrDefault();

      var TimbreFiscalDigital = (from c in root.Elements(retenciones + "Complemento").Elements(tfd + "TimbreFiscalDigital") select c).FirstOrDefault();

      string UUID = TimbreFiscalDigital.Attribute("UUID").Value; //0
      string FechaTimbrado = TimbreFiscalDigital.Attribute("FechaTimbrado").Value; //0

      var Emisor = (from c in root.Elements(retenciones + "Emisor") select c).FirstOrDefault();
      string rfcEmisor = Emisor.Attribute("RFCEmisor").Value;

      var Receptor = (from c in root.Elements(retenciones + "Receptor").Elements(retenciones + "Nacional") select c).FirstOrDefault();
      string rfcReceptor = Receptor.Attribute("RFCRecep").Value;

      return FechaTimbrado + "," + UUID + "," + rfcEmisor + "," + rfcReceptor;
    }

    private void btnCopyFilesByList_Click(object sender, EventArgs e)
    {
      string msj;
      msj = "Espere...";
      lblMessage.Text = msj;

      int coincidences = 0;

      List<string> theList = getList();
      StringBuilder sb = new StringBuilder();

      DirectoryInfo dir = new DirectoryInfo(@"C:\Users\rhernandez.TURIN\Desktop\TAR\");
      FileInfo[] files;

      files = dir.GetFiles("*.xml", SearchOption.AllDirectories);

      foreach (FileInfo file in files)
      {
        foreach (string folio in theList)
        {
          if (fileFieldContains(file, folio))
          {
            file.CopyTo(@"C:\Users\rhernandez.TURIN\Desktop\Nueva carpeta\TAR\" + file.Name);
            sb.Append(file.Name + "," + folio + Environment.NewLine);
            coincidences++;
          }
        }
      }
      TextWriter sw = new StreamWriter(@"C:\Users\rhernandez.TURIN\Desktop\Nueva carpeta\TAR\" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_GE_List.csv", false, Encoding.GetEncoding(1252), 512);
      sw.Write(sb.ToString());
      sw.Close();
      lblMessage.Text = "Done! " + coincidences;
    }
    //----------------------------------------------------------------------
    private bool fileFieldContains(FileInfo file, string _folio)
    {
      //H1-DATOS GENERALES DE LOS CFDI´S

      XNamespace cfdi = "http://www.sat.gob.mx/cfd/3";
      XNamespace nomina = "http://www.sat.gob.mx/nomina";
      XNamespace tfd = "http://www.sat.gob.mx/TimbreFiscalDigital";

      XElement root = XElement.Load(file.FullName);
      //var comprobante = (from c in root.Elements(cfdi + "Comprobante") select c).FirstOrDefault();

      //var TimbreFiscalDigital = (from c in root.Elements(cfdi + "Complemento").Elements(tfd + "TimbreFiscalDigital") select c).FirstOrDefault();

      //string UUID = TimbreFiscalDigital.Attribute("UUID").Value; //0
      //string FechaTimbrado = TimbreFiscalDigital.Attribute("FechaTimbrado").Value; //0

      //var Emisor = (from c in root.Elements(cfdi + "Emisor") select c).FirstOrDefault();
      //string rfcEmisor = Emisor.Attribute("rfc").Value;

      //var Receptor = (from c in root.Elements(cfdi + "Emisor") select c).FirstOrDefault();
      //string rfcReceptor = Receptor.Attribute("rfc").Value;

      //var Base = (from c in root select c).FirstOrDefault();
      //string serie = root.Attribute("serie").Value;
      string folio = root.Attribute("folio").Value;
      //string subTotal = root.Attribute("subTotal").Value;
      //string Total = root.Attribute("total").Value;

      return folio == _folio;

    }
    //-----------------------------------------------------------------------
    private List<string> getList()
    {
      List<string> theList = new List<string>();
      theList.Add("1600007769");
      theList.Add("1600008381");
      theList.Add("1600008654");
      theList.Add("1600008655");
      theList.Add("1600008665");
      theList.Add("1600008757");
      theList.Add("1600008883");
      theList.Add("1600009059");
      theList.Add("1600009060");
      theList.Add("1600009069");
      theList.Add("1600009210");
      theList.Add("1600009211");
      theList.Add("1600009469");
      theList.Add("1600009498");
      theList.Add("1600009688");
      theList.Add("1600009896");
      return theList;
    }
  }
}