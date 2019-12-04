using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement.Missions
{

    // handles selecting an item from a wrap around list
    public class MissionSelector : MonoBehaviour
    {
        #region INSPECTOR
        [SerializeField]
        protected MissionList _missionList;
        #endregion

        #region PROTECTED
        protected int _currentIndex = 0;

        #endregion 

        #region properties
        public int CurrentIndex => _currentIndex;
       
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

        public void SetIndex(int index)
        {
            _currentIndex = index;
            ClampIndex();
        }

        public void IncrementIndex()
        {
            _currentIndex++;
            ClampIndex();
        }

        public void DecrementIndex()
        {
            _currentIndex--;
            ClampIndex();
        }
        // return mission specs based on an index
        public MissionSpecs GetMission(int index)
        {
            return _missionList.GetMission(index);
        }

        // return current mission specs
        public MissionSpecs GetCurrentMission()
        {
            return _missionList.GetMission(_currentIndex);
        }

    }

}