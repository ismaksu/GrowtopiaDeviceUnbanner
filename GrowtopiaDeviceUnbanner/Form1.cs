using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace GrowtopiaDeviceUnbanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void DeleteReg()
        {
            SetLabel("Status: Working..", Colors.Gray);
            LogToRTB("Removal of reg addresses started...");
            //Remove the first child of HKEY_CURRENT_USER
            RegistryKey key = Registry.CurrentUser; // This gets HKEY_CURRENT_USER
            string[] subKeyNames = key.GetSubKeyNames(); // This gets all the subkeys under HKEY_CURRENT_USER

            if (subKeyNames.Length > 0)
            {
                // To get the first child, you can simply grab the first subkey name
                string firstChildName = subKeyNames[0];
                RegistryKey firstChildKey = key.OpenSubKey(firstChildName);
                if (Regex.IsMatch(firstChildName, @"^\d+$"))
                {
                    key.DeleteSubKey(firstChildName);
                    LogToRTB($"Removed {firstChildName}");
                }
            }

            //Remove the MachineGuid
            string keyPath = @"SOFTWARE\Microsoft\Cryptography";
            string keyName = "MachineGuid";

            try
            {
                LogToRTB("Trying to remove MachineGuid..");
                RegistryKey reg = Registry.LocalMachine;
                var HKLM = reg.OpenSubKey(keyPath, true);
                HKLM.DeleteValue(keyName);
                LogToRTB("Removed MachineGuid successfully!");
            } catch (Exception ex)
            {
                SetLabel("Status: Unsuccessful", Colors.Red);
                LogToRTB($"MachineGuid cannot be removed! {ex.Message}");
            }

            //Remove the first child of HKEY_CURRENT_USER\Software\Microsoft
            try
            {
                LogToRTB("Removal of 2nd HKCU key started...");
                keyPath = @"Software\Microsoft";
                var reg = Registry.CurrentUser;
                var HKCU = reg.OpenSubKey(keyPath, true);
                subKeyNames = HKCU.GetSubKeyNames();

                if (Regex.IsMatch(subKeyNames[0], @"^\d+$"))
                {
                    HKCU.DeleteSubKey(subKeyNames[0]);
                    LogToRTB($"Removed {subKeyNames[0]}");
                }

            }
            catch (Exception ex)
            {
                SetLabel("Status: Unsuccessful", Colors.Red);
                LogToRTB($"2nd HKCU key cannot be removed! {ex.Message}");
            }
            SetLabel("Status: Successful", Colors.Green);

        }

        void LogToRTB(string text)
        {
            string nextLine = $"\n{text}";

            if (string.IsNullOrEmpty(rtbLog.Text))
                rtbLog.Text += text;
            else
                rtbLog.Text += nextLine;
        }

        enum Colors
        {
            Red,
            Green,
            Black,
            Gray
        }

        void SetLabel(string text, Colors color)
        {
            switch (color)
            {
                case Colors.Red:
                    lblStatus.ForeColor = Color.Red;
                    break;
                case Colors.Green:
                    lblStatus.ForeColor = Color.Green;
                    break;
                case Colors.Black:
                    lblStatus.ForeColor = Color.Black;
                    break;
                case Colors.Gray:
                    lblStatus.ForeColor = Color.Gray;
                    break;
                default:
                    lblStatus.ForeColor = Color.Black;
                    break;
            }

            lblStatus.Text = text;
        }

        private void btnChangeReg_Click(object sender, EventArgs e)
        {
            DeleteReg();
        }
    }
}