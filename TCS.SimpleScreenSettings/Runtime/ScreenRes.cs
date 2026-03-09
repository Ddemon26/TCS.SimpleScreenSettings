using UnityEngine;

namespace TCS.SimpleScreenSettings {
    [System.Serializable] internal struct ScreenRes : System.IEquatable<ScreenRes> {
        public int m_screenWidth;
        public int m_screenHeight;
        public FullScreenMode m_fullScreenMode;

        public static bool operator ==(ScreenRes a, ScreenRes b) {
            return a.m_screenWidth
                == b.m_screenWidth && a.m_screenHeight
                == b.m_screenHeight && a.m_fullScreenMode
                == b.m_fullScreenMode;
        }
        public static bool operator !=(ScreenRes a, ScreenRes b) {
            return !(a == b);
        }
        public bool Equals(ScreenRes other)
            => m_screenWidth
                == other.m_screenWidth && m_screenHeight
                == other.m_screenHeight && m_fullScreenMode
                == other.m_fullScreenMode;
        public override bool Equals(object obj)
            => obj is ScreenRes other && Equals(other);
        public override int GetHashCode()
            => System.HashCode.Combine
            (
                m_screenWidth,
                m_screenHeight,
                (int)m_fullScreenMode
            );
    }
}