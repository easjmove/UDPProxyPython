using UDPProxy.Models;

namespace UDPProxy.Managers
{
    public class SpeedTrapsManager
    {
        private static readonly List<SpeedTrap> _data = new List<SpeedTrap>();

        public IEnumerable<SpeedTrap> GetAll()
        {
            return new List<SpeedTrap>(_data);
        }

        public SpeedTrap Add(SpeedTrap newSpeedTrap)
        {
            if (newSpeedTrap.TimeStamp == null)
            {
                newSpeedTrap.TimeStamp = DateTime.Now;
            }
            _data.Add(newSpeedTrap);
            return newSpeedTrap;
        }
    }
}
