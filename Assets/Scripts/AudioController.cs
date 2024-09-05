using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private List<AudioClip> _playlist;

    private int _currentTrackIndex = 0;

    void Start()
    {
        if (_playlist.Count > 0)
        {
            _audioSource.clip = _playlist[_currentTrackIndex];
        }
    }

    public void PlayPause()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Pause();
        }
        else
        {
            _audioSource.Play();
        }
    }

    public void NextTrack()
    {
        bool isPlaing = _audioSource.isPlaying;
        _currentTrackIndex = (_currentTrackIndex + 1) % _playlist.Count;
        _audioSource.clip = _playlist[_currentTrackIndex];
        if(isPlaing)
            _audioSource.Play();
    }

    public void PreviousTrack()
    {
        bool isPlaing = _audioSource.isPlaying;
        _currentTrackIndex--;
        if (_currentTrackIndex < 0)
        {
            _currentTrackIndex = _playlist.Count - 1;
        }
        _audioSource.clip = _playlist[_currentTrackIndex];
        if (isPlaing)
            _audioSource.Play();
    }
}
