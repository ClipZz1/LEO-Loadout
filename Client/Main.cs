using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;

namespace Client
{
    public class Main : BaseScript
    {
        public Main()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);

            API.RegisterCommand("loadout", new Action(LeoLoadout), false);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            Debug.WriteLine($"The resource {resourceName} has been started on the client.");
        }

        private void LeoLoadout()
        {
            Game.PlayerPed.Weapons.RemoveAll();

            Game.PlayerPed.Weapons.Give(WeaponHash.CombatPistol, 250, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.StunGun, 50, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.CarbineRifle, 250, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.PumpShotgun, 25, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.Flashlight, 500, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.Flare, 10, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.Nightstick, 10, false, true);
            Game.PlayerPed.Weapons.Give(WeaponHash.FireExtinguisher, 500, false, true);

            TriggerEvent("chat:addMessage", new
            {
                color = new[] {0, 0, 0},
                args = new[] {"[Server]", $"You have recieved your LEO loadout {Game.Player.Name}."}

            });
        }
    }
}
