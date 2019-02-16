using AutumnBox.OpenFramework.Extension;
using AutumnBox.Basic.Device;
using AutumnBox.OpenFramework.Open;
using System;
using AutumnBox.Basic.Calling;
using AutumnBox.OpenFramework.LeafExtension;
using AutumnBox.OpenFramework.LeafExtension.Kit;
using AutumnBox.OpenFramework.LeafExtension.Fast;

namespace AutumnBox_exp_Nexus
{
    [ExtName("解锁Nexus")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("解锁Nexus和Pixel系列手机")]
    [ExtVersion(1,1,0)]
    [ExtIcon("Icons.unlock.png")]
    internal class UnlookNexus : LeafExtensionBase
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
                leafUI.WriteLine(command);
                var result = device.Fastboot(command);
                leafUI.Finish(result.Item2);
            }
        }
    }   
}
