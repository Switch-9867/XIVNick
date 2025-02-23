using Dalamud.Interface.Windowing;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace XIVNick.Windows
{
    internal class AddNickPopupWindow
    {

        private static string WindowName = "Add Nickname";

        private static string PlayerToAddNicknameTo = "";

        internal static void Open(string playerToAddNicknameTo)
        {
            PlayerToAddNicknameTo = playerToAddNicknameTo;
            ImGui.OpenPopup(WindowName);
        }
        internal static void Draw()
        {
            Vector2 center = ImGui.GetMainViewport().GetCenter();
            ImGui.SetNextWindowPos(center);

            bool t = true;
            if (ImGui.BeginPopupModal(WindowName, ref t, ImGuiWindowFlags.AlwaysAutoResize))
            {
                ImGui.Text("All those beautiful files will be deleted.\nThis operation cannot be undone!");
                ImGui.Separator();

                static bool dont_ask_me_next_time = false;
                ImGui.PushStyleVar(ImGuiStyleVar_FramePadding, ImVec2(0, 0));
                ImGui.Checkbox("Don't ask me next time", &dont_ask_me_next_time);
                ImGui.PopStyleVar();

                if (ImGui.Button("OK", ImVec2(120, 0))) { ImGui.CloseCurrentPopup(); }
                ImGui.SetItemDefaultFocus();
                ImGui.SameLine();
                if (ImGui.Button("Cancel", ImVec2(120, 0))) { ImGui.CloseCurrentPopup(); }
                ImGui.EndPopup();
            }
        }
    }
}
