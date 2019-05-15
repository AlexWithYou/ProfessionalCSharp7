﻿using System.Collections.Generic;
using System.Linq;

namespace LiveShaping
{
    public class LapChart
    {
        private Formula1 _f1 = new Formula1();
        private List<LapRacerInfo> _lapInfo;
        private int _currentLap = 0;
        private const int PostionOut = 99;
        private int _maxLaps;

        public LapChart()
        {
            FillPositions();
            _lapInfo = SetLapInfoForStart();
        }

        private Dictionary<int, List<int>> _positions = new Dictionary<int, List<int>>();
        private void FillPositions()
        {
            _positions.Add(18, new List<int> { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3, 3, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            _positions.Add(5, new List<int> { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 });
            _positions.Add(10, new List<int> { 3, 5, 5, 5, 5, 5, 5, 5, 5, 4, 4, 9, 7, 6, 6, 5, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 });
            _positions.Add(9, new List<int> { 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 1, 1, 2, 3, 4, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
            _positions.Add(15, new List<int> { 5, 24, 24, 24, 24, 24, 24, 24, 24, 24, 22, 20, 20, 18, 16, 16, 17, 18, 19, 19, 18, 18, 18, 18, 18, 17, 17, 17, 16, 16, 15, 15, 15, 15, 15, 15, 16, 16, 99 });
            _positions.Add(8, new List<int> { 6, 4, 4, 4, 4, 4, 4, 4, 4, 5, 13, 8, 6, 5, 5, 4, 5, 5, 5, 5, 5, 5, 7, 13, 11, 10, 9, 8, 8, 7, 7, 6, 6, 6, 6, 5, 5, 5, 5, 5, 7, 7, 6, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7 });
            _positions.Add(1, new List<int> { 7, 7, 7, 7, 7, 7, 7, 9, 18, 17, 14, 11, 10, 7, 7, 6, 6, 6, 6, 6, 6, 6, 5, 5, 5, 5, 5, 4, 6, 6, 6, 9, 9, 9, 9, 9, 8, 8, 7, 7, 6, 5, 5, 10, 10, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 8, 8, 8, 8, 8, 7, 6, 6, 6 });
            _positions.Add(7, new List<int> { 8, 6, 6, 6, 6, 6, 6, 6, 6, 6, 5, 10, 9, 99 });
            _positions.Add(14, new List<int> { 9, 9, 9, 9, 9, 9, 9, 8, 8, 19, 17, 13, 12, 9, 9, 8, 8, 8, 8, 8, 8, 8, 8, 7, 7, 7, 6, 10, 10, 9, 9, 8, 8, 7, 7, 6, 6, 6, 6, 6, 5, 6, 7, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 5, 5, 5, 5, 5, 5, 5 });
            _positions.Add(3, new List<int> { 10, 8, 8, 8, 8, 8, 8, 7, 7, 7, 15, 12, 11, 8, 8, 7, 7, 7, 7, 7, 7, 7, 6, 6, 6, 6, 10, 9, 9, 8, 8, 7, 7, 8, 8, 7, 7, 7, 8, 14, 11, 9, 9, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9 });
            _positions.Add(2, new List<int> { 11, 12, 12, 12, 12, 12, 14, 22, 20, 20, 18, 14, 13, 11, 10, 9, 9, 15, 17, 17, 17, 17, 16, 16, 14, 14, 13, 12, 12, 11, 11, 11, 11, 11, 11, 11, 10, 10, 10, 8, 9, 13, 13, 12, 12, 12, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 });
            _positions.Add(11, new List<int> { 12, 13, 13, 13, 13, 13, 12, 12, 11, 11, 20, 15, 14, 12, 11, 10, 10, 9, 9, 9, 9, 9, 9, 10, 15, 15, 14, 13, 13, 13, 12, 13, 13, 14, 14, 14, 13, 14, 14, 12, 12, 11, 11, 15, 15, 15, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14 });
            _positions.Add(12, new List<int> { 13, 14, 14, 14, 14, 14, 13, 13, 12, 12, 10, 19, 17, 15, 14, 13, 13, 13, 13, 14, 16, 15, 15, 15, 13, 13, 12, 11, 11, 10, 10, 10, 10, 10, 10, 10, 9, 9, 9, 10, 14, 12, 12, 11, 11, 11, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });
            _positions.Add(17, new List<int> { 14, 10, 10, 10, 10, 10, 10, 10, 9, 8, 7, 16, 15, 13, 12, 11, 11, 10, 10, 10, 10, 10, 10, 12, 16, 16, 15, 14, 14, 14, 13, 12, 12, 12, 12, 12, 11, 11, 11, 11, 13, 15, 15, 14, 14, 14, 13, 13, 13, 13, 13, 13, 13, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12 });
            _positions.Add(16, new List<int> { 15, 15, 15, 15, 15, 15, 15, 15, 14, 13, 9, 6, 19, 16, 15, 15, 15, 14, 14, 13, 13, 13, 13, 11, 10, 11, 16, 15, 15, 15, 14, 14, 14, 13, 13, 13, 12, 12, 12, 15, 15, 14, 14, 13, 13, 13, 12, 12, 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13 });
            _positions.Add(6, new List<int> { 16, 11, 11, 11, 11, 11, 11, 11, 10, 9, 8, 17, 16, 14, 13, 12, 12, 11, 11, 11, 11, 11, 11, 8, 8, 8, 7, 6, 7, 12, 16, 16, 16, 16, 16, 16, 15, 15, 15, 13, 10, 10, 10, 9, 9, 10, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15 });
            _positions.Add(19, new List<int> { 17, 17, 17, 18, 18, 18, 18, 17, 16, 15, 12, 7, 8, 99 });
            _positions.Add(21, new List<int> { 18, 18, 19, 19, 19, 19, 19, 18, 17, 16, 16, 22, 22, 20, 20, 18, 18, 17, 16, 16, 15, 16, 17, 17, 17, 18, 18, 18, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 17, 17, 17, 17, 17, 17, 16, 18, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17 });
            _positions.Add(20, new List<int> { 19, 16, 16, 16, 16, 17, 17, 16, 15, 14, 11, 5, 5, 10, 17, 17, 16, 16, 15, 15, 14, 14, 14, 14, 12, 12, 11, 16, 18, 17, 17, 17, 17, 17, 17, 17, 17, 17, 16, 16, 16, 16, 16, 16, 17, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16 });
            _positions.Add(25, new List<int> { 20, 21, 23, 23, 23, 23, 23, 21, 22, 22, 21, 21, 21, 19, 19, 19, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 19, 20, 20, 20, 20, 20, 20, 20, 20, 99 });
            _positions.Add(24, new List<int> { 21, 19, 20, 20, 20, 20, 20, 19, 19, 18, 19, 18, 18, 17, 18, 20, 19, 19, 18, 18, 19, 19, 19, 19, 19, 19, 19, 20, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 18, 18, 18, 18, 18, 18, 18, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18 });
            _positions.Add(22, new List<int> { 22, 22, 21, 21, 21, 21, 21, 20, 21, 21, 23, 24, 23, 21, 21, 21, 21, 21, 21, 21, 22, 22, 22, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 20, 20, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19 });
            _positions.Add(23, new List<int> { 23, 23, 22, 22, 22, 22, 22, 23, 23, 23, 24, 23, 24, 22, 22, 22, 22, 22, 22, 22, 21, 21, 21, 99 });
            _positions.Add(4, new List<int> { 24, 20, 18, 17, 17, 16, 16, 14, 13, 10, 6, 4, 4, 4, 4, 14, 14, 12, 12, 12, 12, 12, 12, 9, 9, 9, 8, 7, 5, 5, 5, 5, 5, 5, 5, 8, 14, 13, 13, 9, 8, 8, 8, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8 });

            _maxLaps = _positions.Select(p => p.Value.Count).Max() - 1;
        }

        private List<LapRacerInfo> SetLapInfoForStart()
            => _positions.Select(x => new LapRacerInfo(
                _f1.Racers.Where(r => r.Number == x.Key).Single(),
                x.Value.First())).ToList();

        public IEnumerable<LapRacerInfo> GetLapInfo() => _lapInfo;

        public bool NextLap()
        {
            _currentLap++;
            if (_currentLap > _maxLaps) return false;

            foreach (var info in _lapInfo)
            {
                int lastPosition = info.Position;
                var racerInfo = _positions.Where(x => x.Key == info.Racer.Number).Single();

                if (racerInfo.Value.Count > _currentLap)
                {
                    info.Position = racerInfo.Value[_currentLap];
                }
                else
                {
                    info.Position = lastPosition;
                }
                info.PositionChange = GetPositionChange(lastPosition, info.Position);

                info.Lap = _currentLap;
            }
            return true;
        }

        private PositionChange GetPositionChange(int oldPosition, int newPosition)
        {
            if (oldPosition == PostionOut || newPosition == PostionOut)
                return PositionChange.Out;
            else if (oldPosition == newPosition)
                return PositionChange.None;
            else if (oldPosition < newPosition)
                return PositionChange.Down;
            else
                return PositionChange.Up;
        }
    }
}
