using Mechanics.Garage;
using UnityEngine;

namespace Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Config/Config Level", order = 51)]
    public class ConfigLevel : ScriptableObject
    {
        [Range(1,3)]public int Difficulty = 1;
        public Car CarTemplate;
    }
}