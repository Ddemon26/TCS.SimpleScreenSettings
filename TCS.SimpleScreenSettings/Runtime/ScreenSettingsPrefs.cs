using UnityEngine;

namespace TCS.SimpleScreenSettings {
    public class ScreenSettingsPrefs {
        const string K_VSYNC = "VSync";
        const string K_FPS = "Fps";
        const string K_LIMIT_FPS_IN_BACKGROUND = "LimitFpsInBackground";
        const string K_LIMIT_FPS_IN_MENU = "LimitFpsInMenu";

        const bool K_DEFAULT_VSYNC = false;
        const int K_DEFAULT_FPS = 60;
        const bool K_DEFAULT_LIMIT_FPS_IN_BACKGROUND = true;
        const bool K_DEFAULT_LIMIT_FPS_IN_MENU = true;

        public bool GetVSync() => PlayerPrefs.GetInt(K_VSYNC, K_DEFAULT_VSYNC ? 1 : 0) == 1;
        public void SetVSync(bool value) => PlayerPrefs.SetInt(K_VSYNC, value ? 1 : 0);
        public int GetFps() => PlayerPrefs.GetInt(K_FPS, K_DEFAULT_FPS);
        public void SetFps(int value) => PlayerPrefs.SetInt(K_FPS, value);
        public bool GetLimitFpsInBackground() => PlayerPrefs.GetInt(K_LIMIT_FPS_IN_BACKGROUND, K_DEFAULT_LIMIT_FPS_IN_BACKGROUND ? 1 : 0) == 1;
        public void SetLimitFpsInBackground(bool value) => PlayerPrefs.SetInt(K_LIMIT_FPS_IN_BACKGROUND, value ? 1 : 0);
        public bool GetLimitFpsInMenu() => PlayerPrefs.GetInt(K_LIMIT_FPS_IN_MENU, K_DEFAULT_LIMIT_FPS_IN_MENU ? 1 : 0) == 1;
        public void SetLimitFpsInMenu(bool value) => PlayerPrefs.SetInt(K_LIMIT_FPS_IN_MENU, value ? 1 : 0);
    }
}