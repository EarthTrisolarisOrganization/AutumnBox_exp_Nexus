using AutumnBox.Basic.Calling;
using AutumnBox.Basic.Device;
using AutumnBox.OpenFramework.Extension;
using Microsoft.Win32;

namespace AutumnBox_exp_Nexus
{
    [ExtName("Nexus刷入Bootloader")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("给Nexus和Pixel刷入Bootloader.img")]
    [ExtVersion(1, 0, 0)]
    [ExtIcon("Icons.cd.png")]
    internal class FlashNexusBL : StrictVisualExtension
    {
        protected override int VisualMain()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Reset();
            openFileDialog.Title = "选择一个文件";
            openFileDialog.Filter = "镜像文件(*.img)|*.img|全部文件(*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() != true) return ERR_CANCELED_BY_USER;
            WriteLine(openFileDialog.FileName);
            using (CommandExecutor executor = new CommandExecutor())
            {
                executor.To((e) => { WriteLine(e.Text); });
                var result = executor.Fastboot(DeviceSelectedOnCreating, $"flash bootloader \"{openFileDialog.FileName}\"");
                return result.ExitCode;
            }
        }
        protected override bool VisualStop()
        {
            base.VisualStop();
            return false;
        }
    }

    [ExtName("Nexus刷入基带")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("给Nexus和Pixel刷入Radio.img")]
    [ExtVersion(1, 0, 0)]
    [ExtIcon("Icons.cd.png")]
    internal class FlashNexusRadio : StrictVisualExtension
    {
        protected override int VisualMain()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Reset();
            openFileDialog.Title = "选择一个文件";
            openFileDialog.Filter = "镜像文件(*.img)|*.img|全部文件(*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() != true) return ERR_CANCELED_BY_USER;
            WriteLine(openFileDialog.FileName);
            using (CommandExecutor executor = new CommandExecutor())
            {
                executor.To((e) => { WriteLine(e.Text); });
                var result = executor.Fastboot(DeviceSelectedOnCreating, $"flash radio \"{openFileDialog.FileName}\"");
                return result.ExitCode;
            }
        }
        protected override bool VisualStop()
        {
            base.VisualStop();
            return false;
        }
    }

    [ExtName("Nexus刷入Vendor")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("给Nexus和Pixel刷入vendor.img")]
    [ExtVersion(1, 0, 0)]
    [ExtIcon("Icons.cd.png")]
    internal class FlashNexusVendor : StrictVisualExtension
    {
        protected override int VisualMain()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Reset();
            openFileDialog.Title = "选择一个文件";
            openFileDialog.Filter = "镜像文件(*.img)|*.img|全部文件(*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() != true) return ERR_CANCELED_BY_USER;
            WriteLine(openFileDialog.FileName);
            using (CommandExecutor executor = new CommandExecutor())
            {
                executor.To((e) => { WriteLine(e.Text); });
                var result = executor.Fastboot(DeviceSelectedOnCreating, $"flash vendor \"{openFileDialog.FileName}\"");
                return result.ExitCode;
            }
        }
        protected override bool VisualStop()
        {
            base.VisualStop();
            return false;
        }
    }

    [ExtName("Nexus刷入System")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("给Nexus和Pixel刷入system.img")]
    [ExtVersion(1, 0, 0)]
    [ExtIcon("Icons.cd.png")]
    internal class FlashNexusSystem : StrictVisualExtension
    {
        protected override int VisualMain()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Reset();
            openFileDialog.Title = "选择一个文件";
            openFileDialog.Filter = "镜像文件(*.img)|*.img|全部文件(*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() != true) return ERR_CANCELED_BY_USER;
            WriteLine(openFileDialog.FileName);
            using (CommandExecutor executor = new CommandExecutor())
            {
                executor.To((e) => { WriteLine(e.Text); });
                var result = executor.Fastboot(DeviceSelectedOnCreating, $"flash system \"{openFileDialog.FileName}\"");
                return result.ExitCode;
            }
        }
        protected override bool VisualStop()
        {
            base.VisualStop();
            return false;
        }
    }
}
