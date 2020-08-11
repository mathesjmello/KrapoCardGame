using DefaultNamespace;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var gm = FindObjectOfType<GameManeger>();
        
        Container.Bind<GameManeger>().FromInstance(gm).AsSingle();
    }
}