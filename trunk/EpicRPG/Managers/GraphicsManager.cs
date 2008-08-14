using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Graphics;

namespace EpicRPG.Managers
{
    public class GraphicsManager : Singleton<GraphicsManager>
    {
        public List<GraphicsCollection> graphicsBank;

        public void initializeGraphicsManager(){
            this.graphicsBank = new List<GraphicsCollection>();
        }

        public GraphicsCollection getGraphicsByName(string name){
            foreach(GraphicsCollection g in this.graphicsBank){
                if (g.name == name)
                    return g;
            }

            return null;
        }
        
        public GraphicsCollection getGraphicsById(int id){
            if (id < this.graphicsBank.Count)
                return this.graphicsBank[id];

            return null;
        }
    }
}
