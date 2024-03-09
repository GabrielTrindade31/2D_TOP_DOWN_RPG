using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Worldtime
{

    [RequireComponent(typeof(Light))]
    public class LighControl : MonoBehaviour
    {
        public float duration = 1f;
        [SerializeField] private Gradient gradient;
        [SerializeField] private Gradient bossgradient;
        private Skeletonboss skeletonboss;
        private Light2D lighte;
        private AudioManager audios;
        public AudioClip bgm;
        public AudioClip defaultSound;
        private float startTime;
        private bool startedsongboss;
        private bool startedsongdefault;
        private void Awake()
        {

            lighte = GetComponent<Light2D>();
            startTime = Time.time;
        }
        // void Start()
        // {
        //     skeletonboss = GetComponent<Skeletonboss>();
        // }

        void Update()
        {
            audios = FindAnyObjectByType<AudioManager>();
            skeletonboss = FindAnyObjectByType<Skeletonboss>();
            var timeElapsed = Time.time - startTime;
            var percent = Mathf.Sin(timeElapsed / duration * Mathf.PI * 2) * 0.5f + 0.5f;
            percent = Mathf.Clamp01(percent);
            if (skeletonboss != null)
            {
                if (!skeletonboss.isdead && !startedsongboss)
                {
                    bossSound();
                }
                lighte.color = bossgradient.Evaluate(percent);

            }
            else
            {
                if (!startedsongdefault)
                {
                    defaultSoundSound();
                }
                lighte.color = gradient.Evaluate(percent);
            }
        }

        private void bossSound()
        {
            audios.PlayBGM(bgm);
            startedsongboss = true;
            startedsongdefault = false;
        }
        private void defaultSoundSound()
        {
            audios.PlayBGM(defaultSound);
            startedsongdefault = true;
            startedsongboss = false;
        }
    }
}