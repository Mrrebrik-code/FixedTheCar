using System;
using System.Collections.Generic;
using Factories;
using Mechanics.Prompters;
using UnityEngine;

namespace Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Config/Game", order = 0)]
    public class ConfigGame : ScriptableObject
    {
        public List<PrompterType> _templatePrompter;
        
        [Serializable]
        public class PrompterType
        {
            public Prompter Template => _template;
            public FactoryPrompter.Type Type => _type;

            [SerializeField] private Prompter _template;
            [SerializeField] private FactoryPrompter.Type _type;
        }
    }
}