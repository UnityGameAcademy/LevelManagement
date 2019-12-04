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

        #region PROTECTED
        protected const string _defaultInfo = "COMPLETE PREVIOUS LEVEL TO UNLOCK";

        //protected MissionList _missionList;

        #endregion

        protected override void Awake()
        {
            base.Awake();
            _missionSelector = GetComponent<MissionSelector>();

        }

        private void OnEnable()
        {
            UpdateInfo();
        }

        // load up a level by index
        public void Select(int levelIndex)
        {
            _missionSelector.SetIndex(levelIndex);
        }

        public void UpdateInfo()
        {

            MissionSpecs currentMission = _missionSelector?.GetCurrentMission();

            // check if Locked and show lock icon
            _previewImage.sprite = currentMission.Image;

            _levelNameText.text = currentMission.Name;
            _descriptionText.text = currentMission.Description;
            _infoText.text = string.Empty;
        }

        public void OnNextPressed()
        {
            _missionSelector.IncrementIndex();
            UpdateInfo();
        }

        public void OnPreviousPressed()
        {
            _missionSelector.DecrementIndex();
            UpdateInfo();
        }

        public void OnLockedPressed()
        {
            // add notification that this level is locked

        }

        public void OnStartPressed()
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
            LevelLoader.LoadLevel(selectedMission?.SceneName);
        }


    }

}