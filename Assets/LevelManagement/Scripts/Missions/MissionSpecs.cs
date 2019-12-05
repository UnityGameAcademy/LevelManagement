using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LevelManagement.Missions
{
    [Serializable]
    public class MissionSpecs 
    {
        #region INSPECTOR
        // long name used in menu
        [SerializeField]
        protected string _name;
        // general mission details
        [SerializeField] [Multiline]
        protected string _description;
        // scene name for loading
        [SerializeField]
        protected string _sceneName;
        // unique identifier for storing data
        [SerializeField]
        protected string _id;
        // image used for menu 
        [SerializeField]
        protected Sprite _image;
        #endregion

        #region PROPERTIES
        public string Name => _name;
        public string Description => _description;
        public string SceneName => _sceneName;
        public string Id => _id;
        public Sprite Image => _image;


        #endregion


    }

}