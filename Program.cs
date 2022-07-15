using System;
using System.IO;
using System.Threading;

namespace BMSProject

{
    class Program
    {
        static void Main(string[] args)
        {
            string old_name;
            int n=0;
            int trans=0;
            string []complain = new string[0];
            int indx=0;
            string path = "project.txt";
            int idx = -1;
            int option;
            int num = 0;
            int customer_count = 0;
            string name ;  
            string psw;
            string opt ;
            string name_1=",";
            string myString = ",";
            string[] name_arr = new string[100];
            int[] amount_arr = new int[100];
            string[] c_name_arr = new string[100];
            string[] cnic_arr = new string[100];
            string[] f_name_arr = new string[100];
            int[] age_arr = new int[100];
            header();
            load(path, customer_count, name_arr, amount_arr, c_name_arr, cnic_arr, f_name_arr, age_arr);
            indx = findIndexofCus(name_arr, customer_count, name_1);
            getField(myString, num);
            main_menu(opt, name, psw);
            Console.Read();

                if (name == "admin" && psw == "admin@123")
                {
                    while (true)
                    {
                        header();
                        admin_header();
                        Console.WriteLine("Enter the Option!!!");
                        option = int.Parse(Console.ReadLine());
                        if (option == 1)
                        {
                            Console.Clear();
                            header();
                            new_customer(customer_count, name_arr, amount_arr, c_name_arr, cnic_arr, f_name_arr, age_arr);
                            save( path, customer_count, name_arr, amount_arr, c_name_arr, cnic_arr, f_name_arr, age_arr);
                            Console.Clear();
                        }
                        if (option == 2 )
                        {
                            Console.Clear();
                            header();
                         
                            Console.Clear();
                        }
                        if (option == 3 )
                        {
                            Console.Clear();
                            header();
                            //change_info(customer_count,idx,old_name, name_arr, c_name_arr, cnic_arr, age_arr);
                            Console.Clear();
                        }
                        if (option == 4)
                        {
                            Console.Clear();
                            header();
                            branch_code(n,complain);
                            Console.Clear();
                        }
                        if (option == 5)
                        {
                            Console.Clear();
                            header();
                            loan_bank();
                            Console.Clear();
                        }
                        if (option ==6)
                        {
                            Console.Clear();
                            header();
                            bond(amount_arr, indx, trans);
                            Console.Clear();
                        }
                        if (option == 7)
                        {
                            Console.Clear();
                            header();
                        main_menu(opt, psw, name);
                            Console.Clear();
                        }

                    }

                   
                }
            
         
        }
        static void header()
        {
            Console.WriteLine("**************************************************************  ");
            Console.WriteLine("*                                                            *  ");
            Console.WriteLine("*     B A N K                                                *  ");
            Console.WriteLine("*                   M A N A G E M E N T                      *  ");
            Console.WriteLine("*                                            S Y S T E M     *  ");
            Console.WriteLine("*                                                            *  ");
            Console.WriteLine("**************************************************************  ");
            Console.WriteLine("");


        }
        static void admin_header()
        {
            Console.WriteLine(" 1-  Add Customer Information .");
            Console.WriteLine(" 2-  Display Customer Information.");
            Console.WriteLine(" 3-  Update Customer Information");
            Console.WriteLine(" 4-  Enter  and display  the branch code.");
            Console.WriteLine(" 5-  Display the information about giving loan from bank to customer.");
            Console.WriteLine(" 6-  Show   Different Prizes of Bond That is available.");
            Console.WriteLine(" 7-  Go back to main menu  ");
            Console.WriteLine(" 8-  Delete User ");
            Console.WriteLine(" 9-  Exit");

        }
        static void customer_header()
        {
            Console.WriteLine("  1	Press 1 to see your Account details  fines if print.");
            Console.WriteLine("  2	Press 2 to see option of Atm. ");
            Console.WriteLine("  3	Press 3 to apply for loan .");
            Console.WriteLine("  4	Press 4 to see your Statements of your transactions.");
            Console.WriteLine("  5	Press 5 to go back to main menu.   ");
        }
        static void new_customer(int customer_count, string[] name_arr, int[] amount_arr, string[] c_name_arr, string[] cnic_arr, string[] f_name_arr, int[] age_arr)
        {
            customer_count = 0;
            Console.WriteLine("Information of Customer");
            Console.WriteLine("***********");
            Console.WriteLine("Enter the Name ");
            name_arr[customer_count] = Console.ReadLine();
            Console.WriteLine("Enter the City Name ");
            c_name_arr[customer_count] = Console.ReadLine();
            Console.WriteLine("Enter the CNIC ");
            cnic_arr[customer_count] = Console.ReadLine();
            Console.WriteLine("Enter Father name");
            f_name_arr[customer_count] = Console.ReadLine();
            Console.WriteLine("Enter The age");
            age_arr[customer_count] = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The amount want to submit");
            amount_arr[customer_count] = int.Parse(Console.ReadLine());
            customer_count++;
        }

        static void save(string path ,int customer_count, string[] name_arr, int[] amount_arr, string[] c_name_arr, string[] cnic_arr, string[] f_name_arr, int[] age_arr)
        {
            customer_count = 0;
          path = "project.txt";
            StreamWriter fileVariable = new StreamWriter(path, true);
            int counter = 0;
            for (int i = 0; i < customer_count; i++)
            {
                if (counter > 0)
                {
                    fileVariable.WriteLine();
                }
                fileVariable.WriteLine(name_arr[i] + "," + amount_arr[i] + "," + c_name_arr[i] + "," + cnic_arr[i] + "," + f_name_arr[i] + "," + age_arr[i]);
                counter++;
            }
            fileVariable.Flush();
            fileVariable.Close();


        }
        static int findIndexofCus(string[] name_arr, int customer_count, string name_1)
        {
            customer_count = 0;
            for (int i = 0; i < customer_count; i++)
            {
                if (name_arr[i] == name_1)
                {
                    return i;
                }
            }
            return -1;


        }
        static string getField(string myString, int num)
        {
            string output = "";
            int counter = 1;
            for (int i = 0; i < myString.Length; i++)
            {
                if (counter == num && myString[i] != ',')
                {
                    output += myString[i];
                }
                if (myString[i] == ',')
                {
                    counter++;
                }
            }
            return output;
        }
        static void load(string path, int customer_count, string[] name_arr, int[] amount_arr, string[] c_name_arr, string[] cnic_arr, string[] f_name_arr, int[] age_arr)
        {
            path = "project.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string s;
                    s=fileVariable.ReadLine();
                    name_arr[customer_count] = getField(s, 1);
                    amount_arr[customer_count] = int.Parse(getField(s, 2));
                    c_name_arr[customer_count] = getField(s, 3);
                    cnic_arr[customer_count] = getField(s, 4);
                    f_name_arr[customer_count] = getField(s, 5);
                    age_arr[customer_count] = int.Parse(getField(s, 6));
                    customer_count++;
                }
                fileVariable.Close();
            }
        }
        static void change_info(int idx,string old_name, int customer_count, string[] name_arr,  string[] c_name_arr, string[] cnic_arr, int[] age_arr)
        {
            customer_count = 0;
            idx = -1;
            Console.WriteLine("Enter The Old Name!!!");
            old_name = Console.ReadLine();
            for (int i = 0; i < customer_count; i++)
            {
                if (name_arr[i] == old_name)
                {
                    idx = i;
                }
            }
                if (idx == -1)
                {
                   Console.WriteLine( "Name Not Found");
                }
            else
            {
                Console.WriteLine(" Enter New Name ..." );
                 name_arr[idx]=Console.ReadLine();
                Console.WriteLine("Enter New city name...");
                 c_name_arr[idx]=Console.ReadLine();
                Console.WriteLine("Enter New CNIC ...");
                cnic_arr[idx]=Console.ReadLine() ;
                Console.WriteLine(" Enter New age ..." );
                age_arr[idx]=int.Parse(Console.ReadLine());
                Console.WriteLine("**********************");
                Console.WriteLine(">>>>>>>   Updated Successful   >>>>>>>" );
            }
        }
        static void branch_code(int n,string[] complain)
        {

            Console.WriteLine(">>>>>For Helping Branch Code Number>>>>>" );
            Console.WriteLine("                                                                                     " );
            Console.WriteLine("5467");
            Console.WriteLine(" Write Branch Code If Proceed for  Complaint " );
            n = int.Parse(Console.ReadLine());
            if (n == 5467)
            {
                

                Console.WriteLine("  The Complain Is  " );
                complain[0]=Console.ReadLine();

            }
            Console.Read();
        }
        static void loan_bank()
        {
            Console.WriteLine("   <<<<<<<<<<<<<<<<<<<<<List of Different Things on which Bank give Loan>>>>>>>>>>>>>>>>>>>>>" );
            Console.WriteLine("                                                              Loan Value  ");
            Console.WriteLine("                                                                          ");
            Console.WriteLine("  >>> For Cars                                                   2,000K   ");
            Console.WriteLine("                                                                          ");
            Console.WriteLine("  >>> For Houses                                                 5,000K   ");
            Console.WriteLine("                                                                          ");
            Console.WriteLine("  Instructions For Customers who apply For loan :                         ");
            Console.WriteLine("  >>> Customer who is interested in taking loan of either plot or car restricted that he will return this loan with interest...   " );
            Console.WriteLine("  >>> It is also compulsory that money will also deduct from pay every month if customer is interested in taking loan...          " );
            Console.WriteLine("  >>> Bank will also give you a deadline for returning money of loan to bank... ");
            Console.WriteLine("  >>> Customer will Give MarkUP Also If Customer is interested in taking loan...");      
        }
        static void bond(int[] amount_arr, int trans, int indx)
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>Bonds Of Different Prizes>>>>>>>>>>>>>>>>>>");
            Console.Write(">");
            Console.Write("\t\t");
            Console.Write("700");
            Console.Write("\t\t");
            Console.Write("1000");
            Console.WriteLine();
            Console.Write(">");
            Console.Write("\t\t");
            Console.Write("5k");
            Console.Write("\t\t");
            Console.Write("10 K");
            Console.WriteLine();
            Console.Write(">");
            Console.Write(" \t\t");
            Console.Write("20k");
            Console.Write("\t\t");
            Console.Write("40 K");
            Console.WriteLine();
            Console.WriteLine("Select  Amount Which Prize Of Bond Due You want to purchase .... ");
            trans = int.Parse(Console.ReadLine());
            if (trans == 700)
            {
                Console.WriteLine("700 Rupees Bond You Purchased ");
                amount_arr[indx] = amount_arr[indx] - 700;
                Console.WriteLine("Your Remaining amount is");
                Console.Write(amount_arr[indx]);
            }
            if (trans == 1000)
            {
                Console.WriteLine("1000 Rupees Bond You Purchased ");
                amount_arr[indx] = amount_arr[indx] - 1000;
                Console.WriteLine("Your Remaining amount is");
                Console.Write(amount_arr[indx]);
            }
            if (trans == 5000)
            {
                Console.WriteLine("5000 Rupees Bond You Purchased ");
                amount_arr[indx] = amount_arr[indx] - 5000;
                Console.WriteLine("Your Remaining amount is");
                Console.Write(amount_arr[indx]);
            }
            if (trans == 10000)
            {
                Console.WriteLine("10000 Rupees Bond You Purchased ");
                amount_arr[indx] = amount_arr[indx] - 10000;
                Console.WriteLine("Your Remaining amount is");
                Console.Write(amount_arr[indx]);
            }
            if (trans == 20000)
            {
                Console.WriteLine("20000 Rupees Bond You Purchased ");
                amount_arr[indx] = amount_arr[indx] - 20000;
                Console.WriteLine("Your Remaining amount is");
                Console.Write(amount_arr[indx]);
            }
            if (trans == 40000)
            {
                Console.WriteLine("40000 Rupees Bond You Purchased ");
                amount_arr[indx] = amount_arr[indx] - 40000;
                Console.WriteLine("Your Remaining amount is");
                Console.Write(amount_arr[indx]);
            }
        }
        static void main_menu(string opt, string name, string psw)
        {
            Console.WriteLine("Log in as : ");
            Console.WriteLine("Select the option  admin/customer  : ");
            opt = Console.ReadLine();
            if (opt == "admin")
            {
                Console.WriteLine("Enter the Id Name!!!");
                name = Console.ReadLine();
                Console.WriteLine("Enter the Password!!!");
                psw = Console.ReadLine();
                Console.Clear();
            }
        }  
    }
}