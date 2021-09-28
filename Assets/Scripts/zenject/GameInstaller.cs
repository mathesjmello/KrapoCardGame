using DefaultNamespace;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var sm = FindObjectOfType<StartManager>();
        var mpm = FindObjectOfType<MiddlePileManager>();
        var tm = FindObjectOfType<TurnManager>();


        Container.Bind<TurnManager>().FromInstance(tm).AsSingle();
        Container.Bind<MiddlePileManager>().FromInstance(mpm).AsSingle();
        Container.Bind<StartManager>().FromInstance(sm).AsSingle();
    }
}