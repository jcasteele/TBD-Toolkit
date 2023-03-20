using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator
{
    class MapGenerator
    {
        static Random rng = new Random();
        static Hashtable legend = new Hashtable();
        const int FLOOR_ROWS = 60;
        const int FLOOR_COLUMNS = 3 * FLOOR_ROWS;
        static List<LinkedList<Room>> occupied_rows = new List<LinkedList<Room>>();
        static List<LinkedList<Room>> occupied_columns = new List<LinkedList<Room>>(FLOOR_COLUMNS);


        static void Main(string[] args)
        {
            initialize_legend();
            char[,] floor = new char[FLOOR_ROWS, FLOOR_COLUMNS];
            generate_map(ref floor, FLOOR_ROWS, FLOOR_COLUMNS);
            initialize_validity();
            List<Room> rooms = sprinkle_rooms(ref floor);
            for(int i = 1; i < rooms.Count; i++)
            {
                recursive_corridor_placement(ref floor, rooms[i - 1].Center(), rooms[i].Center());
            }
            show_map(ref floor, FLOOR_ROWS, FLOOR_COLUMNS);
            Console.ReadKey();
        }

        static void show_map(ref char[,] floor, int rows, int columns)
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    Console.Write(floor[r, c].ToString());
                }
                Console.WriteLine();

            }
        }

        static void generate_map(ref char[,] floor, int rows, int columns)
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    floor[r, c] = legend["blank"].ToString()[0];
                }
            }
        }

        static void initialize_legend()
        {
            legend.Add("floor", 'X');
            legend.Add("wall", '#');
            legend.Add("character", '@');
            legend.Add("door", '+');
            legend.Add("corridor", '=');
            legend.Add("blank", '.');
        }

        static void initialize_validity()
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

        static void recursive_fill_down(ref char[,] floor, Point current, Point goal)
        {
            floor[current.Row(), current.Column()] = legend["wall"].ToString()[0];
            if (!(current.Row() == goal.Row() && current.Column() == goal.Column()))
            {
                floor[current.Row(), current.Column()] = legend["wall"].ToString()[0];
                Point next = new Point(current.Row() + 1, current.Column());
                recursive_fill_down(ref floor, next, goal);
            }
        }

        static void recursive_fill_right(ref char[,] floor, Point current, Point goal)
        {
            floor[current.Row(), current.Column()] = legend["wall"].ToString()[0];
            if (!(current.Row() == goal.Row() && current.Column() == goal.Column()))
            {
                floor[current.Row(), current.Column()] = legend["wall"].ToString()[0];
                Point next = new Point(current.Row(), current.Column() + 1);
                recursive_fill_right(ref floor, next, goal);
            }
        }

        static void generate_room(ref char[,] floor, Room room)
        {
            for (int i = room.NWCorner().Row(); i < room.SWCorner().Row(); i++)
            {
                occupied_rows[i].AddLast(room);
            }
            for (int i = room.NWCorner().Column(); i < room.NECorner().Column(); i++)
            {
                occupied_columns[i].AddLast(room);
            }

            recursive_fill_down(ref floor, room.NWCorner(), room.SWCorner());
            recursive_fill_right(ref floor, room.NWCorner(), room.NECorner());
            recursive_fill_right(ref floor, room.SWCorner(), room.SECorner());
            recursive_fill_down(ref floor, room.NECorner(), room.SECorner());
            recursive_floor_fill(ref floor, room.Center());
        }


        static void recursive_floor_fill(ref char[,] floor, Point current)
        {
            if (floor[current.Row(), current.Column()] == legend["blank"].ToString()[0])
            {
                floor[current.Row(), current.Column()] = legend["floor"].ToString()[0];
                recursive_floor_fill(ref floor, new Point(current.Row() + 1, current.Column()));
                recursive_floor_fill(ref floor, new Point(current.Row(), current.Column() + 1));
                recursive_floor_fill(ref floor, new Point(current.Row() - 1, current.Column()));
                recursive_floor_fill(ref floor, new Point(current.Row(), current.Column() - 1));

            }
        }

        static List<Room> sprinkle_rooms(ref char[,] floor)
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
                    generate_room(ref floor, room);
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


        static bool room_validation(Room room)
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

        static bool point_validation(Point test_point, char[,] floor)
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

        static void recursive_corridor_placement(ref char[,] floor, Point current, Point goal)
        {
            Point difference = new Point(goal.Row() - current.Row(), goal.Column() - current.Column());
            if (!(current.Row() == goal.Row() && current.Column() == goal.Column()))
            {
                if (Math.Abs(difference.Row()) > Math.Abs(difference.Column()))
                {
                    if (floor[current.Row(), current.Column()] == legend["floor"].ToString()[0] || floor[current.Row(), current.Column()] == legend["wall"].ToString()[0])
                    {
                        Point next = new Point(current.Row() + (difference.Row() / Math.Abs(difference.Row())), current.Column());
                        recursive_corridor_placement(ref floor, next, goal);
                    }
                    else
                    { 
                        floor[current.Row(), current.Column()] = legend["corridor"].ToString()[0];
                        door_placement(ref floor, current);
                        Point next = new Point(current.Row() + (difference.Row() / Math.Abs(difference.Row())), current.Column());
                        recursive_corridor_placement(ref floor, next, goal);
                    }
                }
                else if (Math.Abs(difference.Column()) > Math.Abs(difference.Row()))
                {
                    if (floor[current.Row(), current.Column()] == legend["floor"].ToString()[0] || floor[current.Row(), current.Column()] == legend["wall"].ToString()[0])
                    {
                        Point next = new Point(current.Row(), current.Column() + (difference.Column() / Math.Abs(difference.Column())));
                        recursive_corridor_placement(ref floor, next, goal);

                    }
                    else
                    {
                        floor[current.Row(), current.Column()] = legend["corridor"].ToString()[0];
                        door_placement(ref floor, current);
                        Point next = new Point(current.Row(), current.Column() + (difference.Column() / Math.Abs(difference.Column())));
                        recursive_corridor_placement(ref floor, next, goal);
                    }
                }
                else
                {
                    if (rng.Next() % 2 > 0)
                    {
                        if (floor[current.Row(), current.Column()] == legend["floor"].ToString()[0] || floor[current.Row(), current.Column()] == legend["wall"].ToString()[0])
                        {
                            Point next = new Point(current.Row() + (difference.Row() / Math.Abs(difference.Row())), current.Column());
                            recursive_corridor_placement(ref floor, next, goal);
                        }
                        else
                        {
                            floor[current.Row(), current.Column()] = legend["corridor"].ToString()[0];
                            door_placement(ref floor, current);
                            Point next = new Point(current.Row() + (difference.Row() / Math.Abs(difference.Row())), current.Column());
                            recursive_corridor_placement(ref floor, next, goal);
                        }
                    }
                    else
                    {
                        if (floor[current.Row(), current.Column()] == legend["floor"].ToString()[0] || floor[current.Row(), current.Column()] == legend["wall"].ToString()[0])
                        {
                            Point next = new Point(current.Row(), current.Column() + (difference.Column() / Math.Abs(difference.Column())));
                            recursive_corridor_placement(ref floor, next, goal);
                        }
                        else
                        {
                            floor[current.Row(), current.Column()] = legend["corridor"].ToString()[0];
                            door_placement(ref floor, current);
                            Point next = new Point(current.Row(), current.Column() + (difference.Column() / Math.Abs(difference.Column())));
                            recursive_corridor_placement(ref floor, next, goal);
                        }
                    }
                }
            }
        }

        static void door_placement(ref char[,] floor, Point location)
        {
            if(floor[location.Row(), location.Column()] == legend["corridor"].ToString()[0])
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
                else if(floor[location.Row() - 1, location.Column()] == legend["wall"].ToString()[0])
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

    }
}
