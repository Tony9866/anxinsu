
namespace XGAPI
{
    public class TimeInterval
    {
        public TimeInterval(int startHour, int startMin, int endHour, int endMin)
        {
            this.m_startHour = startHour;
            this.m_startMin = startMin;
            this.m_endHour = endHour;
            this.m_endMin = endMin;
        }

        public bool isValid()
        {
            if (this.m_startHour >= 0 && this.m_startHour <= 23 &&
                this.m_startMin >= 0 && this.m_startMin <= 59 &&
                this.m_endHour >= 0 && this.m_endHour <= 23 &&
                this.m_endMin >= 0 && this.m_endMin <= 59)
                return true;
            else
                return false;
        }
        public int m_startHour { get; set; }
        public int m_startMin { get; set; }
        public int m_endHour { get; set; }
        public int m_endMin { get; set; }
    }
}
