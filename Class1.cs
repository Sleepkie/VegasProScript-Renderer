using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;
using ScriptPortal.Vegas;
using System.IO;
namespace ScriptForms
{

}


public class EntryPoint1
{
    public void FromVegas(Vegas vegas)
    {
        FileStream inis = new FileStream("C:\\Users\\DevAcc\\Desktop\\RenderersVegas.txt", FileMode.OpenOrCreate); 
        StreamWriter iniw = new StreamWriter(inis);
        foreach (Renderer renderer in vegas.Renderers)
        {
            string s = renderer.FileExtension + " - " + renderer.FileTypeName + " - " + renderer.ClassID + " - " + renderer.ID;
            iniw.WriteLine(s);
        }

        iniw.Close();
        inis.Close();
    }
}