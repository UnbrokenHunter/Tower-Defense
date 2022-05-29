using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TowerDefense
{
    [System.Serializable]
    [ExecuteAlways]
    public class PathScript : MonoBehaviour
    {

        #region Variables
        public GameObject PathScriptObject;
        
        public GameObject PathPointPrefab;

    #endregion

    #region Methods

        void Awake()
        {
        }

        void Update()
        {
			

        }

        [HorizontalGroup("Split", 0.5f)]
        [Button(ButtonSizes.Large), GUIColor(0f, 1f, 0f)]
        private void AddPoint()
        {
            Instantiate(PathPointPrefab);

        }

        [VerticalGroup("Split/right")]
        [Button(ButtonSizes.Large), GUIColor(.7f, 0, 0)]
        private void RemovePoint()
        {
            if (transform.childCount != 0)
            {
                DestroyImmediate(transform.GetChild(transform.childCount - 1).gameObject);

            }
            else
            {
                print("There are no Points to remove!");
            }
        }

        #endregion

    }
}
