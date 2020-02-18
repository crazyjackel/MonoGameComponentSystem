using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ComponentSystem
{
    public abstract class Component
    {
        private GameObject gameObject = null;
        private bool enabled = true;

        /// <summary>
        /// Returns the GameObject of the Component, by default null, once set cannot be changed
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return gameObject;
            }
            set
            {
                if (GameObject == null)
                {
                    gameObject = value;
                }
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            protected set
            {
                enabled = value;
            }
        }
        /// <summary>
        /// Called upon Component being added to a GameObject
        /// </summary>
        public virtual void Start()
        {

        }

        /// <summary>
        /// Called upon Component being updated
        /// </summary>
        public virtual void Update()
        {

        }
        /// <summary>
        /// Called upon Component being Drawn
        /// </summary>
        /// <param name="sb"></param>
        public virtual void Draw(SpriteBatch sb)
        {

        }
    }
}
