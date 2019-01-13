using AutumnBox.OpenFramework.Extension;
using AutumnBox.Basic.Device;
using AutumnBox.OpenFramework.Open;
using System;
using AutumnBox.Basic.Calling;

namespace AutumnBox_exp_Nexus
{
    [ExtName("解锁Nexus")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("解锁Nexus和Pixel系列手机")]
    [ExtVersion(1,0,0)]
    [ExtIcon("Icons.unlock.png")]
    internal class UnlookNexus : StrictVisualExtension
    {
        protected override int VisualMain()
        {
            ChoiceResult choiceResult = Ux.DoChoice("请选择您的设备\n新设备：Nexus 5X，Nexus 6P，Pixel，Pixel XL，Pixel 2或Pixel 2 XL设备\n旧设备：其他15年之前生产的设备", "新设备", "旧设备", "取消");
            String command = null;
            switch (choiceResult)
            {
                case ChoiceResult.Cancel:
                    return ERR_CANCELED_BY_USER;
                case ChoiceResult.Left:
                    command = "flashing unlock";
                    break;
                case ChoiceResult.Right:
                    command = "oem unlock";
                    break;
            }
            if (command == null) return ERR;
            WriteLine(command);
            using (CommandExecutor executor = new CommandExecutor())
            {
                executor.To((e) => { WriteLine(e.Text); });
                var result = executor.Fastboot(DeviceSelectedOnCreating, command);
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
