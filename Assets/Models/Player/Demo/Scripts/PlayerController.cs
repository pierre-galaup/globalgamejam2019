using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public Transform rightGunBone;
    public Transform leftGunBone;
    public Arsenal[] arsenal;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (arsenal.Length == 3)
        {
            SetArsenal(arsenal[2].name);
        }
        else if (arsenal.Length == 2)
        {
            SetArsenal(arsenal[1].name);
        }
    }

    public void SetArsenal(string name)
    {
        foreach (Arsenal hand in arsenal)
        {
            if (hand.name == name)
            {
                if (rightGunBone.childCount > 0)
                {
                    Destroy(rightGunBone.GetChild(0).gameObject);
                }

                if (leftGunBone.childCount > 0)
                {
                    Destroy(leftGunBone.GetChild(0).gameObject);
                }

                if (hand.rightGun != null)
                {
                    GameObject newRightGun = Instantiate(hand.rightGun, rightGunBone, true);
                    newRightGun.transform.localPosition = Vector3.zero;
                    if (arsenal.Length == 3)
                    {
                        newRightGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
                    }
                    else if (arsenal.Length == 2)
                    {
                        newRightGun.transform.localRotation = Quaternion.Euler(65.387f, 89, 90);
                    }
                    newRightGun.transform.localScale = new Vector3(0.3937008f, 0.3937008f, 0.3937008f);
                }
                if (hand.leftGun != null)
                {
                    GameObject newLeftGun = Instantiate(hand.leftGun, leftGunBone, true);
                    newLeftGun.transform.localPosition = Vector3.zero;
                    if (arsenal.Length == 3)
                    {
                        newLeftGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
                    }
                    else if (arsenal.Length == 2)
                    {
                        newLeftGun.transform.localRotation = Quaternion.Euler(65.387f, 89, 90);
                    }
                    newLeftGun.transform.localScale = new Vector3(0.3937008f, 0.3937008f, 0.3937008f);
                }
                //animator.runtimeAnimatorController = hand.controller;
                return;
            }
        }
    }

    [System.Serializable]
    public struct Arsenal
    {
        public string name;
        public GameObject rightGun;
        public GameObject leftGun;
        public RuntimeAnimatorController controller;
    }
}