using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Missions
{
    // class that selects a single element from a MissionList
    public class MissionSelector : MonoBehaviour
    {
        #region INSPECTOR
        // reference to MissionList Asset file
        [SerializeField] protected MissionList _missionList;
        #endregion

        #region PROTECTED
        // currently selected element
        protected int _currentIndex = 0;
        #endregion

        #region PROPERTIES
        protected int CurrentIndex => _currentIndex;
        #endregion

        // method to clamp currently selected element to a valid position in the list
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

        // set a specific valid index as the currently selected element
        public void SetIndex (int index)
        {
            _currentIndex = index;
            ClampIndex();
        }

        // increment selected element by one
        public void IncrementIndex()
        {
            SetIndex(_currentIndex + 1);
        }

        // decrement selected element by one
        public void DecrementIndex()
        {
            SetIndex(_currentIndex - 1);
        }

        // 
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