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
        protected Button _startButton;

        // delay before we play the game
        [SerializeField]
        private float _playDelay = 0.5f;

        // reference to transition prefab
        [SerializeField]
        private TransitionFader _startTransitionPrefab;

        #endregion

        #region PROTECTED
        protected const string _defaultInfo = "COMPLETE PREVIOUS LEVEL TO UNLOCK";
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


            _previewImage.sprite = currentMission.Image;

            _levelNameText.text = currentMission.Name;
            _descriptionText.text = currentMission.Description;
            _infoText.text = string.Empty;

            // check lock status, currently defaulting to off
            _lockIcon.gameObject.SetActive(false);
        }

        public void OnNextPressed()
        {
            _missionSelector.IncrementIndex();
            UpdateInfo();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            MainMenu.Open();
        }

        public void OnPreviousPressed()
        {
            _missionSelector.DecrementIndex();
            UpdateInfo();
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

            // load up the appropriate level after transition
            StartCoroutine(StartMissionRoutine(selectedMission?.SceneName));
        }

        IEnumerator StartMissionRoutine(string sceneName)
        {
            TransitionFader.PlayTransition(_startTransitionPrefab);
            LevelLoader.LoadLevel(sceneName);
            yield return new WaitForSeconds(_playDelay);
            GameMenu.Open();
        }

    }

}