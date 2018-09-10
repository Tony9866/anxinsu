using System;

namespace XGAPI
{
    public class Style
    {
        public Style(int builderId)
            : this(builderId, 0, 0, 1, 0, 1, 0, 1)
        {
        }
        public Style(int builderId, int ring, int vibrate, int clearable, int nId)
        {
            this.m_builderId = builderId;
            this.m_ring = ring;
            this.m_vibrate = vibrate;
            this.m_clearable = clearable;
            this.m_nId = nId;
        }
        public Style(int builderId, int ring, int vibrate, int clearable,
                int nId, int lights, int iconType, int styleId)
        {
            this.m_builderId = builderId;
            this.m_ring = ring;
            this.m_vibrate = vibrate;
            this.m_clearable = clearable;
            this.m_nId = nId;
            this.m_lights = lights;
            this.m_iconType = iconType;
            this.m_styleId = styleId;
        }

        public bool isValid()
        {
            if (m_ring < 0 || m_ring > 1) return false;
            if (m_vibrate < 0 || m_vibrate > 1) return false;
            if (m_clearable < 0 || m_clearable > 1) return false;
            if (m_lights < 0 || m_lights > 1) return false;
            if (m_iconType < 0 || m_iconType > 1) return false;
            if (m_styleId < 0 || m_styleId > 1) return false;

            return true;
        }

        public int m_builderId { get; set; }
        public int m_ring { get; set; }
        public int m_vibrate { get; set; }
        public int m_clearable { get; set; }
        public int m_nId { get; set; }
        public String m_ringRaw { get; set; }
        public int m_lights { get; set; }
        public int m_iconType { get; set; }
        public String m_iconRes { get; set; }
        public int m_styleId { get; set; }
        public String m_smallIcon { get; set; }
    }
}
