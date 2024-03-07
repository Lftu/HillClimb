using System;
using Cinemachine;
using UnityEngine;

namespace Main.Code.Core
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtual;
        public void AssignCamera(Transform player)
        {
  
            _cinemachineVirtual.Follow = player;
        }
    }
}