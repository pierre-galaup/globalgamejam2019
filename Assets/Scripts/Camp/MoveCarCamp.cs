using System;
using DG.Tweening;
using UnityEngine;

namespace Camp
{
    public class MoveCarCamp : MonoBehaviour
    {
        [SerializeField]
        private Transform _fenceDoorTransform;

        [SerializeField]
        private Transform _carTransform;

        public void MoveCar(Action animationCompleted)
        {
            _fenceDoorTransform.DOLocalMoveX(-12.67f, 2).OnComplete(() => // DEFAULT X = -9,97126
                _carTransform.DOLocalMoveZ(-11, 3).SetEase(Ease.InCubic).OnComplete(() => // DEFAULT Z = 0,58
                    animationCompleted?.Invoke())
                );
        }

        private void Reset()
        {
            _fenceDoorTransform = null;
            _carTransform = null;
        }
    }
}