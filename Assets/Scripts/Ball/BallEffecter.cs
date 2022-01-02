using UnityEngine;
using DG.Tweening;

public class BallEffecter : MonoBehaviour
{
    [SerializeField] private float _hitShakeDuration = 1f;
    [SerializeField] private float _hitShakeStrength = 1f;
    [SerializeField] private int _hitShakeVibrato = 10;
    [Space(10)]
    [SerializeField] private ParticleSystem _deathParticleEffectPrefab;

    private Color _color;


    public void Init(Color color)
    {
        _color = color;
    }


    public void CallHitEffect()
    {
        transform.DOShakeScale(_hitShakeDuration, _hitShakeStrength, _hitShakeVibrato)
            .OnComplete(() => transform.DORewind()); //���������� � �������� ��������� ���� �� ��������� �������� �� ��������� ����� (������ ���� �� ������ �����������)
    }

    public void CallDeathEffect()
    {
        //����� ������� � ��������� ���������
        ParticleSystem deathParticleEffect =
            Instantiate(_deathParticleEffectPrefab, transform.position, Quaternion.identity);

        ParticleSystem.MainModule deathParticleEffectMain =
            deathParticleEffect.main;
        deathParticleEffectMain.startColor = _color;
    }
}
