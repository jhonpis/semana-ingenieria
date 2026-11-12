using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace el_amparo
{
    internal static class Program
    {
        private const string ApiHomeMarker = "Sociedad Protectora de Animales El Amparo";

        [STAThread]
        static void Main()
        {
            Process apiProcess = null;
            try
            {
                Uri apiUri = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"].TrimEnd('/') + "/");
                string apiPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\API"));
                if (!Directory.Exists(apiPath))
                    throw new DirectoryNotFoundException("No se encontró la carpeta de la API: " + apiPath);

                if (!IsApiReady(apiUri))
                {
                    string iisExpressPath = FindIisExpress();
                    apiProcess = StartApi(iisExpressPath, apiPath, apiUri);
                    WaitForApi(apiProcess, apiUri);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "No se pudo iniciar El Amparo.\r\n\r\n" + exception.Message,
                    "Error al iniciar El Amparo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (apiProcess != null)
                {
                    if (!apiProcess.HasExited)
                    {
                        apiProcess.Kill();
                        apiProcess.WaitForExit();
                    }
                    apiProcess.Dispose();
                }
            }
        }

        private static string FindIisExpress()
        {
            string[] programFiles =
            {
                Environment.GetEnvironmentVariable("ProgramW6432"),
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
            };

            foreach (string directory in programFiles)
            {
                if (String.IsNullOrEmpty(directory))
                    continue;

                string standardPath = Path.Combine(directory, "IIS Express", "iisexpress.exe");
                if (File.Exists(standardPath))
                    return standardPath;

                string visualStudioRoot = Path.Combine(directory, "Microsoft Visual Studio");
                if (!Directory.Exists(visualStudioRoot))
                    continue;

                foreach (string versionDirectory in Directory.GetDirectories(visualStudioRoot))
                foreach (string editionDirectory in Directory.GetDirectories(versionDirectory))
                {
                    string visualStudioPath = Path.Combine(editionDirectory, @"Common7\IDE\IISExpress\iisexpress.exe");
                    if (File.Exists(visualStudioPath))
                        return visualStudioPath;
                }
            }

            throw new FileNotFoundException("No se encontró IIS Express. Instale IIS Express desde Visual Studio Installer.");
        }

        private static Process StartApi(string iisExpressPath, string apiPath, Uri apiUri)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = iisExpressPath,
                Arguments = "/path:\"" + apiPath + "\" /port:" + apiUri.Port + " /systray:false",
                WorkingDirectory = apiPath,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            Process process = new Process { StartInfo = startInfo };
            if (!process.Start())
                throw new InvalidOperationException("No se pudo iniciar IIS Express.");

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            return process;
        }

        private static void WaitForApi(Process apiProcess, Uri apiUri)
        {
            DateTime deadline = DateTime.UtcNow.AddSeconds(30);
            while (DateTime.UtcNow < deadline)
            {
                if (apiProcess.HasExited)
                    throw new InvalidOperationException("IIS Express se cerró antes de que la API estuviera disponible.");

                if (IsApiReady(apiUri))
                    return;

                Thread.Sleep(500);
            }

            throw new TimeoutException("La API no respondió en " + apiUri + " después de 30 segundos.");
        }

        private static bool IsApiReady(Uri apiUri)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUri);
                request.Method = "GET";
                request.Timeout = 2000;
                request.Proxy = null;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    return response.StatusCode == HttpStatusCode.OK && reader.ReadToEnd().Contains(ApiHomeMarker);
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
