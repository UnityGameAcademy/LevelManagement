using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement.Missions
{

    public class LevelSelectMenu : Menu<LevelSelectMenu>
    {


        #region  INSPECTOR

        [SerializeField]
        protected MissionSelector _missionSelector; 

        [SerializeField]
        protected Image _previewImage;
        [SerializeField]
        protected Text _levelNameText;
        [SerializeField]
        protected Text _descriptionText;
        [SerializeField]
        protected Text _infoText;
        [SerializeField]
        protected GameObject _lockIcon;
        [SerializeField]
        protected Button _playButton;
        #endregion

        private void SetLevelName()
        {

        }

        private void SetImage(Sprite image)
        {

        }

        // load up a level by index
        public void Select(int levelIndex)
        {

        }

 
        

        public void OnLockedPressed()
        {
            // add notification that this level is locked
        }

        public void OnPlayPressed()
        {
            if (_missionSelector == null)
            {
                Debug.LogError("LEVELSELECTMENU OnPlayPressed: missing mission selector");
                return;
            }
            MissionSpecs selectedMission = _missionSelector?.GetCurrentMission();
            

            // return if locked

            // handle any pre-processing

            // load up the appropriate level

        }


    }

}