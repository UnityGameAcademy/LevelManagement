using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Missions
{
    [CreateAssetMenu(fileName = "MissionList", menuName = "Missions/Create MissionList", order = 1)]
    public class MissionList : ScriptableObject
    {
        #region INSPECTOR
        // collection of mission specifications/details
        [SerializeField] private List<MissionSpecs> _missions;
        #endregion

        #region PROPERTIES
        // total number of missions
        public int TotalMissions => _missions.Count;
        #endregion

        // method to return single mission by index
        public MissionSpecs GetMission(int index)
        {
            return _missions[index];
        }

    }

}