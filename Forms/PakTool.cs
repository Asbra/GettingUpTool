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

namespace GettingUpTool.Forms
{
    public partial class PakTool : Form
    {
        #region Public variables
        #endregion

        #region Private variables
        private TextureTool _mainForm;
        private DirectoryInfo _gamePath;
        #endregion

        #region Constructor
        public PakTool()
        {
            InitializeComponent();
        }

        public PakTool(TextureTool frm)
        {
            _mainForm = frm;
            InitializeComponent();
        }
        #endregion

        private void PakViewer_Load(object sender, EventArgs e)
        {
            // Use current system font, rather than WinForms default font
            this.Font = SystemFonts.MessageBoxFont;

            // So we can just do Encoding GetString and not worry about newlines etc.
            Encoding.GetEncoding("Latin1");

            if (_gamePath == null)
            {
                try
                {
                    if (_mainForm != null)
                        _gamePath = _mainForm.GamePath;
                }
                catch (NullReferenceException _) { }
                try
                {
                    _gamePath = GameFinder.LocateGamePath();
                }
                catch (DirectoryNotFoundException _) { }
            }

            if (_gamePath != null) {
                string path = Path.Combine(_gamePath.FullName, @"engine\allassets.pak");
                byte[] data = File.ReadAllBytes(path);
            }
        }
    }
}
