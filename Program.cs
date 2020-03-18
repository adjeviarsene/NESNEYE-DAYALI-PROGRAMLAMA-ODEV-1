 /*******************************************************************************
**                   SAKARYA ÜNİVERSİTESİ
**            BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKULTESİ
**             BİLİŞİM SİSTEMLERİ  MÜHENDİSLİĞİ BÖLÜMÜ
**               NESNEYE DA DAYILI PROGRAMLAMA DERSİ
**                      2019-2020 BAHAR DÖNEMİ
**
**
**                  ÖDEV NUMARASI:1
**                  ÖĞRENCİ ADİ:    ARSENE ADJEVI
**                  ÖĞRENCİ NUMARASI: B181200559
**                  DERSİN ALİNDİĞİ GRUP:A
************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;


namespace SOLDİER
{
    public partial class Soldier
    {
        public string matricule;
        public string name;
        public string surname;
        public string nationality;
        public string record;
        public DateTime birthday;
        public string gender;
        public int height;
        public int old;
    }
    public partial class Soldier{
        public double bedNot;
        public double psycoTest;
        public double precision_shooting;
        public double moy;
    }

    
    
    class Program
    {
        /*
        Like all information systems in military services, 
        security must be at a high level.
        That is why everyone who will execute this code 
        must know the username and password that I have put in the string array.
        Note that the username of the index "i" will be used with the password of the index "j" knowing that i must be equal to j.
        example I can use Dk like username and 1111 like password.

        */
        public static int AccessControl(string username, string password)
        {


            int result;
            string[] Username = new string[] { "Mehmetçi", "HavaKuvvet","SiberSavunma"};
            string[] PassWord = new string[] {"03181915", "HavaT", "SiberT"};

            if(username==Username[0] && password==PassWord[0]){
                result=1;
            }
            else if(username==Username[1] && password==PassWord[1]){
                result=1;
            }
            else if(username==Username[2] && password==PassWord[2]){
                result=1;
            }
            else{
                result=0;
            }
            return result;

        }
        public static int OldCalculator(DateTime x) // this metod will calculate the old of the soldier from the dateTime format of colunm 5.
        {
            int Old = 0;
            /*
            I finished writing my code on the 18th day  of the 3rd month.
            So I imagine that all those who were born at this date or before this date  are the exact old of the result of  "DateTime.Now.Year - x.Year"  
            but if they were born after this date then they the result of"DateTime.Now.Year - x.Year" will will be subtracted from 1.
            */
            if (x.Month<=3 && x.Day<=18)
            {
                Old = DateTime.Now.Year - x.Year;
            }
            else 
            {
                Old = (DateTime.Now.Year - x.Year) - 1;
            }
            return Old;
            
        }
        /*
         Nationality_verificator function will check that if the applicant is Türk or not. 
        I took the example that before entering the türk army the applicant must have Türk nationality.
        */
        public static int Nationality_verifictor(string x){ 
            int nan;
            if(x.ToUpper()=="TÜRK"){
                nan=1;
            }
            else{
                nan=0;
            }
            return nan;
        }


        public static int Old_verificator(int x){//This function verified if the applicant  or the soldier are minimum 16 years old.The army is reserved for those who are at least 16 years old.
            int ol;
            
            if(x>=16 && x<=45){
                ol=1;
            }
            else {
                ol=0;
            }
            return ol;
        }
        public static int Height_verificator(int x){//This function verified if the applicant  or the soldier are minimum 170 cm height.The army is reserved for those who are at least 170 cm height(This is Americain Army critaria).
            int hei;
            if(x>=170){
                hei=1;
            }
            else{
                hei=0;
            }
            return  hei;
        }
        public static int Record_detention_verificator(string x){//If the applicant has a criminal or drog trafffic  record, he cannot Preselected to the army.
            int rec;
            if(x.ToUpper()=="NO"){
                rec=1;
            }
            else{
                rec=0;
            }
            return rec;
        }
        public static double Moy_calculator(double xBed,double yPsyco,double zShoot){// this metode must calculate each soldier average.
            double moyenne=(xBed*0.5 +yPsyco*0.25 +zShoot*0.25);
            
            
            return moyenne;
        }

        public class SortedByold : IComparer<Soldier>
        {
            public int Compare(Soldier x,Soldier z)
            {
                if ((x.old.CompareTo(z.old) != 0))
                {
                    return x.old.CompareTo(z.old);
                }
                else
                {
                    return 0;
                }
            }
        }
        
        static void Main(string[] args)
        {
            Random random=new Random();
            string user, pass;
            Soldier soldier = new Soldier();
            List<Soldier> ListofSoldier = new List<Soldier>();
            string message = "Welcome to TurkGeneralForce İnformation System İnterface Like Admin......";
            for(int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(200);
            }
            Console.WriteLine();
            

            Console.Write("Enter Your  Username:");
            user = Console.ReadLine();
            Console.Write("Enter Your  Password:");
            pass = Console.ReadLine();


            if (AccessControl(user, pass) == 1)// if username and the password is correct  
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Welcome to the 2020 soldier recruitment system.Enter candidate information as a text file in Soldat_list.txt.");
                string Catalog = @"Soldier_list.txt";
                StreamReader sr = new StreamReader(Catalog);
                string row;
                do
                {
                    row = sr.ReadLine();
                    string[] colone = row.Split("-");//My reader will cut the line when it encounters "-".
                    
                    ListofSoldier.Add(new Soldier
                    {
                        matricule = colone[0],
                        name = colone[1],
                        surname = colone[2],
                        nationality = colone[3],
                        record = colone[4],
                        birthday= DateTime.ParseExact(colone[5],"MM/dd/yyyy",CultureInfo.InvariantCulture),// I transformed the string of column 5 into datetime format.
                        
                        gender = Convert.ToString(colone[6]),
                        old = OldCalculator(DateTime.ParseExact(colone[5], "MM/dd/yyyy", CultureInfo.InvariantCulture)),
                        height=Convert.ToInt32(colone[7]),
                        
                    });


                } while (!sr.EndOfStream);

                StreamWriter PreListWriter = new StreamWriter(@"PreselectedSoldier.txt");//Preselected applicants informations  will be enregistered in this file.
                StreamWriter statListWriter = new StreamWriter(@"Statistic_file.txt");
                StreamWriter FinalListWriter = new StreamWriter(@"FinalSelectedSoldier.txt");//Final Selected applicants informations will be enregistered in this file.
                SortedByold sortedByold = new SortedByold();//I called this class to sort preselected and finalselected list by old.from the smallest to the biggest old.
                ListofSoldier.Sort(sortedByold);//sorted instance.
                FinalListWriter.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20} {4,-20} {5,-10} {6,-35} {7,-10} {8,-10} {9,-10} {10,-10} {11,-10} {12,-10}", "No", "Matricule", "Name", "Surname", "Nationality", "Record", "Birthday","Gender", "Height", "Old","BedNot","Shooting","PsycoTest","TotalMoy");
                FinalListWriter.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- -");
                PreListWriter.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20} {4,-20} {5,-10} {6,-35} {7,-10} {8,-10} {9,-10} {10,-10} {11,-10} {12,-10}", "No", "Matricule", "Name", "Surname", "Nationality", "Record", "Birthday","Gender", "Height", "Old","BedNot","Shooting","PsycoTest","TotalMoy");
                PreListWriter.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20} {4,-20} {5,-10} {6,-35} {7,-10} {8,-10}", "No", "Matricule", "Name", "Surname", "Nationality", "Record", "Birthday", "Height", "Old");
                
                 int No=1;
                 int Noo=1;
                 int applicant_Number=0;
                 int selected_Female=0;
                 int selected_male=0;
                   foreach (Soldier Alpha in ListofSoldier)
                   {
                    /*
                    I randomly generated the score for Bed, Psychology and precision shots.
                    */
                    Alpha.bedNot=random.Next(1,100);
                    Alpha.psycoTest=random.Next(30,100);
                    Alpha.precision_shooting=random.Next(30,100);
                    Alpha.moy=Moy_calculator(Alpha.bedNot,Alpha.psycoTest,Alpha.precision_shooting);// I called the metod Moy_calculator to calculate the average of each soldier from the randomly generated notes.
                    if(Nationality_verifictor(Alpha.nationality)==1){
                        if(Old_verificator(Alpha.old)==1){
                            if(Height_verificator(Alpha.height)==1){
                                if(Record_detention_verificator(Alpha.record)==1){
                                    PreListWriter.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20} {4,-20} {5,-10} {6,-35} {7,-10} {8,-10} {9,-10} {10,-10} {11,-10} {12,-10} {13,-10}",Noo,Alpha.matricule,Alpha.name,Alpha.surname,Alpha.nationality.ToUpper(),Alpha.record.ToUpper(),Alpha.birthday,Alpha.gender,Alpha.height,Alpha.old ,Alpha.bedNot,Alpha.precision_shooting,Alpha.psycoTest,Alpha.moy);
                                    
                                    if(Alpha.moy>=60){// This is the simple example for selection average.if the applicant average is equal or bigger than 60 ,he or she will be selected.
                                        FinalListWriter.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20} {4,-20} {5,-10} {6,-35} {7,-10} {8,-10} {9,-10} {10,-10} {11,-10} {12,-10} {13,-10}",No,Alpha.matricule,Alpha.name,Alpha.surname,Alpha.nationality.ToUpper(),Alpha.record.ToUpper(),Alpha.birthday,Alpha.gender,Alpha.height,Alpha.old ,Alpha.bedNot,Alpha.precision_shooting,Alpha.psycoTest,Alpha.moy);
                                        Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20} {4,-20} {5,-10} {6,-35} {7,-10} {8,-10} {9,-10} {10,-10} {11,-10} {12,-10} {13,-10}",No,Alpha.matricule,Alpha.name,Alpha.surname,Alpha.nationality.ToUpper(),Alpha.record.ToUpper(),Alpha.birthday,Alpha.gender,Alpha.height,Alpha.old ,Alpha.bedNot,Alpha.precision_shooting,Alpha.psycoTest,Alpha.moy);
                                        if(Alpha.gender.ToUpper()=="FEMALE"){// This is only how many women was selected.
                                            selected_Female++;
                                        }
                                        else{
                                            selected_male++;//selected men number
                                        }
                                        No++;
                                    }
                                    Noo++;
                                    
                                }
                                
                            }
                        }
                        
                    } 
                    applicant_Number++; 
                    
                }  PreListWriter.Close(); FinalListWriter.Close(); 
                statListWriter.WriteLine("Number of Enregitered Candidate this year: "+ applicant_Number);
                statListWriter.WriteLine("Number of selected New female soldier this year: "+ selected_Female);
                statListWriter.WriteLine("Number of selected New Male soldier this year: "+ selected_male);
                //İn this file you can added whatever you want live percentage.
                statListWriter.Close();
            }
            
            else{
                Console.WriteLine("................Access Denied................");
                

            }  
        }
    }
}

