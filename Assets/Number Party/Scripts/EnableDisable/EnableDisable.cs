using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NumberParty
{
    namespace EnableDisable
    {
        public class EnableDisable : MonoBehaviour
        {
            [SerializeField] ActionChannel enableChannel;
            [SerializeField] ActionChannel disableChannel;
            private Transform container = null;

            private void Awake()
            {
                container = transform.GetChild(0);

                ActOnChannels(() => enableChannel.AddAction(EnableContainer), () => disableChannel.AddAction(DisableContainer));
            }

            private void OnDisable()
            {
                ActOnChannels(() => enableChannel.RemoveAction(EnableContainer), () => disableChannel.RemoveAction(DisableContainer));
            }

            private void ActOnChannels(Action enableChannelFunc, Action disableChannelFunc)
            {
                if (enableChannel != null)
                {
                    enableChannelFunc();
                }

                if (disableChannel != null)
                {
                    disableChannelFunc();
                }
            }

            private void EnableContainer()
            {
                if (container == null) return;
                container.gameObject.SetActive(true);
            }

            private void DisableContainer()
            {
                if (container == null) return;
                container.gameObject.SetActive(false);
            }
        }
    }
}
