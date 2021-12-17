using System;
using System.Collections.Generic;
using System.Text;

namespace MCC_CsOOP.Admin
{
    abstract class AdminMethod : IAdmin
    {
        protected List<String> nameMhs = new List<string>();
        protected List<String> nimMhs = new List<string>();
        protected List<int> examValMhs = new List<int>();

        public abstract void ContactPerson();

        public void MainMenu()
        {
            Console.Clear();
            ContactPerson();
            Console.WriteLine("Menu Program Data Mahasiswa \n");
            Console.WriteLine("1. Input Data \n2. Show Data \n3. Remove Data \n4. Exit \n");

            Console.Write("Choose menu : ");
            String selectedMenu = Console.ReadLine();
            switch (selectedMenu)
            {
                case "1":
                    InputData();
                    ShowMenu();
                    break;
                case "2":
                    ShowData();
                    ShowMenu();
                    break;
                case "3":
                    RemoveData();
                    ShowMenu();
                    break;
                case "4":
                    ConfirmExit();
                    break;
                default:
                    MainMenu();
                    break;
            } // end of switch case
        } // end of MainMenu()

        public void InputData()
        {
        InputMenuCP:
            Console.Clear();
            Console.WriteLine("/---/ Input Data Mahasiswa \\---\\ \n");
            Console.Write("How much? ");
            int inputCount;
            try
            {
                inputCount = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                goto InputMenuCP;
            }

            Console.Clear();

            for (int i = 0; i < inputCount; i++)
            {
                Console.WriteLine("\nMahasiswa " + (i + 1));
                Console.Write("Name \t \t : ");
                String inputName = Console.ReadLine();
                this.nameMhs.Add(inputName);

                Console.Write("Nim \t \t : ");
                String inputNim = Console.ReadLine();
                this.nimMhs.Add(inputNim);

                // check exam value input
                int inputExamValue;
                do
                {
                reInputCheckPoint:
                    Console.Write("Exam value \t : ");
                    try
                    {
                        inputExamValue = Int32.Parse(Console.ReadLine());
                        if (inputExamValue >= 0 && inputExamValue <= 100)
                        {
                            this.examValMhs.Add(inputExamValue);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect exam value, pls re-input");
                            goto reInputCheckPoint;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Incorrect exam value, pls re-input");
                        goto reInputCheckPoint;
                    }

                } while (inputExamValue < 0 && inputExamValue > 100);
                // end of while loop to check input of exam value
                Console.WriteLine("~~~~~ \t ~~~~~ \t ~~~~~ \t ~~~~~ \t ~~~~~");
            } // end of for loop to input data
            Console.Clear();
            Console.WriteLine("\nInput success :) \n");
        } // end of InputData()

        public void ShowMenu()
        {
            Console.WriteLine("1. Back to main menu \n2. Exit Program");
            Console.Write("\nWhat next? ");
            String userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                MainMenu();
            }
            else if (userChoice == "2")
            {
                Environment.Exit(0);
            }
            else
            {
                ShowMenu();
            } // end of if else
        } // end of ShowMenu()

        public List<Boolean> CheckPass(List<int> examVal)
        {
            List<Boolean> passValue = new List<Boolean>();
            for (int i = 0; i < examVal.Count; i++)
            {
                if (examVal[i] >= 75)
                {
                    Boolean value = true;
                    passValue.Add(value);
                }
                else
                {
                    Boolean value = false;
                    passValue.Add(value);
                }
            } // end of loop
            return passValue;
        } // end of CheckPass()

        public void ShowData()
        {
            Console.Clear();
            if (this.nameMhs.Count < 1 || this.nimMhs.Count < 1 || this.examValMhs.Count < 1)
            {
                Console.Clear();
                Console.WriteLine("There is no data to be shown. \n");
                ShowMenu();
            }
            else
            {
                for (int i = 0; i < this.nameMhs.Count; i++)
                {
                    Console.WriteLine($"\nMahasiswa {(i + 1)}");

                    // ArgumentOutOfRangeException FOR nameMhsList
                    try
                    {
                        Console.WriteLine($"Name \t \t : {this.nameMhs[i]}");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Name doesnt exist");
                    }

                    // ArgumentOutOfRangeException FOR nimMhsList
                    try
                    {
                        Console.WriteLine($"Nim \t \t : {this.nimMhs[i]}");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Nim doesnt exist");
                    }

                    // ArgumentOutOfRangeException FOR examValMhsList
                    try
                    {
                        Console.WriteLine($"Exam value \t : {this.examValMhs[i]}");

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Exam value doesnt exist");
                    }

                    // ArgumentOutOfRangeException FOR CheckPassExam method
                    try
                    {
                        if (CheckPass(this.examValMhs)[i] == true)
                        {
                            Console.WriteLine("Exam result \t : Good Job");
                        }
                        else
                        {
                            Console.WriteLine("Exam result \t : Try again :)");
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                        Console.WriteLine("Exam result \t : ???");
                    }

                    Console.WriteLine("\n~~~~~ \t ~~~~~ \t ~~~~~ \t ~~~~~ \t ~~~~~ \n");
                } // end of loop
            } // end of else
        } // end of ShowData()

        public void RemoveData()
        {
        RemoveCP:
            Console.Clear();
            if (this.nameMhs.Count < 1 || this.nimMhs.Count < 1 || this.examValMhs.Count < 1)
            {
                Console.Clear();
                Console.WriteLine("There is no data to be removed. \n");
                ShowMenu();
            }
            else
            {
                ShowData();
                Console.Write("Remove Data Mahasiswa ke- : ");
                int selectData;
                try
                {
                    selectData = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    // RemoveData(); // klo ga pake ini variabel selectData jadi gada isi
                    goto RemoveCP; // klo pake ini masalah di atas fix .-.
                }

                if (this.nameMhs.Count < selectData)
                {
                    RemoveData();
                }
                else
                {
                    Console.Write($"Are u sure to remove Mahasiswa ke-{selectData} (Y/n) ? ");
                    string confirmRemove = Console.ReadLine();

                    switch (confirmRemove.ToLower())
                    {
                        case "y":
                            RemoveDataProcess(selectData - 1);
                            break;
                        case "n":
                            RemoveData();
                            break;
                        default:
                            ShowMenu();
                            break;
                    }
                }
            } // end of if else
        } // end of RemoveData()

        public void RemoveDataProcess(int dataIndex)
        {
            try
            {
                this.nameMhs.RemoveAt(dataIndex);
                this.nimMhs.RemoveAt(dataIndex);
                this.examValMhs.RemoveAt(dataIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                RemoveData();
            }
            Console.Clear();
            Console.WriteLine("\nData removed :( \n");
        } // end of RemoveDataProcess()

        public void ConfirmExit()
        {
            Console.Write("\nAre u sure want to exit (Y/n) ? ");
            String confirm = Console.ReadLine();
            switch (confirm.ToLower())
            {
                case "y":
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                case "n":
                    MainMenu();
                    break;
                default:
                    ConfirmExit();
                    break;
            }
        } // end of ConfirmExit()

    }
}
