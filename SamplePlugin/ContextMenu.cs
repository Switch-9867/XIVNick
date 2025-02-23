using Dalamud.Game.Gui.ContextMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVNick
{
    internal class ContextMenu
    {
        public static void Enable()
        {
            DalamudStatic.ContextMenu.OnMenuOpened += OnOpenContextMenu;
        }
        public static void Disable()
        {
            DalamudStatic.ContextMenu.OnMenuOpened -= OnOpenContextMenu;
        }
        private static void OnOpenContextMenu(IMenuOpenedArgs menuArgs)
        {
            if (IsMenuTargetPlayer(menuArgs) == false) return;

        }

        private static bool IsMenuTargetPlayer(IMenuOpenedArgs menuArgs)
        {
            if (menuArgs == null) return false;
            if (menuArgs.MenuType != ContextMenuType.Default) return false;
            if (menuArgs.Target == null) return false;
            MenuTargetDefault? menuTarget = menuArgs.Target as MenuTargetDefault;
            if (menuTarget == null) return false;
            if (menuTarget.TargetObject == null) return false;
            if (menuTarget.TargetObject.ObjectKind != Dalamud.Game.ClientState.Objects.Enums.ObjectKind.Player) return false;

            return true;
        }
    }
}
