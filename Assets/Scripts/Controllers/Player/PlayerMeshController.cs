using System;
using System.Net.Mime;
using Controllers.Pool;
using Data.ValueObjects;
using DG.Tweening;
using Managers;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMeshController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private new Renderer renderer;
        [SerializeField] private TextMeshPro scaleText;
        [SerializeField] private TextMeshPro totalCountText;
        [SerializeField] private ParticleSystem confettiParticle;

        #endregion

        #region Private Variables

        [ShowInInspector] private ScaleData _data;
        [ShowInInspector] private PoolData _poolData;
        [ShowInInspector] public static byte totalCount = 0;


        #endregion

        #endregion

        private void Awake()
        {
            scaleText.gameObject.SetActive(false);
        }

        internal void GetMeshData(ScaleData scaleData)
        {
            _data = scaleData;
        }

        internal void UpdateTotalCount()
        {
            totalCount += PoolController.totalCollectCount;
            totalCountText.text = $"Total Count : {totalCount}";
        }

        internal void ScaleUpPlayer()
        {
            renderer.gameObject.transform.DOScaleX(_data.ScaleCounter, 1).SetEase(Ease.Flash);
        }

        internal void ShowUpText()
        {
            scaleText.gameObject.SetActive(true);
            scaleText.DOFade(1, 0f).SetEase(Ease.Flash).OnComplete(() => scaleText.DOFade(0, 0).SetDelay(.65f));
            scaleText.rectTransform.DOAnchorPosY(.85f, .65f).SetRelative(true).SetEase(Ease.OutBounce).OnComplete(() =>
                scaleText.rectTransform.DOAnchorPosY(-.85f, .65f).SetRelative(true));
        }

        internal void PlayConfetiParticle()
        {
            confettiParticle.Play();
            //confettiParticle.SetActive(true);
            //DOVirtual.DelayedCall(2, () => confettiParticle.SetActive(false));
        }
        internal void OnReset()
        {
            totalCount = 0;
        }
    }
}