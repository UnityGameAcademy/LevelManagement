using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Missions;

namespace LevelManagement
{
    // method to format user interface using MissionSelector
    [RequireComponent(typeof(MissionSelector))]
    public class LevelSelectMenu : Menu<LevelSelectMenu>
    {
        #region INSPECTOR
        // UI elements
        [SerializeField] protected Text _nameText;
        [SerializeField] protected Text _descriptionText;
        [SerializeField] protected Image _previewImage;

        // play button options
        [SerializeField] protected float _playDelay = 0.5f;
        [SerializeField] protected TransitionFader _playTransitionPrefab;
         
        #endregion

        #region PROTECTED
        protected MissionSelector _missionSelector;
        protected MissionSpecs _currentMission;
        #endregion

        protected override void Awake()
        {
            base.Awake();
            _missionSelector = GetComponent<MissionSelector>();
            UpdateInfo();
        }

        private void OnEnable()
        {
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            _currentMission = _missionSelector.GetCurrentMission();

            _nameText.text = _currentMission?.Name;
            _descriptionText.text = _currentMission?.Description;
            _previewImage.sprite = _currentMission?.Image;
            _previewImage.color = Color.white;
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

        public void OnPlayPressed()
        {

            StartCoroutine(PlayMissionRoutine(_currentMission?.SceneName));
        }

        private IEnumerator PlayMissionRoutine(string sceneName)
        {
            TransitionFader.PlayTransition(_playTransitionPrefab);
            LevelLoader.LoadLevel(sceneName);
            yield return new WaitForSeconds(_playDelay);
            GameMenu.Open();
        }


    }

}