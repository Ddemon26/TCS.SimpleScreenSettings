using UnityEngine;

namespace TCS.SimpleScreenSettings {
    [DefaultExecutionOrder(-100)]
    public class SimpleScreenSettings : MonoBehaviour {
        [SerializeField] ScreenRes m_screenRes;
        ScreenRes m_originalScreenRes;
    
        public bool m_vSync;
    
        public int m_fpsLimit = 30; // Dont save this to player prefs.
        public int m_maxFps = 240; // Dont save this to player prefs.
        public int m_fps;
    
        public bool m_isMenuOpen; // Dont save this to player prefs.
        public bool m_limitFpsInMenu;
        public bool m_limitFpsInBackground;

        readonly ScreenSettingsPrefs m_prefs = new();

        public void SetResolution() {
            if (!m_screenRes.Equals(m_originalScreenRes)) {
                m_originalScreenRes = m_screenRes;
                Screen.SetResolution
                (
                    m_screenRes.m_screenWidth,
                    m_screenRes.m_screenHeight,
                    m_screenRes.m_fullScreenMode
                );
            }
        }
    
        public void SetScreenInfo(int width, int height, FullScreenMode fullScreenMode) {
            m_screenRes.m_screenWidth = width;
            m_screenRes.m_screenHeight = height;
            m_screenRes.m_fullScreenMode = fullScreenMode;
        }

        public void SetVSync(bool value) {
            m_vSync = value;
            QualitySettings.vSyncCount = m_vSync ? 1 : 0;
        }

        public void SetFpsLimit(int value) {
            m_fps = Mathf.Clamp(value, m_fpsLimit, m_maxFps);
        
            if (!Application.isFocused) {
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = m_fpsLimit;
            } else {
                QualitySettings.vSyncCount = m_vSync ? 1 : 0;
            
                if (m_limitFpsInMenu) {
                    Application.targetFrameRate = m_isMenuOpen ? m_fpsLimit : m_fps;
                }else{
                    Application.targetFrameRate = m_fps;
                }
            }
        }

        public void SetLimitFpsInBackground(bool value) => m_limitFpsInBackground = value;

        public void SetLimitFpsInMenu(bool value) => m_limitFpsInMenu = value;

        void Awake() {
            var res = Screen.currentResolution;
            m_screenRes = new ScreenRes {
                m_screenWidth = res.width,
                m_screenHeight = res.height,
                m_fullScreenMode = Screen.fullScreenMode,
            };
            m_originalScreenRes = m_screenRes;
        
        
            m_vSync = m_prefs.GetVSync();
            SetVSync(m_vSync);
        
            m_fps = m_prefs.GetFps();
            SetFpsLimit(m_fps);
        
            m_limitFpsInBackground = m_prefs.GetLimitFpsInBackground();
            SetLimitFpsInBackground(m_limitFpsInBackground);
        
            m_limitFpsInMenu = m_prefs.GetLimitFpsInMenu();
            SetLimitFpsInMenu(m_limitFpsInMenu);
        }
    
        void OnApplicationQuit() {
            m_prefs.SetVSync(m_vSync);
            m_prefs.SetFps(m_fps);
            m_prefs.SetLimitFpsInBackground(m_limitFpsInBackground);
            m_prefs.SetLimitFpsInMenu(m_limitFpsInMenu);
        }
    }
}