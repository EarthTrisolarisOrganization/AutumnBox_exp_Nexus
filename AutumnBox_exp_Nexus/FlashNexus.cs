using AutumnBox.Basic.Calling;
using AutumnBox.Basic.Device;
using AutumnBox.Logging;
using AutumnBox.OpenFramework.Extension;
using AutumnBox.OpenFramework.LeafExtension;
using AutumnBox.OpenFramework.LeafExtension.Fast;
using AutumnBox.OpenFramework.LeafExtension.Kit;
using Microsoft.Win32;

namespace AutumnBox_exp_Nexus
{
    [ExtName("Nexus刷入Bootloader")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("给Nexus和Pixel刷入Bootloader.img")]
    [ExtVersion(1, 1, 0)]
    [ExtIcon("Icons.cd.png")]
    internal class FlashNexusBL : LeafExtensionBase
    {
        public void Main(IDevice device, ILeafUI leafUI)
        {
            using (leafUI)
            {
                leafUI.Icon = this.GetIconBytes();
                leafUI.CloseButtonClicked += (s, e) =>
                {
                    e.CanBeClosed = false;
                };
                leafUI.Show();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Reset();
                openFileDialog.Title = "选择一个文件";
                openFileDialog.Filter = "镜像文件(*.img)|*.img|全部文件(*.*)|*.*";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() != true) leafUI.Finish(LeafConstants.ERR_CANCELED_BY_USER);
                leafUI.WriteLine(openFileDialog.FileName);
                using (CommandExecutor executor = new CommandExecutor())
                {
                    executor.To((e) => { leafUI.WriteLine(e.Text); });
                    var result = executor.Fastboot(device, $"flash bootloader \"{openFileDialog.FileName}\"");
                    leafUI.Finish(result.ExitCode);
                }
            }
        }
    }

    [ExtName("Nexus刷入基带")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("给Nexus和Pixel刷入Radio.img")]
    [ExtVersion(1, 1, 0)]
    [ExtIcon("Icons.cd.png")]
    internal class FlashNexusRadio : LeafExtensionBase
    {
        public void Main(IDevice device, ILeafUI leafUI)
        {
            using (leafUI)
            {
                leafUI.Icon = this.GetIconBytes();
                leafUI.CloseButtonClicked += (s, e) =>
                {
                    e.CanBeClosed = false;
                };
                leafUI.Show();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Reset();
                openFileDialog.Title = "选择一个文件";
                openFileDialog.Filter = "镜像文件(*.img)|*.img|全部文件(*.*)|*.*";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() != true) leafUI.Finish(LeafConstants.ERR_CANCELED_BY_USER);
                leafUI.WriteLine(openFileDialog.FileName);
                using (CommandExecutor executor = new CommandExecutor())
                {
                    executor.To((e) => { leafUI.WriteLine(e.Text); });
                    var result = executor.Fastboot(device, $"flash radio \"{openFileDialog.FileName}\"");
                    leafUI.Finish(result.ExitCode);
                }
            }
        }
    }

    [ExtName("Nexus刷入Vendor")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("给Nexus和Pixel刷入vendor.img")]
    [ExtVersion(1, 1, 0)]
    [ExtIcon("Icons.cd.png")]
    internal class FlashNexusVendor : LeafExtensionBase
    {
        public void Main(IDevice device, ILeafUI leafUI)
        {
            using (leafUI)
            {
                leafUI.Icon = this.GetIconBytes();
                leafUI.CloseButtonClicked += (s, e) =>
                {
                    e.CanBeClosed = false;
                };
                leafUI.Show();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Reset();
                openFileDialog.Title = "选择一个文件";
                openFileDialog.Filter = "镜像文件(*.img)|*.img|全部文件(*.*)|*.*";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() != true) leafUI.Finish(LeafConstants.ERR_CANCELED_BY_USER);
                leafUI.WriteLine(openFileDialog.FileName);
                using (CommandExecutor executor = new CommandExecutor())
                    {
                        executor.To((e) => { leafUI.WriteLine(e.Text); });
                        var result = executor.Fastboot(device, $"flash vendor \"{openFileDialog.FileName}\"");
                        leafUI.Finish(result.ExitCode);
                    }
                }
        }
    }

    [ExtName("Nexus刷入System")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("给Nexus和Pixel刷入system.img")]
    [ExtVersion(1, 1, 0)]
    [ExtIcon("Icons.cd.png")]
    internal class FlashNexusSystem : LeafExtensionBase
    {
        public void Main(IDevice device, ILeafUI leafUI)
        {
            using (leafUI)
            {
                leafUI.Icon = this.GetIconBytes();
                leafUI.CloseButtonClicked += (s, e) =>
                {
                    e.CanBeClosed = false;
                };
                leafUI.Show();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Reset();
                openFileDialog.Title = "选择一个文件";
                openFileDialog.Filter = "镜像文件(*.img)|*.img|全部文件(*.*)|*.*";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() != true) leafUI.Finish(LeafConstants.ERR_CANCELED_BY_USER);
                leafUI.WriteLine(openFileDialog.FileName);
                using (CommandExecutor executor = new CommandExecutor())
                {
                    executor.To((e) => { leafUI.WriteLine(e.Text); });
                    var result = executor.Fastboot(device, $"flash system \"{openFileDialog.FileName}\"");
                    leafUI.Finish(result.ExitCode);
                }
            }
        }
    }
}
