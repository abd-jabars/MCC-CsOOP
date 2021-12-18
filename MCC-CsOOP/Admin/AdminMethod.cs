using System;
using System.Collections.Generic;
using System.Text;

namespace MCC_CsOOP.Admin
{
    abstract class AdminMethod : IAdmin
    {
        public abstract void ContactPerson();

        public void MainMenu()
        {
            Console.Clear();
            ContactPerson();
            Console.WriteLine("Menu Program Data Mahasiswa \n");
            Console.WriteLine("1. Input Data \n2. Show Data \n3. Remove Data \n4. Exit \n");

            Console.Write("Choose menu : ");

        }

        public void SecondaryMenu()
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
                Console.Clear();
                Environment.Exit(0);
            }
            else
            {
                SecondaryMenu();
            } // end of if else
        }

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
        }

        public void InputData(List<Mahasiswa> mhsUniv)
        {
            Console.Clear();
            Console.WriteLine("/---/ Input Data Mahasiswa \\---\\ \n");
            Console.Write("How much? ");
            String inputHowMany = Console.ReadLine();
            bool isNumber = Int32.TryParse(inputHowMany, out int inputMany);
            if (isNumber == false)
            {
                InputData(mhsUniv);
            }
            else
            {
                Console.Clear();

                for (int i = 0; i < inputMany; i++)
                {
                    Console.WriteLine("\nMahasiswa " + (i + 1));
                    Console.Write("Name \t \t : ");
                    String inputName = Console.ReadLine();

                    Console.Write("Nim \t \t : ");
                    String inputNim = Console.ReadLine();

                InputExamValueCP:
                    Console.Write("Exam value \t : ");
                    String inputExamVal = Console.ReadLine();
                    bool isExamVal = Int32.TryParse(inputExamVal, out int examVal);
                    if (isExamVal == false || examVal < 0 || examVal > 100)
                    {
                        Console.WriteLine("Incorrect exam value, pls re-input");
                        goto InputExamValueCP;
                    }
                    else
                    {
                        mhsUniv.Add(new Mahasiswa(inputName, inputNim, examVal));
                    }

                    Console.WriteLine("~~~~~ \t ~~~~~ \t ~~~~~ \t ~~~~~ \t ~~~~~");
                }
                Console.Clear();
                Console.WriteLine("\nInput success :) \n");
                SecondaryMenu();
            }

        }

        public List<Boolean> CheckPass(List<Mahasiswa> mhsUniv)
        {
            List<Boolean> isPass = new List<Boolean>();
            for (int i = 0; i < mhsUniv.Count; i++)
            {
                if (mhsUniv[i].examValMhs >= 75)
                {
                    Boolean pass = true;
                    isPass.Add(pass);
                }
                else
                {
                    Boolean pass = false;
                    isPass.Add(pass);
                }
            }
            return isPass;
        }

        public void ShowDataProcess(List<Mahasiswa> mhsUniv)
        {
            Console.Clear();
            if (mhsUniv.Count < 1)
            {
                Console.Clear();
                Console.WriteLine("There is no data to be shown. \n");
            }
            else
            {
                for (int i = 0; i < mhsUniv.Count; i++)
                {
                    Console.WriteLine($"\nMahasiswa {(i + 1)}");

                    // ArgumentOutOfRangeException FOR nameMhsList
                    try
                    {
                        Console.WriteLine($"Name \t \t : {mhsUniv[i].nameMhs}");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Name doesnt exist");
                    }

                    // ArgumentOutOfRangeException FOR nimMhsList
                    try
                    {
                        Console.WriteLine($"Nim \t \t : {mhsUniv[i].nimMhs}");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Nim doesnt exist");
                    }

                    // ArgumentOutOfRangeException FOR examValMhsList
                    try
                    {
                        Console.WriteLine($"Exam value \t : {mhsUniv[i].examValMhs}");

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Exam value doesnt exist");
                    }

                    // ArgumentOutOfRangeException FOR CheckPassExam method
                    try
                    {
                        if (CheckPass(mhsUniv)[i] == true)
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
                }
            }
        }

        public void ShowData(List<Mahasiswa> mhsUniv)
        {
            ShowDataProcess(mhsUniv);
            SecondaryMenu();
        }

        public void RemoveData(List<Mahasiswa> mhsUniv)
        {
            Console.Clear();
            if (mhsUniv.Count < 1)
            {
                Console.Clear();
                Console.WriteLine("There is no data to be removed. \n");
                SecondaryMenu();
            }
            else
            {
                ShowDataProcess(mhsUniv);
                Console.Write("Remove Data Mahasiswa number- : ");
                String selectToRemove = Console.ReadLine();
                bool isNumber = Int32.TryParse(selectToRemove, out int removeNumber);
                if (isNumber == false || mhsUniv.Count < removeNumber || removeNumber <= 0)
                {
                    RemoveData(mhsUniv);
                }
                else
                {
                    Console.Write($"Are u sure to remove Mahasiswa number-{removeNumber} (Y/n) ? ");
                    string confirmRemove = Console.ReadLine();

                    switch (confirmRemove.ToLower())
                    {
                        case "y":
                            RemoveDataProcess(mhsUniv, removeNumber - 1);
                            break;
                        case "":
                            RemoveDataProcess(mhsUniv, removeNumber - 1);
                            break;
                        default:
                            RemoveData(mhsUniv);
                            break;
                    }
                }
            }
        }

        private void RemoveDataProcess(List<Mahasiswa> mhsUniv, int dataIndex)
        {
            mhsUniv.RemoveAt(dataIndex);
            Console.Clear();
            Console.WriteLine("\nData removed :( \n");
            SecondaryMenu();
        }
    }
}
