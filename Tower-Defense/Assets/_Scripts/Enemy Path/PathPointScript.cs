using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

namespace TowerDefense
{
    [ExecuteAlways]
    public class PathPointScript : MonoBehaviour
    {

        #region Variables

        // Index
        public int index;
        //[HideInInspector]
        public GameObject nextPoint;
        public bool hasNext = false;
        public bool hasLoaded = false;


        // Stats
        [Range(0, 2)]
        public float speed = 0.1f;

    #endregion


    #region Methods

        void Awake()
        {
            if(!Application.isPlaying && !hasLoaded)
			{
                
                gameObject.transform.parent = GameObject.Find("Enemy Path").transform;
                index = transform.hierarchyCount - 1;
                gameObject.name = "Point " + index;
                hasLoaded = true;
			}
        }

		private void OnDrawGizmos()
		{

            if (hasNext)
            {
                gameObject.name = "Point " + index;

                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, nextPoint.transform.position);

            }
            else 
            {
                gameObject.name = "End";

                Gizmos.color = Color.green;
                Gizmos.DrawCube(transform.position, new Vector3(.8f, .4f, .3f));
            }



		}
		private void OnTriggerEnter2D(Collider2D other)
		{
			if( other.gameObject.tag == "Enemy")
			{
                other.GetComponent<EnemyManager>().currentPointsPast++;

                if(this.gameObject.name == "End")
				{
                    Destroy(other.gameObject);
				}
			}
            
		}

		void Update()
        {
            try
			{
                nextPoint = transform.parent.GetChild(index).gameObject;

            }
            catch (Exception e)
			{
			    hasNext = false;
            }

            if (nextPoint != null)
			{
                hasNext = true;
			}




            // -- Debug --
            //print(name + " Position: " + transform.position + " Local Position: " + transform.localPosition);
            //print("NEXT POINT ----- " + nextPoint.name + " Position: " + nextPoint.transform.position + " Local Position: " + nextPoint.transform.localPosition);
        }

        #endregion

    }
}
