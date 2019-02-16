﻿using AutumnBox.Basic.Device;
using AutumnBox.OpenFramework.Extension;
using AutumnBox.OpenFramework.LeafExtension;
using AutumnBox.OpenFramework.LeafExtension.Fast;
using AutumnBox.OpenFramework.LeafExtension.Kit;
using System;

namespace AutumnBox_exp_Nexus
{
    [ExtName("清除Google锁")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("清除Google锁，在刷机前未退出谷歌账号的情况下跳过开机谷歌验证")]
    [ExtVersion(1, 0, 0)]
    [ExtIcon("Icons.google.png")]
    class WipeGoogleLock : LeafExtensionBase
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
                var result = device.Fastboot("erase frp");
                leafUI.Finish(result.Item2);
            }
        }
    }
}
