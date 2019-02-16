using AutumnBox.OpenFramework.Extension;
using AutumnBox.Basic.Device;
using AutumnBox.OpenFramework.Open;
using System;
using AutumnBox.Basic.Calling;

namespace AutumnBox_exp_Nexus
{
    [ExtName("清除Google锁")]
    [ExtRequiredDeviceStates(DeviceState.Fastboot)]
    [ExtTargetApi(8)]
    [ExtMinApi(8)]
    [ExtAuth("神经元")]
    [ExtDesc("清除Google锁，在刷机前未退出谷歌账号的情况下跳过开机谷歌验证")]
    [ExtVersion(1, 0, 0)]
    [ExtIcon("google.png")]
    class WipeGoogleLock : StrictVisualExtension
    {
        protected override int VisualMain()
        {
            using (CommandExecutor executor = new CommandExecutor())
            {
                executor.To((e) => { WriteLine(e.Text); });
                var result = executor.Fastboot(DeviceSelectedOnCreating, "erase frp");
                return result.ExitCode;
            }
        }
    }
}
