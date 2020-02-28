﻿using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace SQLIndexManager {

  public partial class AboutBox : XtraForm {

    public AboutBox() {
      InitializeComponent();

      var assembly = Assembly.GetExecutingAssembly();
      var title = (AssemblyTitleAttribute)assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0];
      var product = (AssemblyProductAttribute)assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0];
      var copyright = (AssemblyCopyrightAttribute)assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0];

      labelProductName.Text = title.Title;
      labelProductDescription.Text = product.Product;
      labelCopyright.Text = copyright.Copyright;
      labelVersion.Text = assembly.GetName().Version.ToString();
    }

    private void Copyright_HyperlinkClick(object sender, HyperlinkClickEventArgs e) {
      RunHyperlink("www.linkedin.com/in/sergiisyrovatchenko");
    }

    private void GitHub_HyperlinkClick(object sender, HyperlinkClickEventArgs e) {
      RunHyperlink("www.github.com/sergiisyrovatchenko/SQLIndexManager");
    }

    private void RunHyperlink(string hyperlink) {
      try {
        Process.Start(hyperlink);
      }
      catch (Exception ex) {
        Output.Current.Add($"Error: {ex.Source}", ex.Message);
        XtraMessageBox.Show(ex.Message.Replace(". ", "." + Environment.NewLine), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #region Override Methods

    protected override bool ProcessDialogKey(Keys keyData) {
      if (keyData == Keys.Escape) {
        Close();
        return true;
      }

      return base.ProcessDialogKey(keyData);
    }


    #endregion

  }

}
