using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace el_amparo
{
    internal sealed class LauncherForm : Form
    {
        private readonly Button desktopButton;
        private readonly Button apiButton;
        private readonly Label statusLabel;

        public LauncherForm()
        {
            Text = "El Amparo - Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(480, 300);
            Font = new Font("Segoe UI", 9F);

            Label titleLabel = new Label
            {
                AutoSize = false,
                Text = "El Amparo",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 107, 135),
                Location = new Point(28, 22),
                Size = new Size(420, 40)
            };

            Label instructionsLabel = new Label
            {
                AutoSize = false,
                Text = "Seleccione qué desea iniciar. El escritorio y la API se ejecutan por separado.",
                Location = new Point(30, 72),
                Size = new Size(420, 42)
            };

            desktopButton = new Button
            {
                Text = "Aplicación de escritorio",
                Location = new Point(30, 130),
                Size = new Size(200, 46),
                BackColor = Color.FromArgb(23, 107, 135),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            desktopButton.Click += StartDesktop;

            apiButton = new Button
            {
                Text = "API en el navegador",
                Location = new Point(250, 130),
                Size = new Size(200, 46),
                BackColor = Color.FromArgb(23, 107, 135),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            apiButton.Click += StartApi;

            statusLabel = new Label
            {
                AutoSize = false,
                Text = "Nota: algunas consultas y operaciones del escritorio requieren que la API ya esté iniciada.",
                ForeColor = Color.DimGray,
                Location = new Point(30, 198),
                Size = new Size(420, 58)
            };

            Controls.Add(titleLabel);
            Controls.Add(instructionsLabel);
            Controls.Add(desktopButton);
            Controls.Add(apiButton);
            Controls.Add(statusLabel);
        }

        private void StartDesktop(object sender, EventArgs e)
        {
            Hide();
            using (Form1 desktop = new Form1())
                desktop.ShowDialog(this);
            Close();
        }

        private void StartApi(object sender, EventArgs e)
        {
            string launcherPath = FindApiLauncher();
            if (launcherPath == null)
            {
                MessageBox.Show(
                    "No se encontró ElAmparo-Local\\IniciarApi.bat.",
                    "No se encontró el lanzador de la API",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = launcherPath,
                    WorkingDirectory = Path.GetDirectoryName(launcherPath),
                    UseShellExecute = true
                });
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "No se pudo iniciar la API.\r\n\r\n" + exception.Message,
                    "Error al iniciar la API",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static string FindApiLauncher()
        {
            DirectoryInfo directory = new DirectoryInfo(Application.StartupPath);
            while (directory != null)
            {
                string localLauncher = Path.Combine(directory.FullName, "IniciarApi.bat");
                if (File.Exists(localLauncher) && Directory.Exists(Path.Combine(directory.FullName, "API")))
                    return localLauncher;

                string repositoryLauncher = Path.Combine(directory.FullName, "ElAmparo-Local", "IniciarApi.bat");
                if (File.Exists(repositoryLauncher))
                    return repositoryLauncher;

                directory = directory.Parent;
            }

            return null;
        }
    }
}
