using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class ButtonsController : MonoBehaviour
{

    private GameObject _play, _pause;

    private PlayerManager _player;

    [SerializeField]
    private AudioController _audioController;

    [SerializeField]
    private int _buttonType;    //  0 - Left
                                //  1 - Right
                                //  2 - Play/Pause

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerManager>();

        _play = _player.ButtonPlay;
        _pause = _player.ButtonPause;

    }

    public void OnAction()
    {
        switch (_buttonType)
        {
            case 0:
                _audioController.PreviousTrack();
                Tween.Scale(transform, 0.7f, 0.3f, Ease.InOutExpo, cycleMode: CycleMode.Yoyo, cycles: 2);
                break;

            case 1:
                _audioController.NextTrack();
                Tween.Scale(transform, 0.7f, 0.3f, Ease.InOutExpo, cycleMode: CycleMode.Yoyo, cycles: 2);
                break;

            case 2:
                _audioController.PlayPause();
                _play.SetActive(!_play.activeSelf);
                _pause.SetActive(!_pause.activeSelf);

                _player.SendMessage("ChangeAnimation", _play.activeSelf);

                Tween.Scale(_play.transform, 1.2f, 0.3f, Ease.OutExpo, cycleMode: CycleMode.Yoyo, cycles: 2);
                Tween.Scale(_pause.transform, 1.2f, 0.3f, Ease.OutExpo, cycleMode: CycleMode.Yoyo, cycles: 2);
                break;
        }
    }
}
