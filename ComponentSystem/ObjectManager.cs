using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
namespace ComponentSystem
{
    public class ObjectManager
    {
        private static ObjectManager Instance;
        List<GameObject> gameObjects = new List<GameObject>();
        private ObjectManager()
        {

        }

        public static ObjectManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ObjectManager();
            }
            return Instance;
        }

        public void AddObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void Update()
        {
            foreach (GameObject g in gameObjects)
            {
                g.Update();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (GameObject g in gameObjects)
            {
                g.Draw(sb);
            }
        }
    }
}
