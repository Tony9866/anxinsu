using System;

namespace XGAPI
{
    public class ClickAction
    {
        public ClickAction()
        {
            m_url = "";
            m_actionType = 1;
            m_activity = "";

            m_atyAttrIntentFlag = 0;
            m_atyAttrPendingIntentFlag = 0;

            m_packageDownloadUrl = "";
            m_confirmOnPackageDownloadUrl = 1;
            m_packageName = "";
        }
        public bool isValid()
        {
            if (m_actionType < TYPE_ACTIVITY || m_actionType > TYPE_INTENT) return false;

            if (m_actionType == TYPE_URL)
            {
                if (string.IsNullOrEmpty(m_url) || m_confirmOnUrl < 0 || m_confirmOnUrl > 1) return false;
                return true;
            }
            if (m_actionType == TYPE_INTENT)
            {
                if (string.IsNullOrEmpty(m_intent)) return false;
                return true;
            }
            return true;
        }
        public static readonly int TYPE_ACTIVITY = 1;
        public static readonly int TYPE_URL = 2;
        public static readonly int TYPE_INTENT = 3;

        public int m_actionType { get; set; }
        public String m_url { get; set; }
        public int m_confirmOnUrl { get; set; }
        public String m_activity { get; set; }
        public String m_intent { get; set; }
        public int m_atyAttrIntentFlag { get; set; }
        public int m_atyAttrPendingIntentFlag { get; set; }
        public String m_packageDownloadUrl { get; set; }
        public int m_confirmOnPackageDownloadUrl { get; set; }
        public String m_packageName { get; set; }
    }
}
