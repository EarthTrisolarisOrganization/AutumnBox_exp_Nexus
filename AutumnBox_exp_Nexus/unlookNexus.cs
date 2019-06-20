using AutumnBox.OpenFramework.Extension;
using AutumnBox.Basic.Device;
using AutumnBox.OpenFramework.Open;
using System;
using AutumnBox.Basic.Calling;
using AutumnBox.OpenFramework.LeafExtension;
using AutumnBox.OpenFramework.LeafExtension.Kit;
using AutumnBox.OpenFramework.LeafExtension.Fast;
using Microsoft.VisualBasic;

namespace AutumnBox_exp_Nexus
{
    [ExtName("解锁手机")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("解锁手机Bootloader")]
    [ExtVersion(1,1,0)]
    [ExtIcon("Icons.unlock.png")]
    internal class UnlookNexus : LeafExtensionBase
    {
        public void Main(IDevice device, ILeafUI leafUI)
        {
            using (leafUI)
            {
                leafUI.Icon = this.GetIconBytes();
                leafUI.Closing += (s, e) =>
                {
                    return false;
                };
                leafUI.Show();
                var choiceResult = leafUI.DoChoice("请选择您的设备\n新设备：Nexus 5X，Nexus 6P，Pixel，Pixel XL，Pixel 2或Pixel 2 XL设备\n旧设备：其他15年之前生产的设备", "新设备", "旧设备", "取消");
                String command = null;
                switch (choiceResult)
                {
                    case null:
                        leafUI.Finish(LeafConstants.ERR_CANCELED_BY_USER);
                        break;
                    case false:
                        command = "flashing unlock";
                        break;
                    case true:
                        command = "oem unlock";
                        break;
                }
                if (command == null) leafUI.Finish(LeafConstants.ERR);
                string code = Interaction.InputBox("请输入解锁码，无需解锁码请留空","输入解锁码");
                if (code != null || code != "") command += " " + code;
                leafUI.WriteLine(command);
                using (CommandExecutor executor = new CommandExecutor())
                {
                    executor.To((e) => { leafUI.WriteLine(e.Text); });
                    var result = executor.Fastboot(device,command);
                    leafUI.Finish(result.ExitCode);
                }
            }
        }
    }   
}
