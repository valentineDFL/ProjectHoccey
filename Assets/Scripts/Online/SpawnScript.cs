using Photon.Pun;
using UnityEngine;

namespace Assets.Scripts.Online
{
    internal class SpawnScript : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _puck;
        [SerializeField] private Transform spawnPos1;
        [SerializeField] private Transform spawnPos2;

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            bool ddw = PhotonNetwork.IsMasterClient;

            Transform spawnPos = (ddw) ? spawnPos1 : spawnPos2;
            PhotonNetwork.Instantiate(_player.name, spawnPos.position, spawnPos.rotation);
        }

        private void OnDisable()
        {
            Destroy(this);
        }

    }
}
