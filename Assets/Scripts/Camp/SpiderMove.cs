using DG.Tweening;
using UnityEngine;

namespace Camp
{
    public class SpiderMove : MonoBehaviour
    {
        private void Start()
        {
            MoveSpider();
        }

        private void MoveSpider()
        {
            transform.DOLookAt(new Vector3(-2.442627f, 0, -2.068425f), 1).OnComplete(() =>
            {
                transform.DOMove(new Vector3(-2.442627f, 0, -2.068425f), 4).OnComplete(() =>
                {
                    transform.DOLookAt(new Vector3(6.58f, 0, 1.35f), 1).OnComplete(() =>
                    {
                        transform.DOMove(new Vector3(6.58f, 0, 1.35f), 8).OnComplete(() =>
                        {
                            transform.DOLookAt(new Vector3(1.1f, 0, 4.5f), 4).OnComplete(() =>
                            {
                                transform.DOMove(new Vector3(1.1f, 0, 4.5f), 5).OnComplete(() =>
                                {
                                    transform.DOLookAt(new Vector3(-5.37f, 0, 6.44f), 7).OnComplete(() =>
                                    {
                                        transform.DOMove(new Vector3(-5.37f, 0, 6.44f), 5).OnComplete(() =>
                                        {
                                            transform.DOLookAt(new Vector3(-4.75f, 0, 2.28f), 1).OnComplete(() =>
                                            {
                                                transform.DOMove(new Vector3(-4.75f, 0, 2.28f), 4).OnComplete(() =>
                                                {
                                                    MoveSpider();
                                                });
                                            });
                                        });
                                    });
                                });
                            });
                        });
                    });
                });
            });
        }
    }
}