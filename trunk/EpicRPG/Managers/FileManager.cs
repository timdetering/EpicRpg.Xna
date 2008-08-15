using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using EpicRPG.Entities.Configuration;
using System.Xml;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using EpicRPG.Graphics;
using EpicRPG.Entities;
using EpicRPG.World;

namespace EpicRPG.Managers
{
    public class FileManager : Singleton<FileManager>
    {
        public void loadGameConfiguration(){
            //TODO: look at game config file, load necessary configurations
            this.ReadConfigurationFile("GameConfiguration.xml");

            foreach(string file in ConfigurationManager.getInstance().configurationFiles){
                this.ReadConfigurationFile(file);
            }
        }

        public void ReadConfigurationFile(string sFileName)
        {
            //Iterators
            int audioIterator = -1;
            int entityIterator = -1;
            int textureIterator = -1;
            int terrainGraphicIterator = -1;
            int projectileIterator = -1;
            int itemIterator = -1;

            //Lists for object factory
            //List<AudioCollection> audioList = new List<AudioCollection>();
            List<EntityConfiguration> entityList = new List<EntityConfiguration>();
            List<GraphicsCollection> graphicsList = new List<GraphicsCollection>();
            List<WorldEntity> worldEntityList = new List<WorldEntity>();
            List<LevelConfiguration> levelList = new List<LevelConfiguration>();
            List<ItemConfiguration> itemList = new List<ItemConfiguration>();
            //List<ProjectileConfiguration> projectileList = new List<ProjectileConfiguration>();

            try
            {
                //Loading the XML document
                XmlDocument doc = new XmlDocument();
                doc.Load(sFileName);

                //Flags
                bool readingAudio = false;
                bool readingEntities = false;
                bool readingProjectiles = false;
                bool readingGraphics = false;
                bool readingTerrainGraphics = false;
                bool readingLevelConfigurations = false;
                bool readingMapConfiguration = false;
                bool readingGameConfig = false;
                bool readingItems = false;

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    readingAudio = (node.Name == "AudioCollection");
                    readingEntities = (node.Name == "Entity");
                    readingProjectiles = (node.Name == "Projectile");
                    readingGraphics = (node.Name == "GraphicsCollection");
                    readingTerrainGraphics = (node.Name == "TerrianGraphicsSet");
                    readingGameConfig = (node.Name == "Setting" || node.Name == "Include");
                    readingItems = (node.Name == "Item");
                    readingLevelConfigurations = (node.Name == "Level");
                    readingMapConfiguration = (node.Name == "Map");

                    if (readingGameConfig)
                    {
                        #region GAME_CONFIG

                        //Parsing the settings from xml
                        foreach (XmlAttribute att in node.Attributes)
                        {
                            ConfigurationManager.getInstance().setConfigurationSetting(att.Name, att.Value);
                        }

                        readingGameConfig = false;
                        #endregion
                    }
                    else if (readingAudio)
                    {
                        //TODO: AUDIO
                        #region AUDIO
                        //Parsing audio code goes here

                        /******SOUND CONFIGURATION PARSING************************
                         * each audio collection node will have the node name 'AudioCollection', and will have one attribute, 'name'
                         * 
                         * For each of these AudioCollection nodes, a AudioCollection object can be instantiated using its name (& id)
                         * 
                         * Each AudioCollection node will consist of sub-nodes of (possible) types:
                         *      VoiceCollection
                         *      AttackCollection
                         *      AmbientCollection
                         *      MessageCollection
                         * 
                         * These can be added simpley by calling the method addSetOfType(string type) on the instantiated AudioCollection.
                         *      type is the same as the sub-node name (listed above)
                         * 
                         * addSetOfType will instantiate a AudioCollection's AudioSet of that type and return it so that we can add audio filenames.
                         * 
                         * Each of these sub-nodes can consist of various sub-sub-nodes.  They represent various types of sounds.
                         *      To assist initializing their properties, they all inherit from AudioSet, which provides
                         *      a method addSound(string type, string fileName).  
                         * 
                         * addSound will allow each set to sort the given data into different sound types.
                         * 
                         * Once the completed list of AudioCollections is created, they can be mapped to EntityConfigurations
                         * 
                         * The SoundBank will look for a particular AudioCollection, named "GameAudio."  This sets ambient music and message
                         *      sounds, and includes default filenames.  Technically this set can be omitted from the XML file.  If
                         *      no GameAudio AudioCollection exists, SoundBank can create a new one with the defaults.
                         *************************************************************************************************************************/

                        //Incrementing the interator to get an accurate id
                        /*audioIterator++;

                        //Getting specific attributes
                        XmlAttribute name = node.Attributes["name"];
                        string nameToSet = name.Value;
                        node.Attributes.Remove(name);

                        XmlAttribute fileNodeNameAtt;

                        //Building the new blank collection
                        AudioCollection newCollection = new AudioCollection(audioIterator, nameToSet);

                        //Parsing the new sets in the collection from xml
                        foreach (XmlNode audioChildNode in node.ChildNodes)
                        {
                            //Getting the type of collection to add
                            string type = audioChildNode.Name;

                            AudioSet newSet = newCollection.addSetOfType(type);

                            if (newSet != null)
                            {
                                foreach (XmlNode typeNode in audioChildNode.ChildNodes)
                                {
                                    string nodeType = typeNode.Name;

                                    foreach (XmlNode fileNode in typeNode.ChildNodes)
                                    {
                                        fileNodeNameAtt = fileNode.Attributes["name"];

                                        if (fileNodeNameAtt != null)
                                            newSet.addSound(nodeType, fileNodeNameAtt.Value);
                                    }
                                }
                            }
                        }

                        //Add the audio collection to the audio list
                        audioList.Add(newCollection);

                        //Set the flag back to false
                        readingAudio = false;
                        */
                        #endregion
                        
                    }
                    else if (readingEntities)
                    {
                        #region ENTITIES
                        //Iterating the entityIterator for an accurate ID
                        entityIterator++;

                        //Getting specific attributes
                        XmlAttribute name = node.Attributes["className"];
                        string nameToSet = name.Value;
                        node.Attributes.Remove(name);

                        string[] entityAttributes = new string[node.Attributes.Count * 2];

                        //Getting the number of attributes for the entity
                        int numOfAttributes = node.Attributes.Count;

                        //Looping over these attributes and adding them to the string array
                        for (int i = 0; i < numOfAttributes; i++)
                        {
                            XmlAttribute newAttribute = node.Attributes[i];
                            entityAttributes[i * 2] = newAttribute.Name;
                            entityAttributes[(i * 2) + 1] = newAttribute.Value;
                        }

                        //Building a new EntityConfiguration
                        EntityConfiguration entity = new EntityConfiguration(entityIterator, nameToSet, entityAttributes);

                        //get component data
                        foreach (XmlNode entityNode in node.ChildNodes)
                        {
                            //Getting specific attributes
                            XmlAttribute compType = entityNode.Attributes["type"];
                            string typeToSet = compType.Value;
                            entityNode.Attributes.Remove(compType);

                            List<string> componentAttributes = new List<string>(entityNode.Attributes.Count * 2);

                            //Getting the number of attributes for the component
                            int numOfAtt = entityNode.Attributes.Count;

                            //Looping over these attributes and adding them to the string array
                            for (int j = 0; j < numOfAtt; j++)
                            {
                                XmlAttribute newAttr = entityNode.Attributes[j];
                                componentAttributes.Add(newAttr.Name);
                                componentAttributes.Add(newAttr.Value);
                            }

                            //TODO: expand to allow for more than one type of attribute for subnodes!
                            if (entityNode.HasChildNodes)
                            {
                                numOfAtt = entityNode.ChildNodes.Count;
                                int numOfCompAtt = 0;
                                XmlNode compNode;
                                XmlAttribute compAtt;

                                for (int j = 0; j < numOfAtt; j++)
                                {
                                    compNode = entityNode.ChildNodes[j];
                                    numOfCompAtt = compNode.Attributes.Count;

                                    for (int c = 0; c < numOfCompAtt; c++)
                                    {
                                        compAtt = compNode.Attributes[c];

                                        componentAttributes.Add(compNode.Name);
                                        componentAttributes.Add(compAtt.Value);
                                    }

                                }
                            }

                            //adding the component
                            entity.addComponentConfiguration(typeToSet, componentAttributes.ToArray());
                        }

                        //adding the entity to the list
                        entityList.Add(entity);

                        //Setting the flag back to false
                        readingEntities = false;
                        #endregion
                    }
                    else if (readingGraphics)
                    {
                        //TODO: GRAPHICS
                        #region GRPAHICS
                        
                        //Iterating the entityIterator for an accurate ID
                        textureIterator++;

                        //Getting specific attributes
                        XmlAttribute name = node.Attributes["name"];

                        string nameToSet = name.Value;
                        node.Attributes.Remove(name);

                        //Building a new GraphicsCollection
                        GraphicsCollection graphic = new GraphicsCollection(textureIterator, nameToSet);

                        //loop through GraphicsSets
                        foreach (XmlNode setNode in node.ChildNodes)
                        {
                            GraphicsSet set = new GraphicsSet();
                            
                            string nodeName, state, orientation, width, height;
                            XmlAttribute att;

                            att = setNode.Attributes["state"];
                            state = (att == null ? "" : att.Value);
                            
                            //loop through orientations
                            foreach (XmlNode subNode in setNode.ChildNodes)
                            {
                                try
                                {
                                    nodeName = subNode.Attributes["file"].Value;

                                    att = subNode.Attributes["orientation"];
                                    orientation = (att == null ? "" : att.Value);

                                    att = subNode.Attributes["frameWidth"];
                                    width = (att == null ? "0" : att.Value.Length == 0 ? "0" : att.Value);

                                    att = subNode.Attributes["frameHeight"];
                                    height = (att == null ? "0" : att.Value.Length == 0 ? "0" : att.Value);

                                    set.addGraphics(orientation, nodeName, int.Parse(width), int.Parse(height));
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Skipping Texture Configuration #" + textureIterator + " because of:");
                                    Console.WriteLine(e.StackTrace);
                                }
                            }
                            
                            graphic.addGraphics(State.getEntityStateByName(state), set);
                            
                        }

                        //adding the texture to the list
                        
                        graphicsList.Add(graphic);

                        //Setting the flag back to false
                        readingGraphics = false;
                        

                        #endregion
                    }
                    else if (readingTerrainGraphics){
                        #region TERRAIN GRAPHICS

                        //Iterating the terrainGraphicIterator for an accurate ID
                        terrainGraphicIterator++;

                        //Getting specific attributes
                        XmlAttribute name = node.Attributes["name"];
                        XmlAttribute file = node.Attributes["file"];
                        XmlAttribute pass = node.Attributes["passable"];

                        string nameToSet = "", fileToSet = "";
                        bool passable = false;

                        if (name != null)
                            nameToSet = name.Value;
                        if (file != null)
                            fileToSet = file.Value;
                        if (pass != null)
                            passable = bool.Parse(pass.Value);

                        //Building a new WorldEntity
                        WorldEntity wentity = new WorldEntity(nameToSet, passable, new GameTexture(fileToSet));

                        //adding the texture to the list
                        worldEntityList.Add(wentity);

                        //Setting the flag back to false
                        readingTerrainGraphics = false;

                        #endregion
                    }
                    else if(readingLevelConfigurations)
                    {
                        #region LEVEL CONFIGURATIONS

                        //Getting specific attributes
                        XmlAttribute name = node.Attributes["name"],
                                     num  = node.Attributes["levelNum"],
                                     file = node.Attributes["mapFile"];
                        
                        string nameToSet, fileToSet;
                        int numToSet;

                        //we need at least file and num...
                        if(file != null){
                            fileToSet = file.Value;

                            if(num != null){
                                numToSet = int.Parse(num.Value);

                                if (name != null){
                                    nameToSet = name.Value;
                                }
                                else
                                    nameToSet = "Level " + numToSet;

                                //add the configuration
                                levelList.Add(new LevelConfiguration(nameToSet, fileToSet, numToSet));
                            }
                        }

                        //Setting the flag back to false
                        readingLevelConfigurations = false;
                        #endregion
                    }
                    //HOLY CRAP EFFICIENCY??!?!?!?!?!!!
                    else if(readingMapConfiguration)
                    {
                        #region MAP CONFIGURATION
                        //This is a special case, as we'll only have one map loaded at a time.
                        
                        //Getting specific attributes
                        XmlAttribute name = node.Attributes["name"],
                                     height = node.Attributes["height"],
                                     width = node.Attributes["width"];


                        string nameToSet;
                        int heightToSet = 0, widthToSet = 0;

                        if (name != null)
                            nameToSet = name.Value;

                        if(height != null && width != null){
                            heightToSet = int.Parse(height.Value);
                            widthToSet = int.Parse(width.Value);
                        }
                        else{
                            //TODO: ERROR
                            continue;
                        }

                        //Building a new Map
                        BaseMap map = new BaseMap();
                        map.initialize(widthToSet, heightToSet);

                        XmlAttribute att;
                        //Load map data
                        foreach (XmlNode partNode in node.ChildNodes)
                        {
                            switch(partNode.Name.ToUpper())
                            {
                                #region PARSE MAP TERRAIN
                                case "TERRAIN":
                                    att = partNode.Attributes["fill"];
                                    
                                    int x = 0, y = 0;

                                    if(att != null){
                                        //fill all with fill value
                                        for (x = 0; x < widthToSet; x++){
                                            for (y = 0; y < heightToSet; y++){
                                                map.setCell(x, y, null);
                                            }
                                        }
                                    }
                                    else{
                                        //parse ROWS
                                        foreach(XmlNode row in partNode.ChildNodes){
                                            att = row.Attributes["fill"];
                                            if(att != null){
                                                //fill row with value
                                                if (att.Value != ""){

                                                    WorldEntity tid = WorldManager.getInstance().getWorldEntityByName(att.Value);

                                                    for(x = 0; x < map.terrainGrid.GetUpperBound(0); x++){
                                                        map.setCell(x, y, tid);
                                                    }
                                                }
                                            }
                                            else{
                                                //parse CELLS
                                                foreach(XmlNode cell in row.ChildNodes){
                                                    att = cell.Attributes["fill"];
                                                    if(att != null){
                                                        map.setCell(x, y, WorldManager.getInstance().getWorldEntityByName(att.Value));
                                                    }

                                                    //goto next column
                                                    x++;
                                                }
                                            }
                                            //goto next row
                                            y++;
                                            x = 0;
                                        }
                                    }

                                    break;
                                #endregion

                                #region PARSE MAP OBJECTS
                                case "OBJECTS":
                                    break;
                                #endregion

                                #region PARSE MAP ENTIIES
                                case "ENTITIES":
                                    break;
                                #endregion

                                default: break;
                            }
                        }

                        //set the current map
                        WorldManager.getInstance().currentMap = map;

                        //Setting the flag back to false
                        readingMapConfiguration = false;

                        #endregion
                    }
                    else if (readingProjectiles)
                    {
                        //TODO: PROJECTILES (?)
                        #region PROJECTILES
                        /*
                        //Iterating the projectileIterator for an accurate ID
                        projectileIterator++;

                        //Getting specific attributes
                        XmlAttribute name = node.Attributes["name"];
                        string nameToSet = name.Value;
                        node.Attributes.Remove(name);

                        string[] projectileAttributes = new string[node.Attributes.Count * 2];

                        //Getting the number of attributes for the entity
                        int numOfAttributes = node.Attributes.Count;

                        //Looping over these attributes and adding them to the string array
                        for (int i = 0; i < numOfAttributes; i++)
                        {
                            XmlAttribute newAttribute = node.Attributes[i];
                            projectileAttributes[i * 2] = newAttribute.Name;
                            projectileAttributes[(i * 2) + 1] = newAttribute.Value;
                        }

                        //Building a new ProjectileConfiguration
                        ProjectileConfiguration projectile = new ProjectileConfiguration(projectileIterator, nameToSet, projectileAttributes);

                        //adding the projectile to the list
                        projectileList.Add(projectile);

                        //Setting the flag back to false
                        readingProjectiles = false;
                        */

                        #endregion
                    }
                    else if(readingItems){
                        //TODO: ITEMS
                        #region ITEMS
                        //Iterating the itemIterator for an accurate ID
                        itemIterator++;

                        //Getting specific attributes
                        XmlAttribute name = node.Attributes["name"],
                                     value = node.Attributes["value"];

                        string nameToSet = "Item " + itemIterator;
                        long valueToSet = 0;

                        if(name != null)
                            nameToSet = name.Value;
                        if (value != null)
                            valueToSet = long.Parse(value.Value);
                        node.Attributes.Remove(name);
                        node.Attributes.Remove(value);

                        string[] itemAttributes = new string[node.Attributes.Count * 2];

                        //Getting the number of variable attributes for the item
                        int numOfAttributes = node.Attributes.Count;

                        //Looping over these attributes and adding them to the string array
                        XmlAttribute newAttribute;
                        for (int i = 0; i < numOfAttributes; i++)
                        {
                            newAttribute = node.Attributes[i];
                            itemAttributes[i * 2] = newAttribute.Name;
                            itemAttributes[(i * 2) + 1] = newAttribute.Value;
                        }

                        //TODO: ABILITIES/EFFECTS/WHATEVER

                        //Building a new ItemConfiguration
                        ItemConfiguration item = new ItemConfiguration(itemIterator, nameToSet, valueToSet, itemAttributes);

                        //adding the item to the list
                        itemList.Add(item);

                        //reset flag
                        readingItems = false;
                        #endregion
                    }
                    else
                    {
                        //ERROR!!! this shoud not happen
                        Console.WriteLine("Unrecognizable format or value in parsing XML: " + node.Name);
                    }

                }

                //Adding the entity list to the object factory
                if ((entityList != null) && (entityList.Count > 0))
                    ObjectFactory.getInstance().Entities = entityList;

                if ((worldEntityList != null) && (worldEntityList.Count > 0))
                    WorldManager.getInstance().setWorldEntities(worldEntityList);

                //Adding the projectile list to the object factory
                //if ((projectileList != null) && (projectileList.Count > 0))
                //    ProjectileBank.getInstance().projectileConfigurations = projectileList;

                //Adding the audio list
                //if ((audioList != null) && (audioList.Count > 0))
                //    SoundCollection.getInstance().audioCollections = audioList;

                //Adding the graphic list to the texture bank
                if((graphicsList != null) && (graphicsList.Count > 0))
                    GraphicsManager.getInstance().graphicsBank = graphicsList;

                //Adding level configurations to the level manager
                if ((levelList != null) && (levelList.Count > 0))
                    LevelManager.getInstance().levelConfigurations = levelList;

                if ((itemList != null) && (itemList.Count > 0))
                    ItemManager.getInstance().itemList = itemList;


            }
            catch (FileLoadException e)
            {
                Console.WriteLine("File Load Exception Found");
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Loads the specified texture file from the current Content root directory.
        /// If filename is in a subdirectory of Content, it must be specified in filename
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Texture2D loadTexture2DFromFile(string filename){
            return Texture2D.FromFile(OutputManager.getInstance().getGraphicsDevice(),
                ConfigurationManager.getInstance().contentRoot + "/" + filename);
        }
    }
}
