using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace TBDRoller
{

    public partial class MapGenerator : Form
    {
        public MapGenerator()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (legendary == false)
            {
                initialize_legend();
            }

            ListBuilder();
            Mapper();
        }

        private void Form2_Close(object sender, EventArgs e)
        {
            rooms.Clear();
            occupied_columns.Clear();
            occupied_rows.Clear();
            mapView.BackgroundImage = finalMap;
        }

        private void form2Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void form2Gen_Click(object sender, EventArgs e)
        {
            rooms.Clear();
            occupied_columns.Clear();
            occupied_rows.Clear();
            Mapper();
        }

        static Random rng = new Random();
        static Hashtable legend = new Hashtable();
        const int FLOOR_ROWS = 90;
        const int FLOOR_COLUMNS = 120;
        static List<Room> rooms = new List<Room>();
        static List<LinkedList<Room>> occupied_rows = new List<LinkedList<Room>>();
        static List<LinkedList<Room>> occupied_columns = new List<LinkedList<Room>>(FLOOR_COLUMNS);
        static char[,] floor = new char[FLOOR_ROWS, FLOOR_COLUMNS];
        static MapGenerator f2 = new MapGenerator();

        static Boolean legendary = false;
        static Bitmap finalMap;

        public void Mapper()
        {
            for (int i = 0; i < FLOOR_ROWS; i++)
            {
                for (int j = 0; j < FLOOR_COLUMNS; j++)
                {
                    floor[i, j] = '.';
                }
            }

            initialize_validity();
            rooms = sprinkle_rooms();

            for (int i = 1; i < rooms.Count; i++)
            {
                recursive_corridor_placement(rooms[i - 1].Center(), rooms[i].Center());
            }

            MapBuilder();
            imgView();
        }

        void initialize_legend()
        {
            legend.Add("floor", 'X');
            legend.Add("wall", '#');
            legend.Add("character", '@');
            legend.Add("door", '+');
            legend.Add("corridor", '=');
            legend.Add("blank", '.');

            legendary = true;
        }

        void initialize_validity()
        {
            for (int i = 0; i < FLOOR_ROWS; i++)
            {
                occupied_rows.Add(new LinkedList<Room>());
            }

            for (int i = 0; i < FLOOR_COLUMNS; i++)
            {
                occupied_columns.Add(new LinkedList<Room>());
            }
        }

        void recursive_fill_down(Point current, Point goal)
        {
            floor[current.Row(), current.Column()] = legend["wall"].ToString()[0];
            if (!(current.Row() == goal.Row() && current.Column() == goal.Column()))
            {
                floor[current.Row(), current.Column()] = legend["wall"].ToString()[0];
                Point next = new Point(current.Row() + 1, current.Column());
                recursive_fill_down(next, goal);
            }
        }

        void recursive_fill_right(Point current, Point goal)
        {
            floor[current.Row(), current.Column()] = legend["wall"].ToString()[0];
            if (!(current.Row() == goal.Row() && current.Column() == goal.Column()))
            {
                floor[current.Row(), current.Column()] = legend["wall"].ToString()[0];
                Point next = new Point(current.Row(), current.Column() + 1);
                recursive_fill_right(next, goal);
            }
        }

        void generate_room(Room room)
        {
            for (int i = room.NWCorner().Row(); i < room.SWCorner().Row(); i++)
            {
                occupied_rows[i].AddLast(room);
            }

            for (int i = room.NWCorner().Column(); i < room.NECorner().Column(); i++)
            {
                occupied_columns[i].AddLast(room);
            }

            recursive_fill_down(room.NWCorner(), room.SWCorner());
            recursive_fill_right(room.NWCorner(), room.NECorner());
            recursive_fill_right(room.SWCorner(), room.SECorner());
            recursive_fill_down(room.NECorner(), room.SECorner());
            recursive_floor_fill(room.Center());
        }

        void recursive_floor_fill(Point current)
        {
            if (floor[current.Row(), current.Column()] == legend["blank"].ToString()[0])
            {
                floor[current.Row(), current.Column()] = legend["floor"].ToString()[0];
                recursive_floor_fill(new Point(current.Row() + 1, current.Column()));
                recursive_floor_fill(new Point(current.Row(), current.Column() + 1));
                recursive_floor_fill(new Point(current.Row() - 1, current.Column()));
                recursive_floor_fill(new Point(current.Row(), current.Column() - 1));
            }
        }

        List<Room> sprinkle_rooms()
        {
            List<Room> rooms = new List<Room> { };
            int fails = 0;

            while (fails < 30000)
            {
                int rows = Math.Abs((rng.Next() % (int)(FLOOR_ROWS * .2))) + 5;
                int columns = Math.Abs((rng.Next() % (int)(FLOOR_COLUMNS * .2))) + 5;
                Point center = new Point(Math.Abs(rng.Next() % (FLOOR_ROWS - (rows))) + (rows / 2), Math.Abs(rng.Next() % (FLOOR_COLUMNS - (columns))) + (columns / 2));
                Room room = new Room(center, rows, columns);

                if (room_validation(room))
                {
                    generate_room(room);
                    rooms.Add(room);
                    fails = 0;
                }

                else
                {
                    fails++;
                }
            }

            return rooms;
        }

        bool room_validation(Room room)
        {
            LinkedList<Room> critical_rows = occupied_rows[room.NWCorner().Row()];
            LinkedList<Room> critical_columns = occupied_columns[room.NWCorner().Column()];

            for (int i = room.NWCorner().Row() + 1; i < room.SWCorner().Row(); i++)
            {
                foreach (Room test in occupied_rows[i])
                {
                    if (!critical_rows.Contains(test))
                    {
                        critical_rows.AddLast(test);
                    }
                }
            }

            for (int i = room.NWCorner().Column() + 1; i < room.NECorner().Column(); i++)
            {
                foreach (Room test in occupied_columns[i])
                {
                    if (!critical_columns.Contains(test))
                    {
                        critical_columns.AddLast(test);
                    }
                }
            }

            foreach (Room test in critical_rows)
            {
                if (critical_columns.Contains(test))
                {
                    return false;
                }
            }

            return true;
        }

        bool point_validation(Point test_point)
        {
            if (!(test_point.Row() < 0 | test_point.Row() > FLOOR_ROWS - 1))
            {
                if (!(test_point.Column() < 0 | test_point.Column() > FLOOR_COLUMNS - 1))
                {
                    if (floor[test_point.Row(), test_point.Column()] == legend["blank"].ToString()[0])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        void recursive_corridor_placement(Point current, Point goal)
        {
            Point difference = new Point(goal.Row() - current.Row(), goal.Column() - current.Column());

            if (!(current.Row() == goal.Row() && current.Column() == goal.Column()))
            {
                if (Math.Abs(difference.Row()) > Math.Abs(difference.Column()))
                {
                    if (floor[current.Row(), current.Column()] == legend["floor"].ToString()[0] || floor[current.Row(), current.Column()] == legend["wall"].ToString()[0])
                    {
                        Point next = new Point(current.Row() + (difference.Row() / Math.Abs(difference.Row())), current.Column());
                        recursive_corridor_placement(next, goal);
                    }

                    else
                    {
                        floor[current.Row(), current.Column()] = legend["corridor"].ToString()[0];
                        door_placement(current);
                        Point next = new Point(current.Row() + (difference.Row() / Math.Abs(difference.Row())), current.Column());
                        recursive_corridor_placement(next, goal);
                    }
                }

                else if (Math.Abs(difference.Column()) > Math.Abs(difference.Row()))
                {
                    if (floor[current.Row(), current.Column()] == legend["floor"].ToString()[0] || floor[current.Row(), current.Column()] == legend["wall"].ToString()[0])
                    {
                        Point next = new Point(current.Row(), current.Column() + (difference.Column() / Math.Abs(difference.Column())));
                        recursive_corridor_placement(next, goal);
                    }

                    else
                    {
                        floor[current.Row(), current.Column()] = legend["corridor"].ToString()[0];
                        door_placement(current);
                        Point next = new Point(current.Row(), current.Column() + (difference.Column() / Math.Abs(difference.Column())));
                        recursive_corridor_placement(next, goal);
                    }
                }

                else
                {
                    if (rng.Next() % 2 > 0)
                    {
                        if (floor[current.Row(), current.Column()] == legend["floor"].ToString()[0] || floor[current.Row(), current.Column()] == legend["wall"].ToString()[0])
                        {
                            Point next = new Point(current.Row() + (difference.Row() / Math.Abs(difference.Row())), current.Column());
                            recursive_corridor_placement(next, goal);
                        }

                        else
                        {
                            floor[current.Row(), current.Column()] = legend["corridor"].ToString()[0];
                            door_placement(current);
                            Point next = new Point(current.Row() + (difference.Row() / Math.Abs(difference.Row())), current.Column());
                            recursive_corridor_placement(next, goal);
                        }
                    }

                    else
                    {
                        if (floor[current.Row(), current.Column()] == legend["floor"].ToString()[0] || floor[current.Row(), current.Column()] == legend["wall"].ToString()[0])
                        {
                            Point next = new Point(current.Row(), current.Column() + (difference.Column() / Math.Abs(difference.Column())));
                            recursive_corridor_placement(next, goal);
                        }

                        else
                        {
                            floor[current.Row(), current.Column()] = legend["corridor"].ToString()[0];
                            door_placement(current);
                            Point next = new Point(current.Row(), current.Column() + (difference.Column() / Math.Abs(difference.Column())));
                            recursive_corridor_placement(next, goal);
                        }
                    }
                }
            }
        }

        void door_placement(Point location)
        {
            if (floor[location.Row(), location.Column()] == legend["corridor"].ToString()[0])
            {
                if (floor[location.Row(), location.Column() + 1] == legend["wall"].ToString()[0])
                {
                    floor[location.Row(), location.Column() + 1] = legend["door"].ToString()[0];
                }

                else if (floor[location.Row(), location.Column() - 1] == legend["wall"].ToString()[0])
                {
                    floor[location.Row(), location.Column() - 1] = legend["door"].ToString()[0];
                }

                else if (floor[location.Row() + 1, location.Column()] == legend["wall"].ToString()[0])
                {
                    floor[location.Row() + 1, location.Column()] = legend["door"].ToString()[0];
                }

                else if (floor[location.Row() - 1, location.Column()] == legend["wall"].ToString()[0])
                {
                    floor[location.Row() - 1, location.Column()] = legend["door"].ToString()[0];
                }
            }
        }

        class Room
        {
            private Point center;
            private Point north_west_corner, north_east_corner, south_west_corner, south_east_corner;
            private int rows, columns;

            public Room(Point center, int rows, int columns)
            {
                this.center = center;
                this.rows = rows;
                this.columns = columns;
                this.north_west_corner = new Point(center.Row() - (rows / 2), center.Column() - (columns / 2));
                this.north_east_corner = new Point(center.Row() - (rows / 2), center.Column() + (columns / 2));
                this.south_west_corner = new Point(center.Row() + (rows / 2), center.Column() - (columns / 2));
                this.south_east_corner = new Point(center.Row() + (rows / 2), center.Column() + (columns / 2));
            }

            public Point Center()
            {
                return this.center;
            }

            public int Rows()
            {
                return this.rows;
            }

            public int Columns()
            {
                return this.columns;
            }

            public Point NWCorner()
            {
                return north_west_corner;
            }

            public Point NECorner()
            {
                return north_east_corner;
            }

            public Point SWCorner()
            {
                return south_west_corner;
            }

            public Point SECorner()
            {
                return south_east_corner;
            }

            public bool Equals(Room room)
            {
                if (this.center.Equals(room.center) &&
                    this.rows == room.rows &&
                    this.columns == room.columns)
                {
                    return true;
                }

                return false;
            }
        }

        struct Point
        {
            private int r, c;  //r = Row, c = Column

            public Point(int row, int column)
            {
                this.r = row;
                this.c = column;
            }

            public int Row()
            {
                return this.r;
            }

            public int Column()
            {
                return this.c;
            }

            public bool Equals(Point point)
            {
                if (this.r == point.r &&
                   this.c == point.c)
                {
                    return true;
                }

                return false;
            }
        }

        String mapDir = "\\MapImg\\";
        String mapName = "";
        List<Image> mapFiles = new List<Image>();
        int tileWidth = 10;
        int tileHeight = 10;

        public void MapBuilder()
        {

            int totWidth = FLOOR_COLUMNS * tileWidth;
            int totHeight = FLOOR_ROWS * tileHeight;
            finalMap = new Bitmap(totWidth, totHeight);

            for (int i = 0; i < FLOOR_COLUMNS; i++)
            {
                for (int j = 0; j < FLOOR_ROWS; j++)
                {
                    using (var map = Graphics.FromImage(finalMap))
                    {
                        if (floor[j, i] == '.')
                            map.DrawImage(mapFiles[0], (0 + (tileWidth * i)), (0 + (tileHeight * j)));
                        else if (floor[j, i] == 'X')
                            map.DrawImage(mapFiles[1], (0 + (tileWidth * i)), (0 + (tileHeight * j)));
                        else if (floor[j, i] == '#')
                            map.DrawImage(mapFiles[2], (0 + (tileWidth * i)), (0 + (tileHeight * j)));
                        else if (floor[j, i] == '@')
                            map.DrawImage(mapFiles[3], (0 + (tileWidth * i)), (0 + (tileHeight * j)));
                        else if (floor[j, i] == '+')
                            map.DrawImage(mapFiles[4], (0 + (tileWidth * i)), (0 + (tileHeight * j)));
                        else if (floor[j, i] == '=')
                            map.DrawImage(mapFiles[5], (0 + (tileWidth * i)), (0 + (tileHeight * j)));
                    }
                }
            }
        }

        public void imgView()
        {
            mapView.Image = finalMap;
        }

        public void ListBuilder()
        {
            for (int i = 0; i < 10; i++)
            {
                mapName = "." + mapDir + "0" + i + ".jpg";
                mapFiles.Add(Image.FromFile(mapName));
            }
        }

        private void form2Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog mapSave = new SaveFileDialog();
            mapSave.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";
            mapSave.Title = "Save Your Map Image";
            mapSave.ShowDialog();

            if (mapSave.FileName != "")
            {

                System.IO.FileStream fs =
                   (System.IO.FileStream)mapSave.OpenFile();

                switch (mapSave.FilterIndex)
                {
                    case 1:
                        finalMap.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        finalMap.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        finalMap.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;

                    case 4:
                        finalMap.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }

                fs.Close();
            }
        }

        //Print code found at: https://stackoverflow.com/questions/9982579/printing-image-with-printdocument-how-to-adjust-the-image-to-fit-paper-size
        private void form2Print_Click(object sender, EventArgs e)
        {
            PrintDialog mapPrintDialog = new PrintDialog();
            PrintDocument mapPrint = new PrintDocument();

            mapPrint.PrintPage += PrintPage;

            mapPrintDialog.Document = mapPrint;
            mapPrint.DefaultPageSettings.Landscape = true;
            DialogResult result = mapPrintDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                mapPrint.Print();
            }
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            try
            {
                System.Drawing.Image img = mapView.Image;

                Rectangle m = e.MarginBounds;

                if ((double)img.Width / (double)img.Height > (double)m.Width / (double)m.Height)
                {
                    m.Height = (int)((double)img.Height / (double)img.Width * (double)m.Width);
                }
                else
                {
                    m.Width = (int)((double)img.Width / (double)img.Height * (double)m.Height);
                }

                e.Graphics.DrawImage(img, m);
            }
            catch (Exception)
            {

            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Not yet implemented
            //
            //if(comboBox1.SelectedIndex.Equals(0))
            //{
            //    f2.Mapper();
            //}
        }
    }
}
