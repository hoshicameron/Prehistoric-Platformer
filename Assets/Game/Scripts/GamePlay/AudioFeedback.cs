using UnityEngine;

namespace PrehistoricPlatformer
{
    public class AudioFeedback:MonoBehaviour
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private AudioSource targetAudioSource;
        [SerializeField] [Range(0f, 1f)] private float volume = 1f;

        public void PlayClip()
        {
            if(clip == null)    return;

            targetAudioSource.volume = volume;
            targetAudioSource.PlayOneShot(clip);
        }

        public void PlaySpecificClip(AudioClip clipToPlay = null)
        {
            if (clipToPlay == null) clipToPlay = clip;
            if (clipToPlay == null)    return;


            targetAudioSource.volume = volume;
            targetAudioSource.PlayOneShot(clipToPlay);
        }

    }// class
}// namespace