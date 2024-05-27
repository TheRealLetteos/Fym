using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class AudioManager : MonoBehaviour
    {

        public static AudioManager Instance;

        [SerializeField]
        private List<NamedGameObject<AudioSource>> audioSources = new List<NamedGameObject<AudioSource>>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayAudioClip(string name)
        {
            NamedGameObject<AudioSource> audioClip = audioSources.Find(x => x.name == name);
            if (audioClip != null)
            {
                audioClip.gameObject.Play();
            }
            else
            {
                Debug.LogWarning("Audio clip " + name + " not found in list of audio sources.");
            }
        }

        public void StopMusic()
        {
            foreach (NamedGameObject<AudioSource> audioSource in audioSources)
            {
                if (audioSource.gameObject.isPlaying)
                {
                    audioSource.gameObject.Stop();
                }
            }
        }

    }
}