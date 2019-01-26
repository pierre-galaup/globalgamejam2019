using DG.Tweening;
using System;
using UnityEngine;

namespace Camp
{
    public class MoveCarCamp : MonoBehaviour
    {
        [SerializeField]
        private Transform _fenceDoorTransform;

        [SerializeField]
        private Transform _carTransform;

        [SerializeField]
        private Transform _player;

        public void MoveCar(Action animationCompleted)
        {
            _player.localPosition = new Vector3(-0.8f, 0, -0.6f);
            _player.localEulerAngles = new Vector3(0, 0, 0);
            _player.gameObject.GetComponent<Animator>().runtimeAnimatorController = null;

            _fenceDoorTransform.DOLocalMoveX(-12.67f, 2).OnComplete(() => // DEFAULT X = -9,97126
                _carTransform.DOLocalMoveZ(-11, 3).SetEase(Ease.InCubic).OnComplete(() => // DEFAULT Z = 0,58
                    animationCompleted?.Invoke())
                );
        }

        private void Reset()
        {
            _fenceDoorTransform = null;
            _carTransform = null;
            _player = null;
        }
    }
}