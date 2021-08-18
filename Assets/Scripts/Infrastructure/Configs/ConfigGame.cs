using System;
using System.Collections.Generic;
using Factories;
using Mechanics.Garage;
using Mechanics.Prompters;
using UnityEngine;

namespace Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Config/Game", order = 51)]
    public class ConfigGame : ScriptableObject
    {
        public Garage TemplateGarage;
        public int startSizePoolSource = 15;
        public AudioSource TemplateSource;
        public List<PrompterType> TemplatePrompter;
        public List<ConfigLevel> ConfigLevels;
        

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