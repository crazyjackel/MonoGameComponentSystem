using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ComponentSystem
{
    public class GameObject
    {
        bool enabled = true;
        Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }
        }

        //A Dictionary that contains Lists of components that are of the same type
        Dictionary<Type, List<Component>> ComponentDictionary = new Dictionary<Type, List<Component>>();
        //A list of all existing components for quick running of virtual functions
        List<Component> ComponentList = new List<Component>();

        public GameObject() : this(Vector2.Zero)
        {

        }
        public GameObject(Vector2 startPos)
        {
            this.position = startPos;
            ObjectManager.GetInstance().AddObject(this);
        }

        /// <summary>
        /// Adds a component to the GameObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        public void AddComponent<T>(T component) where T : Component
        {
            //Adds component to component list for quick access
            ComponentList.Add(component);
            //Adds component to component dictionary, creates new list if it doesnt exist
            if (ComponentDictionary.ContainsKey(typeof(T)))
            {
                ComponentDictionary[typeof(T)].Add(component);
            }
            else
            {
                ComponentDictionary.Add(typeof(T), new List<Component>() { component });
            }
            //Sets components gameobject to this for easy access
            component.GameObject = this;
            //Runs components start method
            component.Start();
        }

        public bool HasComponent<ComponentType>()
        {
            return ComponentDictionary.ContainsKey(typeof(ComponentType));
        }

        public int GetComponentCount<ComponentType>()
        {
            return HasComponent<ComponentType>() ? ComponentDictionary[typeof(ComponentType)].Count : 0;
        }

        public ComponentType GetComponent<ComponentType>() where ComponentType : Component
        {
            if (ComponentDictionary.ContainsKey(typeof(ComponentType)))
            {
                return (ComponentType)ComponentDictionary[typeof(ComponentType)][0];
            }
            else
            {
                return null;
            }
        }

        public ComponentType[] GetComponents<ComponentType>() where ComponentType : Component
        {
            if (ComponentDictionary.ContainsKey(typeof(ComponentType)))
            {
                return (ComponentType[])ComponentDictionary[typeof(ComponentType)].ToArray();
            }
            else
            {
                return null;
            }
        }

        public void Update()
        {
            if (enabled)
            {
                foreach (Component c in ComponentList)
                {
                    if (c.Enabled) c.Update();
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if (enabled)
            {
                foreach (Component c in ComponentList)
                {
                    if (c.Enabled) c.Draw(sb);
                }
            }

        }
    }
}
