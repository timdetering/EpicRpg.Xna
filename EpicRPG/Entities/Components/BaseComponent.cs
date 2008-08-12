using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using EpicRPG.Util;

namespace EpicRPG.Entities.Components
{
    public class BaseComponent
    {
        protected BaseEntity entityRef;
        public State.ComponentType type;

        public BaseComponent()
        {

        }

        public BaseComponent(BaseEntity e)
        {
            this.entityRef = e;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Sets attributes of this component
        /// </summary>
        /// <param name="args">paired list of attributes and their values</param>
        public virtual BaseComponent setAttributes(List<KeyValuePair<string, string>> attributes)
        {
            return this;
        }
    }
}
