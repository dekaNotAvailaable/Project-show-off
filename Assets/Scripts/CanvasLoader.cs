/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CanvasLoader : MonoBehaviour
{
    public GameObject EndMenu;
    public GameObject player;
    public Transform head;
    public Animator animator;//elia
    private void OnTriggerEnter(Collider collision)
    {
        //Temporarily disable animation
        if (animator != null)
        {
            animator.enabled = false;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            EndMenu.SetActive(true);
            player.GetComponent <ContinuousMoveProviderBase>().enabled = false;
            player.GetComponent<ContinuousTurnProviderBase>().enabled = false;
            Vector3 forwardDirection = new Vector3(head.forward.x, 0, head.forward.z).normalized;
            EndMenu.transform.position = head.position + forwardDirection * 2;
            EndMenu.transform.LookAt(new Vector3(head.position.x, EndMenu.transform.position.y, head.position.z));
            EndMenu.transform.forward *= -1;
        }

        //Rehabilitates animation
        if (animator != null)
        {
            animator.enabled = true;
        }
    }
}*/
using UnityEngine;

namespace UI
{
    public class CanvasLoader : MonoBehaviour
    {
        [SerializeField] private Transform playerHead;
        [SerializeField] private float spawnDistance = 2f;
        [SerializeField] private float yOffset = 0f;
        
        [SerializeField] private GameObject panel;
        
        private Vector3 _playerHeadForward;

        private void Awake()
        {
            _playerHeadForward = playerHead.forward;
        }

        private void Update()
        {          
            // show the panel in front of the player
            var position = playerHead.position;
            panel.transform.position = position + new Vector3(_playerHeadForward.x, yOffset, _playerHeadForward.z).normalized * spawnDistance;
            
            // rotate the panel to face the player frame by frame
            panel.transform.LookAt(new Vector3(position.x, panel.transform.position.y, position.z));
            panel.transform.forward *= -1;
        }
    }
}
