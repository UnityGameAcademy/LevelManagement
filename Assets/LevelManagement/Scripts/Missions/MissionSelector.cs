using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Missions
{

    public class MissionSelector : MonoBehaviour
    {
        #region INSPECTOR
        [SerializeField]
        protected MissionList _missionList;
        #endregion

        #region PROTECTED
        protected int _currentIndex = 0;
        #endregion

        #region PROPERTIES
        protected int CurrentIndex => _currentIndex;
        #endregion

        public void ClampIndex()
        {
            if (_missionList.TotalMissions == 0)
            {
                Debug.LogWarning("MISSION SELECTOR ClampIndex: missing mission setup!");
                return;
            }

            if (_currentIndex >= _missionList.TotalMissions)
            {
                _currentIndex = 0;
            }

            if (_currentIndex < 0)
            {
                _currentIndex = _missionList.TotalMissions - 1;
            }
        }

        public void SetIndex (int index)
        {
            _currentIndex = index;
            ClampIndex();
        }

        public void IncrementIndex()
        {
            SetIndex(_currentIndex + 1);
        }

        public void DecrementIndex()
        {
            SetIndex(_currentIndex - 1);
        }

        public MissionSpecs GetMission(int index)
        {
            return _missionList.GetMission(index);
        }

        public MissionSpecs GetCurrentMission()
        {
            return _missionList.GetMission(_currentIndex);
        }
    }

}