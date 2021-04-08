using System;

namespace Penjadwalan_Priority_NonPreemptive
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.Write(" Masukan Banyak Proses :  ");
            int bnykproses = int.Parse(Console.ReadLine());

            string[] namaproses = new string[bnykproses];
            int[] A = new int[bnykproses];
            int[] B = new int[bnykproses];
            int[] P = new int[bnykproses];

            for (int i = 0; i < bnykproses; i++)
            {
                Console.WriteLine(" Proses {0} ", i + 1);
                Console.Write(" Nama Proses :  ");
                namaproses[i] = Console.ReadLine();

                Console.Write(" Waktu Datang :  ");
                A[i] = int.Parse(Console.ReadLine());

                Console.Write(" Lama Proses :  ");
                B[i] = int.Parse(Console.ReadLine());

                Console.Write(" Prioritas :  ");
                P[i] = int.Parse(Console.ReadLine());

            }
            Console.WriteLine(" \t\t\tALGORITMA PENJADWALAN PRIORITAS NON-PREEMPTIVE ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t SEBELUM PROSES ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tNo \t Nama Proses \t Waktu Tiba \t Lama Proses \t Prioritas");
            //proses sebelum ditukar
            for (int i = 0; i < bnykproses; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t{0}. \t   {1} : \t   {2}    \t   {3}    \t   {4}  ", i + 1, namaproses[i], A[i], B[i], P[i]);
            }
            Console.WriteLine();
            //proses setelah ditukar
            Console.WriteLine();
            int finis0 = 0;
            for (int j = 0; j <= bnykproses - 1; j++)
            {
                int singgah = j;
                for (int s = j+1; s <= bnykproses - 1; s++)
                {
                    if (j == 0 && singgah == 0)//khusus untuk indeks nol
                    { 
                        if (A[singgah] > A[s])//cek jika arivall time sblm lbh bsr dari berikutnya maka berikutnya didahulukan
                        {
                            int temp = A[singgah];
                            A[singgah] = A[s];
                            A[s] = temp;
                            string temps = namaproses[singgah];
                            namaproses[singgah] = namaproses[s];
                            namaproses[s] = temps;
                            int temp2 = B[singgah];
                            B[singgah] = B[s];
                            B[s] = temp2;
                            int temp3 = P[singgah];
                            P[singgah] = P[s];
                            P[s] = temp3;

                        }
                        else if (A[singgah] == A[s] && s != singgah)//cek dengan prioritasnya jika dua proses memiliki arival time sama
                        {
                            if (P[singgah] > P[s])
                            {
                                int temp = A[singgah];
                                A[singgah] = A[s];
                                A[s] = temp;
                                string temps = namaproses[singgah];
                                namaproses[singgah] = namaproses[s];
                                namaproses[s] = temps;
                                int temp2 = B[singgah];
                                B[singgah] = B[s];
                                B[s] = temp2;
                                int temp3 = P[singgah];
                                P[singgah] = P[s];
                                P[s] = temp3;
                            }
                        }
                        finis0 = B[0];//sbg acuan untuk memasukan proses2 berikut ke dalam antrian jika masuk sblm proses skrg selesai. ini pada saat indeks = 0
                    }
                    else //j != 0 utk proses 2 ke atas
                    {
                        if (singgah != s )
                        {
                            if (finis0 > A[s] || A[singgah] == A[s])//jika ada proses berikut yang memiliki arivall time lebih kecil atau dtg sebelum proses skrg selesai maka ada dalam antrian
                            {
                                if (P[singgah] > P[s])//cek prioritas yang lbh kecil didahulukan
                                {
                                    int temp = A[singgah];
                                    A[singgah] = A[s];
                                    A[s] = temp;
                                    string temps = namaproses[singgah];
                                    namaproses[singgah] = namaproses[s];
                                    namaproses[s] = temps;
                                    int temp2 = B[singgah];
                                    B[singgah] = B[s];
                                    B[s] = temp2;
                                    int temp3 = P[singgah];
                                    P[singgah] = P[s];
                                    P[s] = temp3;
                                }
                                else if (P[singgah] == P[s])//cek dengan prioritasnya jika dua proses memiliki prioritas sama
                                {
                                    if (A[singgah] > A[s])//arivall time kecil didahulukan
                                    {
                                        int temp = A[singgah];
                                        A[singgah] = A[s];
                                        A[s] = temp;
                                        string temps = namaproses[singgah];
                                        namaproses[singgah] = namaproses[s];
                                        namaproses[s] = temps;
                                        int temp2 = B[singgah];
                                        B[singgah] = B[s];
                                        B[s] = temp2;
                                        int temp3 = P[singgah];
                                        P[singgah] = P[s];
                                        P[s] = temp3;
                                    }
                                }
                            }
                            finis0 = finis0 + B[j];//sbg acuan untuk memasukan proses2 berikut ke dalam antrian jika masuk sblm proses skrg selesai
                        }                   
                    }
                }
            }

            Console.WriteLine("\t\t\t\t PROSES ");
            int start = A[0];//nilai memulai skedul pada indeks = 0
            int finish = A[0] + B[0];//nilai selesai pada indeks = 0
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tNo \t Nama Proses \t Waktu Tiba \t Lama Proses \t Prioritas \t Mulai - Selesai  \tWS    TAT   WT");//mencetak hasil pengurutan
                                                                      
            int TAT = 0;
            int wt = 0;
            double rata2 = 0;
            double rata_rata = 0;
            for (int i = 0; i < bnykproses; i++)//mencetak urustan waktu proses penjadwalan
            {
                if (i == 0)
                {
                    TAT = finish - A[i];
                    wt = TAT - B[i];
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t{0}. \t   {1} : \t   {2}    \t   {3}    \t   {4}   \t\t    {5} - {6} \t\t{7}     {8}   {9}", i+1,namaproses[i], A[i], B[i], P[i], start, finish,finish,TAT,wt);
                    start = start + B[i];//star diubah menjadi star awal + lama waktu proses skrg untuk ditampilkan di proses pada indeks berikut
                    
                    rata2 = rata2 + wt;
                }
                else
                {
                   
                    finish = start + B[i];//sbg akhir yang akan ditampilkan pada indeks yang masuk
                    TAT = finish - A[i];
                    wt = TAT - B[i];
                    rata2 = rata2 + wt;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t{0}. \t   {1} : \t   {2}    \t   {3}    \t   {4}   \t\t    {5} - {6} \t\t{7}     {8}   {9}", i + 1, namaproses[i], A[i], B[i], P[i], start, finish, finish, TAT, wt);
                    start = start + B[i];//star diubah lagi untuk ditampilkan ke proses di indeks berikut
                }
            }
            rata_rata = rata2 / bnykproses;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t Rata-rata waktu tunggu = {0}",rata_rata);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" \tKeterangan : ");
            Console.WriteLine(" \t  WS  = Waktu Selesai Setiap Proses ");
            Console.WriteLine(" \t  TAT = Turn Around Time (Waktu Penyelesaian) ");
            Console.WriteLine(" \t  WT  = Waiting Time (Waktu Tunggu)");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\t\t\t\t\t KELOMPOK 8");
            Console.WriteLine();
            Console.WriteLine(" \t\t\t\t\t1. PUTRI E. BLOEMHARD  (1906080001)");
            Console.WriteLine(" \t\t\t\t\t2. RIZAL J. S. JUANA   (1906080092)");
            Console.WriteLine(" \t\t\t\t\t3. ANDI A. RAHMAN      (1906080094)");
            Console.WriteLine(" \t\t\t\t\t4. MARIO A.T. RAYAMUDA (1906080076)");
            Console.WriteLine(" \t\t\t\t\t5. YUFRIDON C. LUTTU   (1906080070)");
            Console.WriteLine();
            Console.WriteLine("\t===============================     ILMU KOMPUTER '19     ===============================");
            Console.WriteLine("\t=============================== FAKULTAS SAINS DAN TEKNIK ===============================");
            Console.WriteLine("\t=============================== UNIVERSITAS NUSA CENDANA  ===============================");
            Console.ReadKey();
        }
    }
}
