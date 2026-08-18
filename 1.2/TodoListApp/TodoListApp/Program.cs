using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace TodoListApp
{
    class Todo
    {
        //Variables for the todolist
        List<string> elements = new List<string>();
        int current_element;

        //Instantiate the CallList Method
        static void Main(string[] args)
        {
            Todo list = new Todo();
            list.CallList();
            Console.WriteLine("Done");
            Console.ReadLine();
        }


        //Pull up todo list array
        public void CallList()
        {
            if (elements.Count > 0)
            {
                Console.WriteLine("0. Add item.\n");
                foreach (var element in elements)
                {
                    int e = elements.IndexOf(element) + 1;
                    Console.WriteLine(e.ToString() + ". " + element + "\n");
                }
                Console.WriteLine("Please enter the number of the list item you would like to edit.");
                string num = Console.ReadLine();
                Actions(num);
            }
            else
            {
                Console.WriteLine("Press any button to add item.");
                Console.ReadLine();
                AddItem();
            }
        }

        //Provide options
        private void Actions(string a)
        {
            bool valid = CheckInt(a);
            if(valid)
            {
                int b = ChangeToInt(a) - 1;

                //-1 will be the add function, since the number is 0 but element 1 is the 0 index
                if ((elements.Count - 1) >= b && b >= -1) 
                {
                    if(b == -1)
                    {
                        AddItem();
                    }
                    else
                    {
                        Options(b);
                    }
                }
                else
                {
                    Console.WriteLine("INCORRECT INPUT. Please type a valid number.");
                    CallList();
                }
            }
            else
            {
                Console.WriteLine("INCORRECT INPUT. Please type a valid number.");
                CallList();
            }

        }

        //Options for list item
        public void Options(int number)
        {
            current_element = number;
            Console.WriteLine(elements[number]);
            bool isTicked = elements[number].Contains("<- DONE");

            if (isTicked)
            {
                Console.WriteLine("1. Uncheck\n2. Delete\n3. Back\nPlease enter a number.");
                string num = Console.ReadLine();
                OptionAction(num, isTicked);
            }
            else
            {
                Console.WriteLine("1. Check\n2. Delete\n3. Back\nPlease enter a number.");
                string num = Console.ReadLine();
                OptionAction(num, isTicked);
            }
            
            
        }

        //Options Actions
        private void OptionAction(string number, bool tick)
        {
            bool valid = CheckInt(number);
            if (valid)
            {
                int b = ChangeToInt(number);

                if(b == 1 || b == 2 || b == 3)
                {
                    switch (b)
                    {
                        case 1:
                            TickCheck(tick, current_element);
                            break;
                        case 2:
                            Remove(current_element);
                            break;
                        case 3:
                            CallList(); 
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    Options(current_element);  //number is the option number, current element is the action number
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
                Options(current_element);
            }

        }

        //Check if action is viable
        private bool CheckInt(string a)
        {
            if (int.TryParse(a, out int number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Change value to an Int
        private int ChangeToInt(string number)
        {
            int n = int.Parse(number);
            return n;
        }

        //Add to list
        private void AddItem()
        {
            Console.WriteLine("Please enter the item you'd like to add to the todo list.");
            var item = Console.ReadLine();

            //only allow numbers and letters
            var clean_item = Regex.Replace(item, @"[^a-zA-Z0-9 ]", "");
            elements.Add(clean_item);
            Console.WriteLine("Item has been added.");
            CallList();
        }

        //Remove element from list
        private void Remove(int index)
        {
            //remove selected element from the array
            elements.RemoveAt(index);
            Console.WriteLine("Item has been deleted.");
            CallList();
        }

        //Check/uncheck item
        private void TickCheck(bool c, int index)
        {
            string temp = elements[index];
            string result;
            if (c)
            {
                //if ticked
                result = temp.Replace("<- DONE", "");
            }
            else
            {
                //If not ticked
                result = temp + "<- DONE";
            }

            //Get element and change a section at the end to either -> DONE or remove the -> DONE
            elements[index] = result;
            Console.WriteLine("Item updated!");
            CallList();
        }
    }
}
