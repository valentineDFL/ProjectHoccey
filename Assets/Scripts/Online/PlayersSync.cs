using UnityEngine;
using Photon.Pun;
using UnityEditor;
using System;

namespace Assets.Scripts.Online
{

    public class PUN2_PlayerSync : MonoBehaviourPun, IPunObservable
    {
        private void Start()
        {
            if (photonView.IsMine)
            {

            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                // Локальный клиент отправляет данные
                stream.SendNext(transform.position);
                stream.SendNext(transform.rotation);
            }
            else
            {
                // Удаленный клиент получает данные
                transform.position = (Vector3)stream.ReceiveNext();
                transform.rotation = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}
