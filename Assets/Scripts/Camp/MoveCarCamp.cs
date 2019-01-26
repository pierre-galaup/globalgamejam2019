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

        private void Start()
        {
            MoveCar();
        }

        public void MoveCar()
        {
            _fenceDoorTransform.DOLocalMoveX(-12.67f, 2).OnComplete(() => // DEFAULT X = -9,97126
                _carTransform.DOLocalMoveZ(-11, 3).SetEase(Ease.InCubic).OnComplete(() => // DEFAULT Z = 0,58
                    Debug.Log("CALL MINI GAME MAP"))
                );
        }

        private void Reset()
        {
            _fenceDoorTransform = null;
            _carTransform = null;
        }
    }
}