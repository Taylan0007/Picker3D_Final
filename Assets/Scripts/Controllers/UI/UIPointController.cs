using System;
using System.Collections;
using System.Collections.Generic;
using Controllers.Player;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class UIPointController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI totalPointsText;

        private void OnEnable()
        {
            Debug.Log(PlayerPhysicsController._totalCollectCount);
            totalPointsText.text = $"TOTAL POINTS : {PlayerPhysicsController._totalCollectCount}";
        }


        
        
    }
}
