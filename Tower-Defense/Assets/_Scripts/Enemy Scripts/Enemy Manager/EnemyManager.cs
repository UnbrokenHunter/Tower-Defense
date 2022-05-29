using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TowerDefense
{
    public class EnemyManager : MonoBehaviour
    {

    #region Variables
        
        // Components
        private Rigidbody rb;
        
        public GameObject path;

        public int currentPointsPast;

        public int i = 0;

        #endregion


        #region Methods

        void Awake()
        {
            rb = GetComponent<Rigidbody>();

            path = GameObject.Find("Enemy Path");
            transform.position = path.transform.GetChild(0).position;
        }

        void FixedUpdate()
        {

            if(i == currentPointsPast)
			{
                    transform.position = Vector3.MoveTowards(transform.position, path.transform.GetChild(i).position,
                        path.transform.GetChild(i).GetComponent<PathPointScript>().speed);
                    //print("I: " + i + " Get Child: " + path.transform.GetChild(i) + " Position: " + path.transform.GetChild(i).position);

			}
            if (i < currentPointsPast)
			{
                i++;
			}
				

				
			
        }

    #endregion

    }
}
