using DefaultNamespace;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var sm = FindObjectOfType<StartManager>();
        var mpm = FindObjectOfType<MiddlePileManager>();


        Container.Bind<MiddlePileManager>().FromInstance(mpm).AsSingle();
        Container.Bind<StartManager>().FromInstance(sm).AsSingle();
    }
}