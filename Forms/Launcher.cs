using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GettingUpTool.Forms
{
    public partial class Launcher : Form
    {
        #region Public variables
        #endregion

        #region Private variables
        private TextureTool _textureTool;
        private LevelTool _levelTool;
        private PakTool _pakTool;

        private DirectoryInfo _gamePath;
        private string _gameRoot = "engine";
        private string _exePath = string.Empty;

        private Properties.Settings _settings = Properties.Settings.Default;
        #endregion

        #region Constructor
        public Launcher()
        {
            InitializeComponent();
        }

        public Launcher(TextureTool frm)
        {
            _textureTool = frm;
            InitializeComponent();
        }
        #endregion

        #region Load event
        private void Launcher_Load(object sender, EventArgs e)
        {
            // Use current system font, rather than WinForms default font
            this.Font = SystemFonts.MessageBoxFont;

            // So we can just do Encoding GetString and not worry about newlines etc.
            Encoding.GetEncoding("Latin1");

            if (!string.IsNullOrWhiteSpace(_settings.GamePath))
            {
                _gamePath = new DirectoryInfo(_settings.GamePath);
            }

            if (_gamePath == null || !GameFinder.ValidateGamePath(_gamePath))
            {
                _gamePath = null;

                try
                {
                    if (_textureTool != null)
                        _gamePath = _textureTool.GamePath;
                }
                catch (NullReferenceException _) { }
                try
                {
                    _gamePath = GameFinder.LocateGamePath();
                }
                catch (DirectoryNotFoundException _) {
                    MessageBox.Show("Failed to find the game, cannot continue.");
                    Application.Exit();
                    return;
                }

                _settings.GamePath = _gamePath.FullName;
                _settings.Save();
            }

            _exePath = Path.Combine(_gamePath.FullName, @"_Bin\GettingUp.exe");

            if (!string.IsNullOrWhiteSpace(_settings.GameRoot.ToString()))
            {
                _gameRoot = _settings.GameRoot.ToString();
                cmbRootSelect.SelectedText = _gameRoot;
            }

            // TODO: Read default_pc.cfg and vars_pc.cfg

            PopulateLevelSelect(cmbLevelSelect, _gamePath, _gameRoot);

            txtCmdLine.Text = BuildCommandLine();

            txtGamePath.Text = _gamePath.FullName;
        }
        #endregion

        private string BuildCmdArg(string arg, string value)
        {
            if (value == string.Empty) return string.Empty;
            return string.IsNullOrWhiteSpace(value) ? string.Empty : $"{arg}:\"{value}\"";
        }

        private string BuildCmdArg(string arg, int value)
        {
            return $"{arg}:{value}";
        }

        private string BuildCommandArgs()
        {
            List<string> args = new List<string>();

            args.Add(BuildCmdArg("game", "rhapsody"));
            args.Add(BuildCmdArg("root", $"..\\{_gameRoot}")); // cmbRootSelect.SelectedIndex >= 0 ? $"..\\{cmbRootSelect.SelectedItem.ToString()}" : string.Empty));

            /*
            rnd_bones=1
            rnd_brushes=true
            rnd_particleaxis=true
            rnd_particlebounds=true
            rnd_particles=true
            rnd_portals=true
            rnd_reflections=true
            rnd_shadows=true
            rnd_skybox=true
            rnd_stripfx=true
            rnd_water=true
            rnd_wire=true
             */
            args.Add(BuildCmdArg("map", cmbLevelSelect.SelectedIndex >= 0 ? cmbLevelSelect.SelectedItem.ToString() : string.Empty));
            args.Add(BuildCmdArg("player", cmbCharSelect.SelectedIndex >= 0 ? cmbCharSelect.SelectedItem.ToString() : string.Empty));

            string argstr = string.Join(" ", args.ToArray());

            if (string.IsNullOrWhiteSpace(argstr))
                argstr = txtArgs.Text.Trim();
            else
                argstr = $"{argstr.Trim()} {txtArgs.Text.Trim()}";

            return argstr;
        }

        private string BuildCommandLine()
        {
            string exe = _exePath;
            return $"\"{exe}\" {BuildCommandArgs()}".Trim();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (chkClearAssetCache.Checked)
            {
                string path = Path.Combine(_gamePath.FullName, $@"{_gameRoot}\allassets.pak");
                if (File.Exists(path))
                    File.Delete(path);
            }

            _settings.GamePath = _gamePath.FullName;
            _settings.GameRoot = _gameRoot;
            _settings.Save();

            var procGame = new Process();
            procGame.StartInfo.FileName = _exePath;
            procGame.StartInfo.WorkingDirectory = Path.Combine(_gamePath.FullName, "_Bin");
            procGame.StartInfo.UseShellExecute = true;

            string args = BuildCommandArgs();

            procGame.StartInfo.Arguments = args;

            procGame.Start();

            /*
            Thread.Sleep(2000);

            for (int timeout = 0; timeout < 20; timeout++)
            {
                if (GameFinder.IsGameRunning())
                    Application.Exit();

                Thread.Sleep(500);
            }
            */

            Application.Exit();
        }

        private void btnGamePathBrowse_Click(object sender, EventArgs e)
        {
            folderBrowser.Description = "Choose the game folder. This should be the folder containing the \"_Bin\" and \"engine\" folders";
            folderBrowser.ShowNewFolderButton = false;

            DialogResult dresFindGame = folderBrowser.ShowDialog();

            if (dresFindGame == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            {
                DirectoryInfo inpath = new DirectoryInfo(folderBrowser.SelectedPath);

                if (GameFinder.ValidateGamePath(inpath))
                {
                    _settings.GamePath = inpath.FullName;
                    _settings.Save();
                    txtCmdLine.Text = BuildCommandLine();
                }
                else
                {
                    this.Focus();
                    MessageBox.Show("Game not found. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PopulateLevelSelect(ComboBox cmbLevelSelect, DirectoryInfo gamePath, string gameRoot)
        {
            cmbLevelSelect.Items.Clear();

            FileInfo[] files = gamePath.GetFiles($"{gameRoot}/Levels/*.slp", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                cmbLevelSelect.Items.Add(Path.GetFileNameWithoutExtension(file.FullName).ToLower());
            }
        }

        #region Control events
        private void comboBox_CmdArg_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtCmdLine.Text = BuildCommandLine();
        }

        private void cmbRootSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _gameRoot = cmbRootSelect.SelectedIndex >= 0 ? cmbRootSelect.SelectedItem.ToString() : string.Empty;

            if (!string.IsNullOrWhiteSpace(_gameRoot))
            {
                _settings.GameRoot = _gameRoot;
                _settings.Save();
            }

            PopulateLevelSelect(cmbLevelSelect, _gamePath, _gameRoot);

            comboBox_CmdArg_SelectionChangeCommitted(sender, e);
        }

        private void textureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_textureTool == null)
                _textureTool = new TextureTool();
            this.Hide();
            _textureTool.ShowDialog();
            this.Show();
        }

        private void levelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_levelTool == null)
                _levelTool = new LevelTool();
            this.Hide();
            _levelTool.ShowDialog();
            this.Show();
        }

        private void pakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_pakTool == null)
                _pakTool = new PakTool();
            this.Hide();
            _pakTool.ShowDialog();
            this.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(UI.HelpUrl);
        }
        #endregion
    }
}
