using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assign3
{
    public partial class Form1 : Form
    {
        /*
         * Enum definitions
         */
        public enum ItemType
        {
            Helmet, Neck, Shoulders, Back, Chest,
            Wrist, Gloves, Belt, Pants, Boots,
            Ring, Trinket
        };

        public enum Race { Orc, Troll, Tauren, Forsaken };

        public enum PlayerClass
        {
            Warrior, Mage, Druid, Priest, Warlock,
            Rogue, Paladin, Hunter, Shaman
        };

        public enum Role { Tank, Healer, Damage };

        public enum GuildType
        {
            Casual, Questing, Mythic, Raiding, PVP
        };

        /*
         * Lists of what Class can preform what Roles
         */
        public static List<PlayerClass> Tank = new List<PlayerClass>() { PlayerClass.Warrior, PlayerClass.Druid, PlayerClass.Paladin };
        public static List<PlayerClass> Healer = new List<PlayerClass>() { PlayerClass.Druid, PlayerClass.Priest, PlayerClass.Paladin, PlayerClass.Shaman };
        public static List<PlayerClass> Damage = new List<PlayerClass>() { PlayerClass.Warlock, PlayerClass.Mage, PlayerClass.Druid, PlayerClass.Priest, PlayerClass.Warlock, PlayerClass.Rogue, PlayerClass.Paladin,
                                                                    PlayerClass.Hunter, PlayerClass.Shaman };
        /*
         * Global variables
         */
        private static uint MAX_ILVL = 360;
        private static uint MAX_PRIMARY = 200;
        private static uint MAX_STAMINA = 275;
        private static uint MAX_LEVEL = 60;
        private static uint GEAR_SLOTS = 14;
        private static uint MAX_INVENTORY_SIZE = 20;

        /*
         * Storage for Guilds, Items, and Players
         */
        private static Dictionary<uint, Guild> Guilds = new Dictionary<uint, Guild>();
        private static Dictionary<uint, Item> Items = new Dictionary<uint, Item>();
        private static Dictionary<uint, Player> Players = new Dictionary<uint, Player>();

        /*
         * Input file paths
         *
         * You Might have to alter the path if you have the input files located in a different folder than I do.
         * Mine are in the same folder where the Assign1.cs file is located in VS.
         */
        private static string guildsFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\guilds.txt";
        private static string itemsFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\equipment.txt";
        private static string playersFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\players.txt";
        //finds the player specified by the user
        public static uint FindPlayer(Dictionary<uint, Player> Players)
        {
            //asks the user for the name of the player
            Console.Write("\nPlease enter player name: ");
            String playername = Console.ReadLine();
            Console.WriteLine();
            uint key = 2147483647;

            //checks through the player list for someone by that name
            foreach (KeyValuePair<uint, Player> pair in Players)
            {
                if ((pair.Value).Name == playername)
                    key = pair.Key;
            }

            //if it doesn't exist it returns the error code I decided on because it's the max 32 bit int
            //I also don't throw exceptions here just so you can keep trying/using the menu rather than 
            //having to relaunch.
            if (key == 2147483647)
            {
                Console.WriteLine("\nPlayer under that name not found.");
                return key;
            }

            //returns the key of the related player if they exist.
            return key;
        }

        //finds the guild specified by the user via the name
        public static uint[] FindGuild(Dictionary<uint, Guild> Guilds, string gName)
        {
            //asks the user for the guild name   
            uint[] key = new uint[5];
            for (int x = 0; x < 5; x++)
                key[x] = 2147483647;
            int i = 0;
            //searches the guild list for a guild by name
            foreach (KeyValuePair<uint, Guild> pair in Guilds)
            {
                if (pair.Value.Guildname == gName)
                {
                    key[i] = pair.Key;
                    i++;
                }
            }

            //returns and says that the guild couldn't be found.
            if (key[i] == 2147483647)
            {
                return key;
            }

            //returns the guild key
            return key;
        }

        //find the item specified by the user
        public static uint FindItem(Dictionary<uint, Item> Items)
        {
            //asks the user for the item name
            Console.WriteLine("\nPlease enter the name of the Item you would like to equip.");
            String itemName = Console.ReadLine();
            uint key = 2147483647;

            //searches the guild list for a guild by name
            foreach (KeyValuePair<uint, Item> pair in Items)
            {
                if (pair.Value.Name == itemName)
                    key = pair.Key;
            }

            //returns and says that the item couldn't be found.
            if (key == 2147483647)
            {
                Console.WriteLine("\nItem under that name not found.");
                return key;
            }

            //returns the item key
            return key;
        }

        /*
         * Method to read and load data from input files
         */
        public static void LoadData()
        {
            //Read in data from Guilds file
            var lines = File.ReadLines(guildsFile);
            foreach (var line in lines)
            {
                //Seperate on tabs and add to dict of Guilds
                string[] s = line.Split('\t');
                string[] s1 = s[2].Split('-');
                Guilds.Add(Convert.ToUInt32(s[0]), new Guild(s1[0].Trim(), s1[1].Trim(), (GuildType)(Convert.ToUInt32(s[1])), Convert.ToUInt32(s[0])));
            }

            //Read in data from Items file
            lines = File.ReadLines(itemsFile);
            foreach (var line in lines)
            {
                //Seperate on tabs and add to dict of Items
                string[] s = line.Split('\t');
                Item item = new Item(Convert.ToUInt32(s[0]), s[1], (ItemType)Convert.ToUInt32(s[2]), Convert.ToUInt32(s[3]),
                                 Convert.ToUInt32(s[4]), Convert.ToUInt32(s[5]), Convert.ToUInt32(s[6]), s[7]);
                Items.Add(item.Id, item);
            }

            //Read in data from Players file
            lines = File.ReadLines(playersFile);
            foreach (var line in lines)
            {
                //Seperate on tabs and add to dict of Players
                string[] s = line.Split('\t');
                // Build the Gear array for the Player
                uint[] ar = new uint[MAX_INVENTORY_SIZE];
                Player player = new Player(Convert.ToUInt32(s[0]), s[1].Trim(), (Race)Convert.ToUInt32(s[2]), (PlayerClass)Convert.ToUInt32(s[3]), (Role)Convert.ToUInt32(s[4]), Convert.ToUInt32(s[5]),
                                   Convert.ToUInt32(s[6]), Convert.ToUInt32(s[7]), ar);
                Players.Add(player.Id, player);
            }
        }

        /*
         *  This is the definition of the Player class along with an Icomparable interface
         */
        public class Player : IComparable
        {
            /*
            * Player Attributes
            */
            private uint _id;
            private string _name;
            private Race _race;
            private uint _level;
            private uint _exp;
            private uint _guildID;
            private uint[] _gear;
            private PlayerClass _playerclass;
            private Role _role;
            private List<uint> _inventory;
            bool firstRingNext = true;
            bool firstTrinkNext = true;

            /*
             * Default Constructor for Player Class
             */
            public Player()
            {
                _id = 0;
                _name = "";
                _race = 0;
                _level = 0;
                _exp = 0;
                _guildID = 0;
                _playerclass = 0;
                _gear = new uint[GEAR_SLOTS];
                _inventory = new List<uint>();
                _role = 0;

            }

            /*
             * Custom Constructor for Player Class
             */
            public Player(uint id, string name, Race race, PlayerClass playerclass, Role role, uint level, uint exp, uint guildID, uint[] gear)
            {
                _id = id;
                _name = name;
                _race = race;
                _level = level;
                _exp = exp;
                _guildID = guildID;
                _gear = new uint[GEAR_SLOTS];
                _inventory = new List<uint>();
                _playerclass = playerclass;
                _role = role;

                //If passed in gear arrray is not empty, copy it into Player gear array
                if (gear != null)
                    Array.Copy(gear, gear.GetLowerBound(0), _gear, _gear.GetLowerBound(0), GEAR_SLOTS);
            }
            /*
             *Role property
             */
            public Role Role
            {
                get => _role;
                set => _role = value;
            }

            /*
             * Id Property
             */
            public uint Id
            {
                get => _id;
            }

            /*
             * Name Property
             */
            public string Name
            {
                get => _name;
            }

            /*
             * Player type Property
             */
            public Race Race
            {
                get => _race;

            }

            /*
             * Level property
             */
            public uint Level
            {
                get => _level;
                set
                {
                    if (value < 0 || value > MAX_LEVEL)
                        throw new ArgumentOutOfRangeException($"Player level must be between 1 and " + MAX_LEVEL);
                    else
                        _level = value;
                }
            }

            /*
             * Experience property
             */
            public uint Exp
            {
                get => _exp;
                set
                {
                    //Add assigned exp value to Players exp value
                    _exp += value;

                    //Check to see if new exp amount is over threshhold to level up
                    if (_level < MAX_LEVEL)
                        LevelUp(_exp);
                }
            }
            //Guild ID Property
            public uint GuildID
            {
                get => _guildID;
                set => _guildID = value;
            }
            //Public Class Property
            public PlayerClass Playerclass
            {
                get => _playerclass;
                set => _playerclass = value;
            }

            /*
             * Method to handle leveling up a player
             */
            public void LevelUp(uint exp)
            {
                //Calculate required xp for level up
                uint expRequired = _level * 1000;

                while (exp >= expRequired && _level < MAX_LEVEL)
                {
                    if (_level < MAX_LEVEL)
                    {
                        //Increment level and subtract required amount from awarded amount
                        _level++;
                        Console.Write("\n" + this.Name + " has reached level " + _level + "!");
                        exp -= expRequired;
                    }
                    //Calculate new required amount for next iteration
                    expRequired = _level * 1000;
                }
            }

            /*
             * Method to equip (add) gear to players 
             */
            public void EquipGear(uint newGearID)
            {
                //if item and player exist, equip item id to corresponding slot in player gear array
                uint itype = (uint)Items[newGearID].Type;

                //make sure player meets required level for item
                if (this.Level < Items[newGearID].Requirement)
                {
                    //console message instead of exception so that level requirements don't break program and allow user to try again
                    Console.WriteLine("\n" + this.Name + " does not meet required level for " + Items[newGearID].Name + ".\n");
                    return;
                }

                //check if item is ring or trinket, if so then special case
                if ((itype == 10) || (itype == 11))
                {
                    switch (itype)
                    {
                        case 10:
                            if (firstRingNext || this._gear[itype] == 0)
                            {
                                if (this._gear[itype] != 0)
                                    this._inventory.Add(this._gear[itype]);
                                this._gear[itype] = newGearID;
                                firstRingNext = false;
                                break;
                            }
                            else
                            {
                                if (this._gear[itype + 1] != 0)
                                    this._inventory.Add(this._gear[itype + 1]);
                                this._gear[itype + 1] = newGearID;
                                firstRingNext = true;
                                break;

                            }

                        case 11:
                            if (firstTrinkNext || this._gear[itype + 1] == 0)
                            {
                                if (this._gear[itype + 1] != 0)
                                    this._inventory.Add(this._gear[itype + 1]);
                                this._gear[itype + 1] = newGearID;
                                firstTrinkNext = false;
                                break;
                            }
                            else
                            {
                                if (this._gear[itype + 2] != 0)
                                    this._inventory.Add(this._gear[itype + 2]);
                                this._gear[itype + 2] = newGearID;
                                firstTrinkNext = true;
                                break;
                            }
                    }
                }
                //Add to only slot if not special case
                else
                {
                    if (this._gear[itype] != 0)
                        this._inventory.Add(this._gear[itype]);
                    this._gear[itype] = newGearID;
                }
                Console.WriteLine("\n" + this.Name + " is now equipped with " + Items[newGearID].Name + "!");
            }

            /*
             * Method to unequip (remove) gear from players
             */
            public void UnequipGear(uint gearSlot)
            {
                //Special case (ring)
                if (gearSlot == 10)
                {
                    //Check if ring 1 is empty
                    if (this[gearSlot] == 0)
                    {
                        //Check if ring 2 is empty, if both empty do nothing
                        if (this[gearSlot + 1] == 0)
                            Console.WriteLine("There was nothing in that slot. Nothing has changed.");

                        //If trinket 1 empty, unequip trinket 2
                        else
                        {
                            this._inventory.Add(this[gearSlot + 1]);
                            Console.WriteLine("\n" + Items[this._gear[gearSlot + 1]].Name + " was removed from player and added to inventory");
                            this[gearSlot + 1] = 0;
                        }
                    }

                    //No special case
                    else
                    {
                        this._inventory.Add(this[gearSlot]);
                        Console.WriteLine("\n" + Items[this._gear[gearSlot]].Name + " was removed from player and added to inventory");
                        this[gearSlot] = 0;
                    }
                }

                //Special case (trinket)
                else if (gearSlot == 11)
                {
                    //Check if trinket 1 is empty
                    if (this[gearSlot + 1] == 0)
                    {
                        //Check if trinket 2 is empty, if both empty do nothing
                        if (this[gearSlot + 2] == 0)
                            Console.WriteLine("There was nothing in that slot. Nothing has changed.");

                        //If trinket 1 empty, uneqip trinket 2
                        else
                        {
                            this._inventory.Add(this[gearSlot + 2]);
                            Console.WriteLine("\n" + Items[this._gear[gearSlot + 2]].Name + " was removed from player and added to inventory");
                            this[gearSlot + 2] = 0;
                        }
                    }

                    //If trinket 1 not empty, unequip trinket 1
                    else
                    {
                        this._inventory.Add(this[gearSlot + 1]);
                        Console.WriteLine("\n" + Items[this._gear[gearSlot + 1]].Name + " was removed from player and added to inventory");
                        this[gearSlot + 1] = 0;
                    }
                }

                //No special case
                else
                {
                    //Unequip item 
                    if (this[gearSlot] != 0)
                    {
                        this._inventory.Add(this[gearSlot]);
                        Console.WriteLine("\n" + Items[this._gear[gearSlot]].Name + " was removed from player and added to inventory");
                        this[gearSlot] = 0;
                    }
                    else
                    {
                        Console.WriteLine("\nThere was nothing in that slot. Nothing has changed.");
                    }
                }
            }

            /*
             * Indexer for the Players Gear array
             */
            public uint this[uint i]
            {
                get { return _gear[i]; }
                set { _gear[i] = value; }
            }

            /*
             * IComparable interface for the Player Class
             */
            public int CompareTo(object obj)
            {
                //Make sure object not null
                if (obj == null)
                    return 1;

                //Compare by name if valid Player object
                if (obj is Player toCompare)
                    return this.Name.CompareTo(toCompare.Name);
                else
                    throw new ArgumentException("Object is not a Player");
            }

            /*
             * toString method for the Player class
             */
            public override String ToString()
            {
                string message = "Name: " + String.Format("{0,-12}", _name) + "\tRace: " + _race + "\tLevel: " + _level;
                return _guildID == 0 ? message : message + "     Guild: " + Guilds[GuildID].Guildname + " [" + Guilds[GuildID].Servername + "]";

            }
        }

        /*
         *  This is the definition of the Item class along with an Icomparable interface
         */
        public class Item : IComparable
        {
            //The Count variable so that we can keep track of how many items there are
            public static int Count = 0;
            //the id variable that can only be changed in the constuctor and then the public property with on a get method
            private readonly uint id;
            public uint Id
            {
                get { return id; }

            }

            //The name of the item as well as the public property for accessing the String or changing it.
            private String name;
            public String Name
            {
                //just very simple get and set methods
                get => name;
                set => name = value;
            }

            //the itemType as well as the public property for accessing the itemType
            private ItemType type;
            public ItemType Type
            {
                //simple get method
                get => type;
                //The set method here checks to make sure that the Item type is somewhere between Helmet and Trinket
                //and throws an acception if the argument given is out of the given range
                set
                {
                    if (value < 0 || value > ItemType.Trinket)
                        throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 12");
                    //otherwise changes the item type
                    type = value;
                }
            }

            //the item level of the item and the public property for accessing it.
            private uint ilvl;
            public uint Ilvl
            {
                //simple get method
                get => ilvl;
                set
                {
                    //checks to make sure that the item level that is given is between 0 and the given max item level
                    //if the item level is not in that range it throws an acception.
                    if (value < 0 || value > MAX_ILVL)
                        throw new ArgumentOutOfRangeException($"The item level must be between 0 and " + MAX_ILVL);
                    //otherwise changes the value of ilvl
                    ilvl = value;
                }
            }

            //The primary number(I am unsure of what this actually is at this point) and the public property of it
            private uint primary;
            public uint Primary
            {
                //simple get method
                get => primary;
                set
                {
                    //checks to make sure that the primary value is between 0 and the given Max primary value and
                    //throws an exception if it is not it throws an exception stating that it is not in the range
                    if (value < 0 || value > MAX_PRIMARY)
                        throw new ArgumentOutOfRangeException($"The primary value must be between 0 and " + MAX_PRIMARY);
                    //or it just changes the value of primary.
                    primary = value;
                }
            }

            //the stamina cost of using the weapon(I am assuming that is what stamina is in reference to?) and it's property
            private uint stamina;
            public uint Stamina
            {
                //simple get method
                get => stamina;
                set
                {
                    //checks to make sure that the value of the stamina is between 0 and the given max stamina cost
                    //and throws an exception if it is not.
                    if (value < 0 || value > MAX_STAMINA)
                        throw new ArgumentOutOfRangeException($"the stamina value must be between 0 and " + MAX_STAMINA);
                    //or just changes the value.
                    stamina = value;
                }
            }

            //The level requirment of the item and it's public property
            private uint requirement;
            public uint Requirement
            {
                //simple get method for the requirement
                get => requirement;
                set
                {
                    //checks to make sure that the requirement level is between 0 and the max level and throws an exception if it is not
                    if (value < 0 || value > MAX_LEVEL)
                        throw new ArgumentOutOfRangeException($"The level requirement must be between 0 and " + MAX_LEVEL);
                    //or changes the value of requirement.
                    requirement = value;
                }
            }

            //The flavor text and it's public property
            private String flavor;
            public String Flavor
            {
                //very simple set and get methods for this property
                get => flavor;
                set => flavor = value;
            }
            //the override for ToString that just prints out all of the item stats.
            public override String ToString()
            {
                return "(" + Type + ") " + Name + " |" + Ilvl + "| " + "--" + Requirement + "--" + "\n\t" + "\"" + Flavor + "\"";
            }
            //The default constructor that just sets everything to 0 or null and adds one to Count
            //side note both of the constructors use the properties to access everything minus id
            public Item()
            {
                id = 0;
                Name = "";
                Type = 0;
                Ilvl = 0;
                Primary = 0;
                Stamina = 0;
                Requirement = 0;
                Flavor = "";
                Count++;
            }

            //Constructor for when you want to set all the item class members and then adds one to Count
            public Item(uint nid, String nname, ItemType ntype, uint nilvl, uint nprimary, uint nstamina, uint nreq, String nflavor)
            {
                id = nid;
                Name = nname;
                Type = ntype;
                Ilvl = nilvl;
                Primary = nprimary;
                Stamina = nstamina;
                Requirement = nreq;
                Flavor = nflavor;
                Count++;
            }

            //IComparable Interface Compare to override
            public int CompareTo(object obj)
            {
                //checks if the second item is null and then returns 500 simply for debugging purposes it will still get caught because it is greater than 0
                if (obj == null) return 500;
                //sets otheritem equal to the passed in item typecasted as an item
                Item otherItem = obj as Item;
                //checks if the typecasting failed if it did then it throws an exception and if not it just compares the names.
                if (otherItem != null)
                    return this.Name.CompareTo(otherItem.Name);
                else
                    throw new ArgumentException("Object is not an Item");
            }
        }
        //Guild class to be used in the guild dictionary
        public class Guild
        {
            private string _guildName;
            private string _serverName;
            private uint _guildID;
            private GuildType _guildType;
            //a guild class constuctor with a guildtype value of casual
            public Guild(string guildName, string serverName, GuildType guildType, uint guildID)
            {
                _guildName = guildName;
                _serverName = serverName;
                _guildType = guildType;
                _guildID = guildID;
            }

            public string Guildname
            {
                get => _guildName;
            }

            public string Servername
            {
                get => _serverName;
            }

            public GuildType Guildtype
            {
                get => _guildType;
            }

            public uint Guildid
            {
                get => _guildID;
            }
        }
        public Form1()
        {
            InitializeComponent();
            LoadData();
            // adding the classes to the class dropdown
            ClassBox.Items.AddRange(new string[] { "Warrior", "Mage", "Druid", "Priest", "Warlock", "Rogue", "Paladin", "Hunter", "Shaman" });
            //adding the roles to the Role box
            RoleBox.Items.AddRange(new string[] { "Tank", "Healer", "Damage" });
            //adding the types to the guild type box
            TypeBox.Items.AddRange(new string[] { "Casual", "Questing", "Mythic", "Raiding", "PVP" });
            //Fills the server box
            foreach (KeyValuePair<uint, Guild> pair in Guilds)
            {
                if (ServerBox.FindStringExact(pair.Value.Servername) == -1)
                    ServerBox.Items.Add(pair.Value.Servername);
                if (ServerBox2.FindStringExact(pair.Value.Servername) == -1)
                    ServerBox2.Items.Add(pair.Value.Servername);
                if (ServerBox3.FindStringExact(pair.Value.Servername) == -1)
                    ServerBox3.Items.Add(pair.Value.Servername);
            }
        }
        //First button click to search for Classes on servers
        private void button1_Click(object sender, EventArgs e)
        {
            //checks to make sure that the dropdown boxes are selected
            if (ClassBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Class.", "Error");
                return;
            }
            if (ServerBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a server.", "Error");
                return;
            }
            OutputBox.Items.Clear();
            //the query that finds all players of a certain class on a specific server
            var ClassQuery =
                from p in Players
                where p.Value.GuildID != 0
                where p.Value.Playerclass == (PlayerClass)ClassBox.SelectedIndex && Guilds[p.Value.GuildID].Servername.Contains(ServerBox.Text)
                orderby p.Value.Name
                select p;
            int Count = 0;
            //prints out the players if any are found or that none where found if that is the case
            OutputBox.Items.Add(String.Format("All {0} from {1}", ClassBox.Text, ServerBox.Text));
            OutputBox.Items.Add("---------------------------------------------------------------------------------");
            foreach (KeyValuePair<uint, Player> i in ClassQuery)
            {
                OutputBox.Items.Add(String.Format("Name: {0,-15} ({1} - {2,-6}) Race: {3,-10} Level: {4,-3}  <{5}>", i.Value.Name, i.Value.Playerclass, i.Value.Role, i.Value.Race, i.Value.Level, Guilds[i.Value.GuildID].Guildname));
                Count++;
            }
            if (Count == 0)
            {
                OutputBox.Items.Add("No players of that class where found on that server.");
            }
            OutputBox.Items.Add("End Results");
            OutputBox.Items.Add("---------------------------------------------------------------------------------");
            //resets the combo boxs because I think that looks nicer when they do that.
            ClassBox.SelectedIndex = -1;
            ServerBox.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //checks to make sure that the server box is filled in
            if (ServerBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a server.", "Error");
                return;
            }
            OutputBox.Items.Clear();
            //makes queries for all the races to get the counts and add them up
            float TCount = 0;
            float OrcCount =
                (from p in Players
                 where p.Value.GuildID != 0
                 where p.Value.Race == (Race)0 && Guilds[p.Value.GuildID].Servername.Contains(ServerBox2.Text)
                 select p).Count();
            TCount += OrcCount;
            float TrollCount =
                (from p in Players
                 where p.Value.GuildID != 0
                 where p.Value.Race == (Race)1 && Guilds[p.Value.GuildID].Servername.Contains(ServerBox2.Text)
                 select p).Count();
            TCount += TrollCount;
            float TaurenCount =
                (from p in Players
                 where p.Value.GuildID != 0
                 where p.Value.Race == (Race)2 && Guilds[p.Value.GuildID].Servername.Contains(ServerBox2.Text)
                 select p).Count();
            TCount += TaurenCount;
            float ForsakenCount =
                (from p in Players
                 where p.Value.GuildID != 0
                 where p.Value.Race == (Race)3 && Guilds[p.Value.GuildID].Servername.Contains(ServerBox2.Text)
                 select p).Count();
            TCount += ForsakenCount;
            //just some simple math and formatting so that all the percentages for all the races are printed out
            OutputBox.Items.Add(String.Format("Percentage of Each Race from {0}", ServerBox2.Text));
            OutputBox.Items.Add("---------------------------------------------------------------------------------");
            OutputBox.Items.Add(String.Format("Orc           {0:P2}", OrcCount / TCount));
            OutputBox.Items.Add(String.Format("Troll         {0:P2}", TrollCount / TCount));
            OutputBox.Items.Add(String.Format("Tauren        {0:P2}", TaurenCount / TCount));
            OutputBox.Items.Add(String.Format("Forsaken      {0:P2}", ForsakenCount / TCount));
            OutputBox.Items.Add("End Results");
            OutputBox.Items.Add("---------------------------------------------------------------------------------");
            ServerBox2.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //checks to make sure that the server and role boxes are filled
            if (RoleBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a server.", "Error");
                return;
            }
            if (ServerBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a server.", "Error");
                return;
            }
            OutputBox.Items.Clear();
            //queries to find everyone of a certain role on a certain server
            var ClassQuery =
                from p in Players
                where p.Value.GuildID != 0
                where p.Value.Role == (Role)RoleBox.SelectedIndex && Guilds[p.Value.GuildID].Servername.Contains(ServerBox3.Text)
                where p.Value.Level <= MaxUpDown.Value && p.Value.Level >= MinUpDown.Value
                orderby p.Value.Level
                select p;
            int Count = 0;
            //prints out the players if any are found or that none where found if that is the case
            OutputBox.Items.Add(String.Format("All {0} from {1}", RoleBox.Text, ServerBox3.Text));
            OutputBox.Items.Add("---------------------------------------------------------------------------------");
            foreach (KeyValuePair<uint, Player> i in ClassQuery)
            {
                OutputBox.Items.Add(String.Format("Name: {0,-15} ({1,-7} - {2,-6}) Race: {3,-10} Level: {4,-3}  <{5}>", i.Value.Name, i.Value.Playerclass, i.Value.Role, i.Value.Race, i.Value.Level, Guilds[i.Value.GuildID].Guildname));
                Count++;
            }
            if (Count == 0)
            {
                OutputBox.Items.Add("No players of that class where found on that server.");
            }
            OutputBox.Items.Add("End Results");
            OutputBox.Items.Add("---------------------------------------------------------------------------------");
            //resets the combo boxs because I think that looks nicer when they do that.
            RoleBox.SelectedIndex = -1;
            ServerBox3.SelectedIndex = -1;
        }

        //these two functions just make sure that the min level is never higher than the max level and the same in reverse.
        private void MinUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (MinUpDown.Value > MaxUpDown.Value)
                MaxUpDown.Value = MinUpDown.Value;
        }
        private void MaxUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (MinUpDown.Value > MaxUpDown.Value)
                MinUpDown.Value = MaxUpDown.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //checks to make sure that the Type boxe is filled
            if (TypeBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a server.", "Error");
                return;
            }
            OutputBox.Items.Clear();
            //query inlcuding a groupby server name
            var GuildQuery =
                from g in Guilds
                where g.Value.Guildtype == (GuildType)TypeBox.SelectedIndex
                orderby g.Value.Guildname
                group g by g.Value.Servername;
            int Count = 0;
            OutputBox.Items.Add(String.Format("All {0} from {1}", RoleBox.Text, ServerBox3.Text));
            //nested foreach loops to go through all of the guilds in each group and print them out by name
            OutputBox.Items.Add("---------------------------------------------------------------------------------");
            foreach (var i in GuildQuery)
            {
                OutputBox.Items.Add(i.Key);
                foreach (KeyValuePair<uint, Guild> guild in i)
                {
                    OutputBox.Items.Add(String.Format("               <{0}>)", guild.Value.Guildname));
                }
                Count++;
            }
            if (Count == 0)
            {
                OutputBox.Items.Add("No players of that class where found on that server.");
            }
            OutputBox.Items.Add("End Results");
            OutputBox.Items.Add("---------------------------------------------------------------------------------");
            //resets the combo box because I think that looks nicer when they do that.
            TypeBox.SelectedIndex = -1;
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            // No button selected
            if (!TankButton.Checked && !HealerButton.Checked && !DamageButton.Checked)
            {              
                MessageBox.Show("Please select a role.", "Error");
                return;
            }

            // Clear output field
            OutputBox.Items.Clear();

            // Tank button selected
            if(TankButton.Checked)
            {
                // Execute query
                var roleQuery =
                    from p in Players
                    where Tank.Contains(p.Value.Playerclass)
                    where p.Value.Role != Role.Tank
                    orderby p.Value.Level, p.Value.Name
                    select p;

                // Print results
                OutputBox.Items.Add("All Eligible Players Not Fulfilling the Tank Role");
                OutputBox.Items.Add(new String('-', 80));
                foreach (var result in roleQuery)
                    OutputBox.Items.Add(String.Format("Name: {0,-15} ({1,-8} - {2,-6})   Race: {3,-8}   Level: {4,-2}   <{5}>",
                                                       result.Value.Name, result.Value.Playerclass, result.Value.Role, result.Value.Race, result.Value.Level, Guilds[result.Value.GuildID].Guildname));
            }

            // Healer button selected
            if (HealerButton.Checked)
            {
                // Execute query
                var roleQuery =
                    from p in Players
                    where Healer.Contains(p.Value.Playerclass)
                    where p.Value.Role != Role.Healer
                    orderby p.Value.Level, p.Value.Name
                    select p;


                // Print results
                OutputBox.Items.Add("All Eligible Players Not Fulfilling the Healer Role");
                OutputBox.Items.Add(new String('-', 80));
                foreach (var result in roleQuery)
                {
                    OutputBox.Items.Add(result.Value.Role == Role.Tank ? 
                        String.Format("Name: {0,-15} ({1,-8} - {2,-4})     Race: {3,-8}   Level: {4,-2}   <{5}>", result.Value.Name, result.Value.Playerclass,
                                      result.Value.Role, result.Value.Race, result.Value.Level, Guilds[result.Value.GuildID].Guildname) :
                        String.Format("Name: {0,-15} ({1,-8} - {2,-6})   Race: {3,-8}   Level: {4,-2}   <{5}>", result.Value.Name, result.Value.Playerclass,
                                      result.Value.Role, result.Value.Race, result.Value.Level, Guilds[result.Value.GuildID].Guildname));
                }
            }

            // Damage button selected
            if (DamageButton.Checked)
            {
                // Execute query 
                var roleQuery =
                    from p in Players
                    where Damage.Contains(p.Value.Playerclass)
                    where p.Value.Role != Role.Damage
                    orderby p.Value.Level, p.Value.Name
                    select p;

                // Print results
                OutputBox.Items.Add("All Eligible Players Not Fulfilling the Damage Role");
                OutputBox.Items.Add(new String('-', 80));
                foreach (var result in roleQuery)
                {
                    OutputBox.Items.Add(result.Value.Role == Role.Tank ?
                        String.Format("Name: {0,-15} ({1,-8} - {2,-4})     Race: {3,-8}   Level: {4,-2}   <{5}>", result.Value.Name, result.Value.Playerclass,
                                      result.Value.Role, result.Value.Race, result.Value.Level, Guilds[result.Value.GuildID].Guildname) :
                        String.Format("Name: {0,-15} ({1,-8} - {2,-6})   Race: {3,-8}   Level: {4,-2}   <{5}>", result.Value.Name, result.Value.Playerclass,
                                      result.Value.Role, result.Value.Race, result.Value.Level, Guilds[result.Value.GuildID].Guildname));
                }
            }

            OutputBox.Items.Add("");
            OutputBox.Items.Add("END RESULTS");
            OutputBox.Items.Add(new string('-', 80));
        }
    }
}
