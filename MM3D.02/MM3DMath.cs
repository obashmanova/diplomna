using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM3D._02
{
    // V_i переглянути посилання t на H має бути < 10
    class MM3DMath
    {
        public int
           z_time = 38,
           m_time = 38 * 3,
           m1 = 11,
           m2 = 11,
            m2_ = 7,
            m = 0,
           m3 = 11,
            m3_ = 5,
            a = 1,
            b = 1,
            counter2D = 0,
            f_choise = 10,
            coeff_choise = 0;
            



        double[] a_kc = new double[6] { 0.0010054, 0.010563, -0.074311, 0.17051, -0.16703, 0.059404 };
        double[] b_kt = new double[6] { 0.0030925, 0.010404, 0.00012844, 0.010819, -0.026097, 0.014154 };

        public double
            H_1 = 10,//0,//
            H_2 = 1,//0,//
            H_0 = 1,//0,//
            T_0 = 15,
            T_1 = 30,
            T_2 = 15.0,
            C_1 = 350.0,
            C_2 = 8,
            C_0 = 8,
            C_m = 350,// = C_1~(x,t)
            T_m = 30,
            conc = 50,

            C_t = 2.137e6,

            a_h = 1,
            n_p = 0.3,// n_p1 = 0.2 , n_p2 = 0.3 , n_p3 = 0.4;

            Alpha_T = 1E-6,//0,//
            Alpha_Tb = 0,
            D = 2E-3,// 1 , 2, 3
            D_t = 2E-3,// 1 , 2 , 3
            ro = 1100,
            C_p = 4.2e3, // 1 , 2 , 3
            tau = 30,
            h1 = 1,
            h2 = 1,
            h3 = 1,
            //Lamda = 108 * 10E3, /// Lamda_t 1 , 2 , 3
            LamdaT = 108E3,//259.2,//
            LamdaT_ = 259E3, /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/
            gamma = 6.5E-5, // 1 , 2 , 3
            gamma_r = 1E4,                               ///////////////////////////////////////////////////////////////////////////////////
                                                         //gamma_zv1 = 2.3 * 10E4,
            gamma_zv2 = 1.3E4,//1.3 * 10E4,//
            gamma_pr3 = 1.7E4,

            Lamda1 = 1.2E10,
            Miu1 = 1.2E10,
            E1 = 2.34E10,
            Lamda2 = 1.35E7,
            Miu2 = 0.9E7,
            E2 = 2.34E7,
            Lamda3 = 1.7E7,
            Miu3 = 1.15E7,
            E3 = 3E7,
            mju_b = 0,
            lam_b = 0,
            V_C = 2.8E-5,//0,//2.8 * 10E-5,// 
            V_T = 2.8E-6,//0,//2.8 * 10E-4 ,//2.8 * 10E-6,//2.8 * 10E-5,//
            K = 0.001,
            // Lame

            Lame_L = 5,
            Lame_M = 5,
            eps = 1E-12;

        public double[]
            LamCoeff,
            MjuCoeff,
            ECoeff;

        //  V = 0.35; 
        public double[,,,]
            C, C_b,
            H, H_b,
            //H1, H2, H3,
            T, T_b,
            V,
            V_b,
            V_z_b,
            U_z_b,
            W_z_b,
            V_z,
            U_z,
            W_z,
            E_x,
            E_y,
            E_z,
            E_xy,
            E_xz,
            E_yz,
            sigma_x,
            sigma_y,
            sigma_z,
            tau_xy,
            tau_xz,
            tau_yz,
            mju_,
            lam_,
            E_,
            E,

            E_x_b,
            E_y_b,
            E_z_b,
            E_xy_b,
            E_xz_b,
            E_yz_b,
            sigma_x_b,
            sigma_y_b,
            sigma_z_b,
            tau_xy_b,
            tau_xz_b,
            tau_yz_b,

            E_b
            ;
        //,
        //D1, D2, D3,
        // Niu;
        //LamdaT;
        //V1, V2, V3,
        //V_T,//V_T1, V_T2, V_T3,
        //V_C,//V_C1, V_C2, V_C3,
        //K;
        //K1, K2, K3;

        public MM3DMath()
        {

        }

        public void Run()
        {
            C = new double[m_time, m1, m2, m3];
            H = new double[m_time, m1, m2, m3];
            T = new double[m_time, m1, m2, m3];
            V = new double[m_time, m1, m2, m3];
            V_z = new double[z_time, m1, m2, m3];
            W_z = new double[z_time, m1, m2, m3];
            U_z = new double[z_time, m1, m2, m3];
            E_x = new double[z_time, m1, m2, m3];
            E_y = new double[z_time, m1, m2, m3];
            E_z = new double[z_time, m1, m2, m3];
            E_xy = new double[z_time, m1, m2, m3];
            E_xz = new double[z_time, m1, m2, m3];
            E_yz = new double[z_time, m1, m2, m3];
            sigma_x = new double[z_time, m1, m2, m3];
            sigma_y = new double[z_time, m1, m2, m3];
            sigma_z = new double[z_time, m1, m2, m3];
            tau_xy = new double[z_time, m1, m2, m3];
            tau_xz = new double[z_time, m1, m2, m3];
            tau_yz = new double[z_time, m1, m2, m3];
            mju_ = new double[z_time, m1, m2, m3];
            lam_ = new double[z_time, m1, m2, m3];
            E_ = new double[z_time, m1, m2, m3];
            E = new double[z_time, m1, m2, m3];

            C_b = new double[m_time, m1, m2, m3];
            H_b = new double[m_time, m1, m2, m3];
            T_b = new double[m_time, m1, m2, m3];
            V_b = new double[m_time, m1, m2, m3];
            V_z_b = new double[z_time, m1, m2, m3];
            W_z_b = new double[z_time, m1, m2, m3];
            U_z_b = new double[z_time, m1, m2, m3];
            E_x_b = new double[z_time, m1, m2, m3];
            E_y_b = new double[z_time, m1, m2, m3];
            E_z_b = new double[z_time, m1, m2, m3];
            E_xy_b = new double[z_time, m1, m2, m3];
            E_xz_b = new double[z_time, m1, m2, m3];
            E_yz_b = new double[z_time, m1, m2, m3];
            sigma_x_b = new double[z_time, m1, m2, m3];
            sigma_y_b = new double[z_time, m1, m2, m3];
            sigma_z_b = new double[z_time, m1, m2, m3];
            tau_xy_b = new double[z_time, m1, m2, m3];
            tau_xz_b = new double[z_time, m1, m2, m3];
            tau_yz_b = new double[z_time, m1, m2, m3];
            E_b = new double[z_time, m1, m2, m3];

            if (coeff_choise == 0)
            {
                LamCoeff = new double[6] { 0, 0, -1798.96, 4314.732, -2615.37, 2545.743 };
                MjuCoeff = new double[6] { 0, 0, -1205.28, 2880.321, -1741.92, 1696.324 };
                ECoeff = new double[6] { 0, 0, -0.000393, 0.1878866, -22.70202, 4410.552 };
            }
            else
            {
                LamCoeff = new double[6] { 0.11658, -19.13338, -0.01433, 0.07664, -18.29209, 4875.65995 };
                MjuCoeff = new double[6] { 0.05347, -9.56879, -0.01451, 0.04571, -8.02227, 2098.68892 };
                ECoeff = new double[6] { 0.13495, -22.19182, -0.01556, 0.08929, -21.30479, 5646.9363 };
            }

            for (int t = 0; t < m_time; t++)
                for (int i1 = 0; i1 <= m1 - 1; i1++)
                    for (int i2 = 0; i2 <= m2 - 1; i2++)
                    { 
                        for (int i3 = 0; i3 <= m3 - 1; i3++)
                        {
                            T_b[t, i1, i2, i3] = 0;
                        }
                        for (int i3 = 0; i3 <= 2 - 1; i3++)
                        {
                            C_b[t, i1, i2, i3] = 0;
                        }
                        for (int i3 = 0; i3 <= m3_ - 1; i3++)
                        {
                            C_b[t, i1, i2, i3] = 0;
                        }
                    }

            //Zero time all layers

            for (int i1 = 1; i1 < m1 - 1; i1++)
                for (int i2 = 1; i2 < m2 - 1; i2++)
                {
                    for (int i3 = 1; i3 < m2_; i3++) 
                    {
                        C[0, i1, i2, i3] = C_0;
                        H[0, i1, i2, i3] = H_0;
                        H_b[0, i1, i2, i3] = H_0;
                    }
                    for (int i3 = 1; i3 < m3_; i3++)
                    {
                        C[0, i1, i2, i3] = C_0;
                        H[0, i1, i2, i3] = H_0;
                        H_b[0, i1, i2, i3] = H_0;
                    }
                    for (int i3 = 1; i3 < m3; i3++)
                        T[0, i1, i2, i3] = T_0;
                }

            ////////////////////////////////////////////////////////

            for (int t = 0; t < m_time; t++)
                for (int i1 = 0; i1 < m1; i1++)
                    for (int i2 = 0; i2 < m2; i2++)
                    {
                        //???????   
                        // t=time*3 x=i y=i z=0
                        C[t, i1, i2, 0] = C_0;
                        T[t, i1, i2, 0] = T_0;
                        H[t, i1, i2, 0] = H_0;
                        H_b[t, i1, i2, 0] = H_0;

                        // t=time*3 x=i y=i z=m2_-1
                        C[t, i1, i2, m2_] = C_1;
                        T[t, i1, i2, m3 - 1] = T_0;
                        H[t, i1, i2, m2_] = H_1;
                        H_b[t, i1, i2, m2_] = H_1;

                        // t=time*3 x=i y=i z=m3_-1
                        C[t, i1, i2, m3_] = C_1;
                        T[t, i1, i2, m3 - 1] = T_0;
                        H[t, i1, i2, m3_] = H_1;
                        H_b[t, i1, i2, m3_] = H_1;
                    }



            ///////////////////////////////////////////////////////
            // t=time*3 x=m1 y=i z=i
            for (int t = 0; t < m_time; t++)
                for (int i2 = 0; i2 < m2; i2++)
                {
                    for (int i3 = 0; i3 < m2_; i3++)
                    {
                        C[t, m1 - 1, i2, i3] = C_2;
                        H[t, m1 - 1, i2, i3] = H_2;
                        H_b[t, m1 - 1, i2, i3] = H_2;
                    }

                    for (int i3 = 0; i3 < m3_; i3++)
                    {
                        C[t, m1 - 1, i2, i3] = C_2;
                        H[t, m1 - 1, i2, i3] = H_2;
                        H_b[t, m1 - 1, i2, i3] = H_2;
                    }

                    for (int i3 = 0; i3 < m3; i3++)
                    {
                        T[t, m1 - 1, i2, i3] = T_2;
                    }
                }

            // t=time*3 x=i y=m2 z=i
            for (int t = 0; t < m_time; t++)
                for (int i1 = 0; i1 < m1; i1++)
                {
                    for (int i3 = 0; i3 < m2_; i3++)
                    {
                        C[t, i1, m2 - 1, i3] = C_2;
                        H[t, i1, m2 - 1, i3] = H_2;
                        H_b[t, i1, m2 - 1, i3] = H_2;
                    }

                    for (int i3 = 0; i3 < m3_; i3++)
                    {
                        C[t, i1, m2 - 1, i3] = C_2;
                        H[t, i1, m2 - 1, i3] = H_2;
                        H_b[t, i1, m2 - 1, i3] = H_2;
                    }

                    for (int i3 = 0; i3 < m3; i3++)
                    {
                        T[t, i1, m2 - 1, i3] = T_2;
                    }
                }

            ////////////////////////////////////////////////////////
            // t=time*3 x=0 y=i z=i
            for (int t = 0; t < m_time; t++)
                for (int i2 = 0; i2 < m2; i2++)
                {
                    for (int i3 = 0; i3 < m2_; i3++)
                    {
                        C[t, 0, i2, i3] = C_1;
                        H[t, 0, i2, i3] = H_1;
                        H_b[t, 0, i2, i3] = H_1;
                    }

                    for (int i3 = 0; i3 < m3_; i3++)
                    {
                        C[t, 0, i2, i3] = C_1;
                        H[t, 0, i2, i3] = H_1;
                        H_b[t, 0, i2, i3] = H_1;
                    }

                    for (int i3 = 0; i3 < m3; i3++)
                    {
                        T[t, 0, i2, i3] = T_1;
                    }
                }

            // t=time*3 x=i y=0 z=i
            for (int t = 0; t < m_time; t++)
                for (int i1 = 0; i1 < m1; i1++)
                {
                    for (int i3 = 0; i3 < m2_; i3++)
                    {
                        C[t, i1, 0, i3] = C_1;
                        H[t, i1, 0, i3] = H_1;
                        H_b[t, i1, 0, i3] = H_1;
                    }

                    for (int i3 = 0; i3 < m3_; i3++)
                    {
                        C[t, i1, 0, i3] = C_1;
                        H[t, i1, 0, i3] = H_1;
                        H_b[t, i1, 0, i3] = H_1;
                    }

                    for (int i3 = 0; i3 < m3; i3++)
                    {
                        T[t, i1, 0, i3] = T_1;
                    }
                }

            for (int t = 0; t < z_time - 1; t++)
                for (int i1 = 0; i1 <= m1 - 1; i1++)
                    for (int i2 = 0; i2 <= m2 - 1; i2++)
                        for (int i3 = 0; i3 <= m3 - 1; i3++)
                        {
                            U_z[t, i1, i2, i3] = 0.000;
                            V_z[t, i1, i2, i3] = 0.000;
                            W_z[t, i1, i2, i3] = 0.000;
                        }

            // Progonca + Gaus_Zeidel
            for (int t = 0; t < z_time - 2; t++)
            {
                // Цикл i1,i2,i3
                //Gaus_Zeidel_H(i1, i2, i3, t);


                for (int n = 1; n <= 3; n++)
                {
                    V_i(t, n);

                    // константні значення
                    for (int i1 = 1; i1 < m1 - 1; i1++)
                        for (int i2 = 1; i2 < m2 - 1; i2++)
                            for (int i3 = 1; i3 < m3 - 1; i3++)
                            {
                                // T[t * 3 + n, i1, i2, i3] = 14;
                                // H[t * 3 + n, i1, i2, i3] = 0;
                                // C[t * 3 + n, i1, i2, i3] = 8;
                            }

                    Progonca_T(t, n);
                    Progonca_C(t, n);
                    Progonca_H(t, n);
                    Gaus_Zeidel_U_V_W(t, n);
                    Deform(t, n);
                    Naprug(t, n);

                    Progonca_H_b(t, n);
                    Gaus_Zeidel_U_V_W_b(t, n);
                    Deform_b(t, n);
                    Naprug_b(t, n);

                }
            }
        }

        // Lamda для температури
        public double Lamda_(int i1, int i2, int i3, int t, int n)
        {
            return (1.0 / 3.0) * (LamdaT + LamdaT);
            /*switch (n)
            {
                case 1: { return (double)(1.0 / 3) * (LamdaT1[t, i1, i2, i3] + LamdaT1[t, i1 - 1, i2, i3]); }
                case 2: { return (double)(1.0 / 3) * (LamdaT2[t, i1, i2, i3] + LamdaT2[t, i1, i2 - 1, i3]); }
                case 3: { return (double)(1.0 / 3) * (LamdaT3[t, i1, i2, i3] + LamdaT3[t, i1, i2, i3 - 1]); }
                default: return 0;
            }*/
        }

        public double Lamda__(int i1, int i2, int i3, int t, int n)
        {
            return (1.0 / 3.0) * (LamdaT_ + LamdaT_);
        }

        public double K_C(int i1, int i2, int i3, int t, int n)
        {
            int time = t * 3 + n - 1;
            double uc = C[time, i1, i2, i3] / C_m;
            return ((a_kc[5] * (Math.Pow(uc, 5)) + a_kc[4] * Math.Pow(uc, 4) + a_kc[3] * Math.Pow(uc, 3) + a_kc[2] * Math.Pow(uc, 2) + a_kc[1] * uc + a_kc[0]));
        }

        public double K_T(int i1, int i2, int i3, int t, int n)
        {
            int time = t * 3 + n - 1;
            double ut = T[time, i1, i2, i3] / T_m;
            return ((b_kt[5] * (Math.Pow(ut, 5)) + b_kt[4] * Math.Pow(ut, 4) + b_kt[3] * Math.Pow(ut, 3) + b_kt[2] * Math.Pow(ut, 2) + b_kt[1] * ut + b_kt[0]));
        }

        public double K_(int i1, int i2, int i3, int t, int n)
        {
            return (K_C(i1, i2, i3, t, n) * K_T(i1, i2, i3, t, n)) / K;//0;//  ; // //10e2//0//
                                                                       // + K_C(i1, i2, i3, t, n) * K_T(i1, i2, i3, t, n) / K ;
                                                                       // (1.0/K) * K_C(i1,i2,i3,t) * K_T(i1, i2, i3, t);
                                                                       /*switch (n)
                                                                       {
                                                                           case 1: { return (double)(1.0 / 3) * (LamdaT1[t, i1, i2, i3] + LamdaT1[t, i1 - 1, i2, i3]); }
                                                                           case 2: { return (double)(1.0 / 3) * (LamdaT2[t, i1, i2, i3] + LamdaT2[t, i1, i2 - 1, i3]); }
                                                                           case 3: { return (double)(1.0 / 3) * (LamdaT3[t, i1, i2, i3] + LamdaT3[t, i1, i2, i3 - 1]); }
                                                                           default: return 0;
                                                                       }*/
        }

        public double K_g(int i1, int i2, int i3, int t, int n)
        {
            return (K_(i1, i2, i3, t, n) + K_(i1, i2, i3 - 1, t, n)) / 2.0;
        }
        public double K_g_b(int i1, int i2, int i3, int t, int n)
        {
            return (K + K) / 2.0;
        }
        public double V_T_g(int i1, int i2, int i3, int t, int n)
        {
            return (double)(V_T + V_T) / 2.0;
        }

        public double V_C_g(int i1, int i2, int i3, int t, int n)
        {
            return (V_C + V_C) / 2.0;
        }

        public double Lamda_t(int i1, int i2, int i3, int t, int n)
        {
            return LamdaT;
            /*switch (n)
            {
                case 1: { return (double)(1.0 / 3) * (LamdaT1[t, i1, i2, i3] + LamdaT1[t, i1 - 1, i2, i3]); }
                case 2: { return (double)(1.0 / 3) * (LamdaT2[t, i1, i2, i3] + LamdaT2[t, i1, i2 - 1, i3]); }
                case 3: { return (double)(1.0 / 3) * (LamdaT3[t, i1, i2, i3] + LamdaT3[t, i1, i2, i3 - 1]); }
                default: return 0;
            }*/
        }

        public double Lamda_t_(int i1, int i2, int i3, int t, int n)
        {
            return LamdaT_;
        }

        public double V_T_(int i1, int i2, int i3, int t)
        {
            return (double)V_T;
        }

        public double V_C_(int i1, int i2, int i3, int t)
        {
            return V_C;
        }

        /*
        public double V_(int i1, int i2, int i3, int t)
        {
            switch (n)
            {
                case 1: { return (double)(1.0 / 3) * (D1[t, i1, i2, i3] + D1[t, i1 - 1, i2, i3]); }
                case 2: { return (double)(1.0 / 3) * (D2[t, i1, i2, i3] + D2[t, i1, i2 - 1, i3]); }
                case 3: { return (double)(1.0 / 3) * (D3[t, i1, i2, i3] + D3[t, i1, i2, i3 - 1]); }
                default: return 0;
            }
        }
        */

        // d_i для концентрації
        public double d_i(int i1, int i2, int i3, int t, int n)
        {
            return (double)(1.0 / 3.0) * (D + D);
            /*
            switch (n)
            {
                case 1: { return (double)(1.0 / 3) * (D1[t, i1, i2, i3] + D1[t, i1 - 1, i2, i3]); }
                case 2: { return (double)(1.0 / 3) * (D2[t, i1, i2, i3] + D2[t, i1, i2 - 1, i3]); }
                case 3: { return (double)(1.0 / 3) * (D3[t, i1, i2, i3] + D3[t, i1, i2, i3 - 1]); }
                default: return 0;
            }*/
        }

        public double d_i_t(int i1, int i2, int i3, int t, int n)
        {
            return (double)(1.0 / 3.0) * (D_t + D_t);
            /*
            switch (n)
            {
                case 1: { return (double)(1.0 / 3) * (D1[t, i1, i2, i3] + D1[t, i1 - 1, i2, i3]); }
                case 2: { return (double)(1.0 / 3) * (D2[t, i1, i2, i3] + D2[t, i1, i2 - 1, i3]); }
                case 3: { return (double)(1.0 / 3) * (D3[t, i1, i2, i3] + D3[t, i1, i2, i3 - 1]); }
                default: return 0;
            }*/
        }

        public double D_(int i1, int i2, int i3, int t, int n)
        {
            return D;
        }

        public double D_t_(int i1, int i2, int i3, int t, int n)
        {
            return D_t;
        }

        // Niu для температури
        public double Niu_(int i1, int i2, int i3, int t, int n)
        {

            int time = t * 3 + n - 1;

            switch (n)
            {
                case 1: return (1.0 / ((1.0 + h1 * ro * C_p * Math.Abs(V[time, i1, i2, i3])) / (3.0 * Lamda_t(i1, i2, i3, t, n))));
                case 2: return (1.0 / ((1.0 + h2 * ro * C_p * Math.Abs(V[time, i1, i2, i3])) / (3.0 * Lamda_t(i1, i2, i3, t, n))));
                case 3: return (1.0 / ((1.0 + h3 * ro * C_p * Math.Abs(V[time, i1, i2, i3])) / (3.0 * Lamda_t(i1, i2, i3, t, n))));
                default: return 0;

            }
        }

        // Niu_ для концентрації
        public double Niu_C(int i1, int i2, int i3, int t, int n)
        {
            int time = t * 3 + n - 1;

            switch (n)
            {
                case 1: return (1.0 / ((1.0 + h1 * ro * C_p * Math.Abs(V[time, i1, i2, i3])) / (3 * D_(i1, i2, i3, t, n))));
                case 2: return (1.0 / ((1.0 + h2 * ro * C_p * Math.Abs(V[time, i1, i2, i3])) / (3 * D_(i1, i2, i3, t, n))));
                case 3: return (1.0 / ((1.0 + h3 * ro * C_p * Math.Abs(V[time, i1, i2, i3])) / (3 * D_(i1, i2, i3, t, n))));
                default: return 0;
            }
        }

        /*
         
        Шв у насиченому шарі
                 
        */


        //Швидкість Vi

        /// Змынити t na time dla C T
        public void V_i(int t, int n)
        {
            int time = t * 3 + n - 1;

            for (int i1 = 0; i1 < m1; i1++)
                for (int i2 = 0; i2 < m2; i2++)
                    for (int i3 = 0; i3 < m2_; i3++)     ///////////////
                    {
                        switch (n)
                        {
                            case 1:
                                {
                                    if (i1 == m1 - 1)
                                        V[time, i1, i2, i3] =
                                         -K_(i1, i2, i3, t, n) * (/*H1*/H[time, i1, i2, i3] - /*H1*/H[time, i1 - 1, i2, i3]) / (h1)
                                         + /*V_C1*/V_C_(i1, i2, i3, t) * (C[time, i1, i2, i3] - C[time, i1 - 1, i2, i3]) / (h1)
                                         + /*V_C1*/V_T_(i1, i2, i3, t) * (T[time, i1, i2, i3] - T[time, i1 - 1, i2, i3]) / (h1);
                                    else
                                        if (i1 == 0)
                                        V[time, i1, i2, i3] =
                                            -K_(i1, i2, i3, t, n) * (/*H1*/H[time, i1 + 1, i2, i3] - /*H1*/H[time, i1, i2, i3]) / (h1)
                                            + /*V_C1*/V_C_(i1, i2, i3, t) * (C[time, i1 + 1, i2, i3] - C[time, i1, i2, i3]) / (h1)
                                            + /*V_C1*/V_T_(i1, i2, i3, t) * (T[time, i1 + 1, i2, i3] - T[time, i1, i2, i3]) / (h1);
                                    else
                                        V[time, i1, i2, i3] =
                                        -K_(i1, i2, i3, t, n) * (/*H1*/H[time, i1 + 1, i2, i3] - /*H1*/H[time, i1 - 1, i2, i3]) / (2 * h1)
                                        + /*V_C1*/V_C_(i1, i2, i3, t) * (C[time, i1 + 1, i2, i3] - C[time, i1 - 1, i2, i3]) / (2 * h1)
                                        + /*V_C1*/V_T_(i1, i2, i3, t) * (T[time, i1 + 1, i2, i3] - T[time, i1 - 1, i2, i3]) / (2 * h1);
                                    break;
                                }
                            case 2:
                                {                                    
                                    if (i2 == m2 - 1)
                                        V[time, i1, i2, i3] =
                                         -K_(i1, i2, i3, t, n) * (/*H2*/H[time, i1, i2, i3] - /*H2*/H[time, i1, i2 - 1, i3]) / (h2) +
                                       /*V_C2*/V_C_(i1, i2, i3, t) * (C[time, i1, i2, i3] - C[time, i1, i2 - 1, i3]) / (h2) +
                                       /*V_C2*/V_T_(i1, i2, i3, t) * (T[time, i1, i2, i3] - T[time, i1, i2 - 1, i3]) / (h2);
                                    else
                                        if (i2 == 0)
                                        V[time, i1, i2, i3] =
                                        -K_(i1, i2, i3, t, n) * (/*H2*/H[time, i1, i2 + 1, i3] - /*H2*/H[time, i1, i2, i3]) / (h2) +
                                      /*V_C2*/V_C_(i1, i2, i3, t) * (C[time, i1, i2 + 1, i3] - C[time, i1, i2, i3]) / (h2) +
                                      /*V_C2*/V_T_(i1, i2, i3, t) * (T[time, i1, i2 + 1, i3] - T[time, i1, i2, i3]) / (h2);
                                    else
                                        V[time, i1, i2, i3] =
                                        -K_(i1, i2, i3, t, n) * (/*H2*/H[time, i1, i2 + 1, i3] - /*H2*/H[time, i1, i2 - 1, i3]) / (2 * h2) +
                                      /*V_C2*/V_C_(i1, i2, i3, t) * (C[time, i1, i2 + 1, i3] - C[time, i1, i2 - 1, i3]) / (2 * h2) +
                                      /*V_C2*/V_T_(i1, i2, i3, t) * (T[time, i1, i2 + 1, i3] - T[time, i1, i2 - 1, i3]) / (2 * h2);
                                    break;
                                }
                            case 3:
                                {                                    
                                    if (i3 == m2_ - 1)          ///////////////////
                                        V[time, i1, i2, i3] =
                                        -K_(i1, i2, i3, t, n) * (/*H3*/H[time, i1, i2, i3] - /*H3*/H[time, i1, i2, i3 - 1]) / (h3) +
                                      /*V_C3*/V_C_(i1, i2, i3, t) * (C[time, i1, i2, i3] - C[time, i1, i2, i3 - 1]) / (h3) +
                                      /*V_C3*/V_T_(i1, i2, i3, t) * (T[time, i1, i2, i3] - T[time, i1, i2, i3 - 1]) / (h3);
                                    else
                                    if (i3 == 0)
                                        V[time, i1, i2, i3] =
                                        -K_(i1, i2, i3, t, n) * (/*H3*/H[time, i1, i2, i3 + 1] - /*H3*/H[time, i1, i2, i3]) / (h3) +
                                      /*V_C3*/V_C_(i1, i2, i3, t) * (C[time, i1, i2, i3 + 1] - C[time, i1, i2, i3]) / (h3) +
                                      /*V_C3*/V_T_(i1, i2, i3, t) * (T[time, i1, i2, i3 + 1] - T[time, i1, i2, i3]) / (h3);
                                    else
                                        V[time, i1, i2, i3] =
                                            -K_(i1, i2, i3, t, n) * (/*H3*/H[time, i1, i2, i3 + 1] - /*H3*/H[time, i1, i2, i3 - 1]) / (2 * h3) +
                                          /*V_C3*/V_C_(i1, i2, i3, t) * (C[time, i1, i2, i3 + 1] - C[time, i1, i2, i3 - 1]) / (2 * h3) +
                                          /*V_C3*/V_T_(i1, i2, i3, t) * (T[time, i1, i2, i3 + 1] - T[time, i1, i2, i3 - 1]) / (2 * h3);
                                    break;
                                }
                        }
                    }
                    for (int i3 = 0; i3 < m3_; i3++)     ///////////////
                    {
                        switch (n)
                        {
                            case 1:
                                {
                                    if ( i1 == m1 - 1)
                                        V[time, i1, i2, i3] =
                                         -K_( i1, i2, i3, t, n) * (/*H1*/H[time, i1, i2, i3] - /*H1*/H[time, i1 - 1, i2, i3]) / (h1)
                                         + /*V_C1*/V_C_(i1, i2, i3, t) * (C[time, i1, i2, i3] - C[time, i1 - 1, i2, i3]) / (h1)
                                         + /*V_C1*/V_T_(i1, i2, i3, t) * (T[time, i1, i2, i3] - T[time, i1 - 1, i2, i3]) / (h1);
                                    else
                                        if (i1 == 0)
                                        V[time, i1, i2, i3] =
                                            -K_(i1, i2, i3, t, n) * (/*H1*/H[time, i1 + 1, i2, i3] - /*H1*/H[time, i1, i2, i3]) / (h1)
                                            + /*V_C1*/V_C_(i1, i2, i3, t) * (C[time, i1 + 1, i2, i3] - C[time, i1, i2, i3]) / (h1)
                                            + /*V_C1*/V_T_(i1, i2, i3, t) * (T[time, i1 + 1, i2, i3] - T[time, i1, i2, i3]) / (h1);
                                    else
                                        V[time, i1, i2, i3] =
                                        -K_(i1, i2, i3, t, n) * (/*H1*/H[time, i1 + 1, i2, i3] - /*H1*/H[time, i1 - 1, i2, i3]) / (2 * h1)
                                        + /*V_C1*/V_C_(i1, i2, i3, t) * (C[time, i1 + 1, i2, i3] - C[time, i1 - 1, i2, i3]) / (2 * h1)
                                        + /*V_C1*/V_T_(i1, i2, i3, t) * (T[time, i1 + 1, i2, i3] - T[time, i1 - 1, i2, i3]) / (2 * h1);
                                    break;
                                }
                            case 2:
                                {                                    
                                    if (i2 == m2 - 1)
                                        V[time, i1, i2, i3] =
                                         -K_(i1, i2, i3, t, n) * (/*H2*/H[time, i1, i2, i3] - /*H2*/H[time, i1, i2 - 1, i3]) / (h2) +
                                       /*V_C2*/V_C_(i1, i2, i3, t) * (C[time, i1, i2, i3] - C[time, i1, i2 - 1, i3]) / (h2) +
                                       /*V_C2*/V_T_(i1, i2, i3, t) * (T[time, i1, i2, i3] - T[time, i1, i2 - 1, i3]) / (h2);
                                    else
                                        if (i2 == 0)
                                        V[time, i1, i2, i3] =
                                        -K_(i1, i2, i3, t, n) * (/*H2*/H[time, i1, i2 + 1, i3] - /*H2*/H[time, i1, i2, i3]) / (h2) +
                                      /*V_C2*/V_C_(i1, i2, i3, t) * (C[time, i1, i2 + 1, i3] - C[time, i1, i2, i3]) / (h2) +
                                      /*V_C2*/V_T_(i1, i2, i3, t) * (T[time, i1, i2 + 1, i3] - T[time, i1, i2, i3]) / (h2);
                                    else
                                        V[time, i1, i2, i3] =
                                        -K_(i1, i2, i3, t, n) * (/*H2*/H[time, i1, i2 + 1, i3] - /*H2*/H[time, i1, i2 - 1, i3]) / (2 * h2) +
                                      /*V_C2*/V_C_(i1, i2, i3, t) * (C[time, i1, i2 + 1, i3] - C[time, i1, i2 - 1, i3]) / (2 * h2) +
                                      /*V_C2*/V_T_(i1, i2, i3, t) * (T[time, i1, i2 + 1, i3] - T[time, i1, i2 - 1, i3]) / (2 * h2);
                                    break;
                                }
                            case 3:
                                {                                    
                                    if (i3 == m3_ - 1)          ///////////////////
                                        V[time, i1, i2, i3] =
                                        -K_(i1, i2, i3, t, n) * (/*H3*/H[time, i1, i2, i3] - /*H3*/H[time, i1, i2, i3 - 1]) / (h3) +
                                      /*V_C3*/V_C_(i1, i2, i3, t) * (C[time, i1, i2, i3] - C[time, i1, i2, i3 - 1]) / (h3) +
                                      /*V_C3*/V_T_(i1, i2, i3, t) * (T[time, i1, i2, i3] - T[time, i1, i2, i3 - 1]) / (h3);
                                    else
                                    if (i3 == 0)
                                        V[time, i1, i2, i3] =
                                        -K_(i1, i2, i3, t, n) * (/*H3*/H[time, i1, i2, i3 + 1] - /*H3*/H[time, i1, i2, i3]) / (h3) +
                                      /*V_C3*/V_C_(i1, i2, i3, t) * (C[time, i1, i2, i3 + 1] - C[time, i1, i2, i3]) / (h3) +
                                      /*V_C3*/V_T_(i1, i2, i3, t) * (T[time, i1, i2, i3 + 1] - T[time, i1, i2, i3]) / (h3);
                                    else
                                        V[time, i1, i2, i3] =
                                            -K_(i1, i2, i3, t, n) * (/*H3*/H[time, i1, i2, i3 + 1] - /*H3*/H[time, i1, i2, i3 - 1]) / (2 * h3) +
                                          /*V_C3*/V_C_(i1, i2, i3, t) * (C[time, i1, i2, i3 + 1] - C[time, i1, i2, i3 - 1]) / (2 * h3) +
                                          /*V_C3*/V_T_(i1, i2, i3, t) * (T[time, i1, i2, i3 + 1] - T[time, i1, i2, i3 - 1]) / (2 * h3);
                                    break;
                                }
                        }
                    }
        }

        /// V(j,i1,i2,i3)_plus
        public double V_plus(int i1, int i2, int i3, int t, int n)
        {
            int time = t * 3 + n - 1;

            switch (n)
            {
                case 1:
                    {
                        return (-V[time, i1, i2, i3] + Math.Abs(V[time, i1, i2, i3])) / 3.0;
                    }
                case 2:
                    {
                        return (-V[time, i1, i2, i3] + Math.Abs(V[time, i1, i2, i3])) / 3.0;
                    }
                case 3:
                    {
                        return (-V[time, i1, i2, i3] + Math.Abs(V[time, i1, i2, i3])) / 3.0;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        /// V(j,i1,i2,i3)_minus
        public double V_minus(int i1, int i2, int i3, int t, int n)
        {
            int time = t * 3 + n - 1;
            switch (n)
            {
                case 1:
                    {
                        return (-V[time, i1, i2, i3] - Math.Abs(V[time, i1, i2, i3])) / 3.0;
                    }
                case 2:
                    {
                        return (-V[time, i1, i2, i3] - Math.Abs(V[time, i1, i2, i3])) / 3.0;
                    }
                case 3:
                    {
                        return (-V[time, i1, i2, i3] - Math.Abs(V[time, i1, i2, i3])) / 3.0;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        public void Progonca_T(int t, int n)
        {
            //Znahodimo Alpha ta Beta , a,b,c 

            double[]
                Alpha = new double[m1],
                Beta = new double[m1];

            double Alpha3 = 0, Beta3 = 0;
            double a, b, c;
            int time = t * 3 + n - 1;

            switch (n)
            {
                case 1:
                    {   //Temperatura j -> j + 1/3
                        for (int i2 = 1; i2 < m2; i2++)
                            for (int i3 = 0; i3 < m3; i3++)
                            {
                                Alpha = new double[m1];
                                Beta = new double[m1];
                                Alpha[0] = 0;
                                Beta[0] = T[time, 0, i2, i3];

                                if (i3 <= m2_)
                                {
                                    for (int i = 1; i < m1 - 1; i++)
                                    {
                                        a = (tau / C_t) * (Lamda_(i, i2, i3, t, n) / h1) * (Niu_(i, i2, i3, t, n) / h1 - (ro * C_p * V_minus(i, i2, i3, t, n)) / Lamda_t(i, i2, i3, t, n));
                                        b = (tau / C_t) * (Lamda_(i, i2, i3, t, n) / h1) * (Niu_(i, i2, i3, t, n) / h1 + (ro * C_p * V_plus(i, i2, i3, t, n)) / Lamda_t(i, i2, i3, t, n));
                                        c = 1 + (tau / C_t) * (Niu_(i, i2, i3, t, n) * (Lamda_(i + 1, i2, i3, t, n) + Lamda_(i, i2, i3, t, n)) / (h1 * h1)
                                        + ((ro * C_p) / Lamda_t(i, i2, i3, t, n)) * (Lamda_(i + 1, i2, i3, t, n) * V_plus(i, i2, i3, t, n) - Lamda_(i, i2, i3, t, n) * V_minus(i, i2, i3, t, n)));
                                    
                                        Alpha[i] = b / (c - a * Alpha[i - 1]);
                                        Beta[i] = (a * Beta[i - 1] + T[time, i, i2, i3]) / (c - a * Alpha[i - 1]);
                                    }
                                }
                                /*
                                if (i3 == m2_)
                                {
                                    for (int i = 1; i < m1 - 1; i++)
                                    {
                                        Alpha[i] = Lamda_t_(i, i2, i3, t, n) / (Lamda_t_(i, i2, i3, t, n) + (Lamda_t(i, i2, i3, t, n) - ro * C_p * V[time, i, i2, i3]) * (1 - Alpha[i - 1]));
                                        Beta[i] = (Lamda_t(i, i2, i3, t, n) * Beta[i - 1]) / (Lamda_t_(i, i2, i3, t, n) + (Lamda_t(i, i2, i3, t, n) - ro * C_p * V[time, i, i2, i3]) * (1 - Alpha[i - 1]));
                                    }
                                }*/
                                if (i3 <= m3_)
                                {
                                    for (int i = 1; i < m1 - 1; i++)
                                    {
                                        a = (tau / C_t) * (Lamda_(i, i2, i3, t, n) / h1) * (Niu_(i, i2, i3, t, n) / h1 - (ro * C_p * V_minus(i, i2, i3, t, n)) / Lamda_t(i, i2, i3, t, n));
                                        b = (tau / C_t) * (Lamda_(i, i2, i3, t, n) / h1) * (Niu_(i, i2, i3, t, n) / h1 + (ro * C_p * V_plus(i, i2, i3, t, n)) / Lamda_t(i, i2, i3, t, n));
                                        c = 1 + (tau / C_t) * (Niu_(i, i2, i3, t, n) * (Lamda_(i + 1, i2, i3, t, n) + Lamda_(i, i2, i3, t, n)) / (h1 * h1)
                                        + ((ro * C_p) / Lamda_t(i, i2, i3, t, n)) * (Lamda_(i + 1, i2, i3, t, n) * V_plus(i, i2, i3, t, n) - Lamda_(i, i2, i3, t, n) * V_minus(i, i2, i3, t, n)));

                                        Alpha[i] = b / (c - a * Alpha[i - 1]);
                                        Beta[i] = (a * Beta[i - 1] + T[time, i, i2, i3]) / (c - a * Alpha[i - 1]);
                                    }
                                }
                                /*
                                if (i3 == m3_)
                                {
                                    for (int i = 1; i < m1 - 1; i++)
                                    {
                                        Alpha[i] = Lamda_t_(i, i2, i3, t, n) / (Lamda_t_(i, i2, i3, t, n) + (Lamda_t(i, i2, i3, t, n) - ro * C_p * V[time, i, i2, i3]) * (1 - Alpha[i - 1]));
                                        Beta[i] = (Lamda_t(i, i2, i3, t, n) * Beta[i - 1]) / (Lamda_t_(i, i2, i3, t, n) + (Lamda_t(i, i2, i3, t, n) - ro * C_p * V[time, i, i2, i3]) * (1 - Alpha[i - 1]));
                                    }
                                }*/

                                if (i3 > m2_)
                                {
                                    for (int i = 1; i < m1 - 1; i++)
                                    {
                                        a = (tau / C_t) * (Lamda__(i, i2, i3, t, n) / h1) * (Niu_(i, i2, i3, t, n) / h1 - (ro * C_p * V_minus(i, i2, i3, t, n)) / Lamda_t_(i, i2, i3, t, n));
                                        b = (tau / C_t) * (Lamda__(i, i2, i3, t, n) / h1) * (Niu_(i, i2, i3, t, n) / h1 + (ro * C_p * V_plus(i, i2, i3, t, n)) / Lamda_t_(i, i2, i3, t, n));
                                        c = 1 + (tau / C_t) * (Niu_(i, i2, i3, t, n) * (Lamda__(i + 1, i2, i3, t, n) + Lamda__(i, i2, i3, t, n)) / (h1 * h1)
                                        + ((ro * C_p) / Lamda_t_(i, i2, i3, t, n)) * (Lamda__(i + 1, i2, i3, t, n) * V_plus(i, i2, i3, t, n) - Lamda__(i, i2, i3, t, n) * V_minus(i, i2, i3, t, n)));

                                        Alpha[i] = b / (c - a * Alpha[i - 1]);
                                        Beta[i] = (a * Beta[i - 1] + T[time, i, i2, i3]) / (c - a * Alpha[i - 1]);
                                    }
                                }

                                if (i3 > m3_)
                                {
                                    for (int i = 1; i < m1 - 1; i++)
                                    {
                                        a = (tau / C_t) * (Lamda__(i, i2, i3, t, n) / h1) * (Niu_(i, i2, i3, t, n) / h1 - (ro * C_p * V_minus(i, i2, i3, t, n)) / Lamda_t_(i, i2, i3, t, n));
                                        b = (tau / C_t) * (Lamda__(i, i2, i3, t, n) / h1) * (Niu_(i, i2, i3, t, n) / h1 + (ro * C_p * V_plus(i, i2, i3, t, n)) / Lamda_t_(i, i2, i3, t, n));
                                        c = 1 + (tau / C_t) * (Niu_(i, i2, i3, t, n) * (Lamda__(i + 1, i2, i3, t, n) + Lamda__(i, i2, i3, t, n)) / (h1 * h1)
                                        + ((ro * C_p) / Lamda_t_(i, i2, i3, t, n)) * (Lamda__(i + 1, i2, i3, t, n) * V_plus(i, i2, i3, t, n) - Lamda__(i, i2, i3, t, n) * V_minus(i, i2, i3, t, n)));

                                        Alpha[i] = b / (c - a * Alpha[i - 1]);
                                        Beta[i] = (a * Beta[i - 1] + T[time, i, i2, i3]) / (c - a * Alpha[i - 1]);
                                    }
                                }

                                // zvorotnia
                                for (int i = m1 - 2; i >= 1; i--)
                                    T[time + 1, i, i2, i3] = Alpha[i] * T[time + 1, i + 1, i2, i3] + Beta[i];
                            }
                        break;
                    }

                case 2:
                    {
                        //Temperatura j + 1/3 -> j + 2/3

                        for (int i1 = 1; i1 < m1; i1++)
                            for (int i3 = 0; i3 < m3; i3++)
                            {
                                Alpha = new double[m2];
                                Beta = new double[m2];
                                Alpha[0] = 0;
                                Beta[0] = T[time, i1, 0, i3];

                                if (i3 <= m2_)
                                {
                                    for (int i = 1; i < m2 - 1; i++)
                                    {
                                        a = (tau / C_t) * (Lamda_(i1, i, i3, t, n) / h2) * (Niu_(i1, i, i3, t, n) / h2 - (ro * C_p * V_minus(i1, i, i3, t, n)) / Lamda_t(i1, i, i3, t, n));
                                        b = (tau / C_t) * (Lamda_(i1, i, i3, t, n) / h2) * (Niu_(i1, i, i3, t, n) / h2 + (ro * C_p * V_plus(i1, i, i3, t, n)) / Lamda_t(i1, i, i3, t, n));
                                        c = 1 + (tau / C_t) * (Niu_(i1, i, i3, t, n) * (Lamda_(i1, i + 1, i3, t, n) + Lamda_(i1, i, i3, t, n)) / (h2 * h2)
                                        + ((ro * C_p) / Lamda_t(i1, i, i3, t, n)) * (Lamda_(i1, i + 1, i3, t, n) * V_plus(i1, i, i3, t, n) - Lamda_(i1, i, i3, t, n) * V_minus(i1, i, i3, t, n)));

                                        Alpha[i] = b / (c - a * Alpha[i - 1]);
                                        Beta[i] = (a * Beta[i - 1] + T[time, i1, i, i3]) / (c - a * Alpha[i - 1]);
                                    }
                                }
                                /*
                                if (i3 == m2_)
                                {
                                    for (int i = 1; i < m2 - 1; i++)
                                    {
                                        Alpha[i] = Lamda_t_(i1, i, i3, t, n) / (Lamda_t_(i1, i, i3, t, n) + (Lamda_t(i1, i, i3, t, n) - ro * C_p * V[time, i1, i, i3]) * (1 - Alpha[i - 1]));
                                        Beta[i] = (Lamda_t(i1, i, i3, t, n) * Beta[i - 1]) / (Lamda_t_(i1, i, i3, t, n) + (Lamda_t(i1, i, i3, t, n) - ro * C_p * V[time, i1, i, i3]) * (1 - Alpha[i - 1]));
                                    }
                                }
                                */
                                if (i3 <= m2_)
                                {
                                    for (int i = 1; i < m2 - 1; i++)
                                    {
                                        a = (tau / C_t) * (Lamda_(i1, i, i3, t, n) / h2) * (Niu_(i1, i, i3, t, n) / h2 - (ro * C_p * V_minus(i1, i, i3, t, n)) / Lamda_t(i1, i, i3, t, n));
                                        b = (tau / C_t) * (Lamda_(i1, i, i3, t, n) / h2) * (Niu_(i1, i, i3, t, n) / h2 + (ro * C_p * V_plus(i1, i, i3, t, n)) / Lamda_t(i1, i, i3, t, n));
                                        c = 1 + (tau / C_t) * (Niu_(i1, i, i3, t, n) * (Lamda_(i1, i + 1, i3, t, n) + Lamda_(i1, i, i3, t, n)) / (h2 * h2)
                                        + ((ro * C_p) / Lamda_t(i1, i, i3, t, n)) * (Lamda_(i1, i + 1, i3, t, n) * V_plus(i1, i, i3, t, n) - Lamda_(i1, i, i3, t, n) * V_minus(i1, i, i3, t, n)));

                                        Alpha[i] = b / (c - a * Alpha[i - 1]);
                                        Beta[i] = (a * Beta[i - 1] + T[time, i1, i, i3]) / (c - a * Alpha[i - 1]);
                                    }
                                }
                                /*
                                if (i3 == m2_)
                                {
                                    for (int i = 1; i < m2 - 1; i++)
                                    {
                                        Alpha[i] = Lamda_t_(i1, i, i3, t, n) / (Lamda_t_(i1, i, i3, t, n) + (Lamda_t(i1, i, i3, t, n) - ro * C_p * V[time, i1, i, i3]) * (1 - Alpha[i - 1]));
                                        Beta[i] = (Lamda_t(i1, i, i3, t, n) * Beta[i - 1]) / (Lamda_t_(i1, i, i3, t, n) + (Lamda_t(i1, i, i3, t, n) - ro * C_p * V[time, i1, i, i3]) * (1 - Alpha[i - 1]));
                                    }
                                }
                                */

                                if (i3 <= m3_)
                                {
                                    for (int i = 1; i < m2 - 1; i++)
                                    {
                                        a = (tau / C_t) * (Lamda_(i1, i, i3, t, n) / h2) * (Niu_(i1, i, i3, t, n) / h2 - (ro * C_p * V_minus(i1, i, i3, t, n)) / Lamda_t(i1, i, i3, t, n));
                                        b = (tau / C_t) * (Lamda_(i1, i, i3, t, n) / h2) * (Niu_(i1, i, i3, t, n) / h2 + (ro * C_p * V_plus(i1, i, i3, t, n)) / Lamda_t(i1, i, i3, t, n));
                                        c = 1 + (tau / C_t) * (Niu_(i1, i, i3, t, n) * (Lamda_(i1, i + 1, i3, t, n) + Lamda_(i1, i, i3, t, n)) / (h2 * h2)
                                        + ((ro * C_p) / Lamda_t(i1, i, i3, t, n)) * (Lamda_(i1, i + 1, i3, t, n) * V_plus(i1, i, i3, t, n) - Lamda_(i1, i, i3, t, n) * V_minus(i1, i, i3, t, n)));

                                        Alpha[i] = b / (c - a * Alpha[i - 1]);
                                        Beta[i] = (a * Beta[i - 1] + T[time, i1, i, i3]) / (c - a * Alpha[i - 1]);
                                    }
                                }
                                /*
                                if (i3 == m3_)
                                {
                                    for (int i = 1; i < m2 - 1; i++)
                                    {
                                        Alpha[i] = Lamda_t_(i1, i, i3, t, n) / (Lamda_t_(i1, i, i3, t, n) + (Lamda_t(i1, i, i3, t, n) - ro * C_p * V[time, i1, i, i3]) * (1 - Alpha[i - 1]));
                                        Beta[i] = (Lamda_t(i1, i, i3, t, n) * Beta[i - 1]) / (Lamda_t_(i1, i, i3, t, n) + (Lamda_t(i1, i, i3, t, n) - ro * C_p * V[time, i1, i, i3]) * (1 - Alpha[i - 1]));
                                    }
                                }
                                */

                                if (i3 > m2_)
                                {
                                    for (int i = 1; i < m2 - 1; i++)
                                    {
                                        a = (tau / C_t) * (Lamda__(i1, i, i3, t, n) / h2) * (Niu_(i1, i, i3, t, n) / h2 - (ro * C_p * V_minus(i1, i, i3, t, n)) / Lamda_t_(i1, i, i3, t, n));
                                        b = (tau / C_t) * (Lamda__(i1, i, i3, t, n) / h2) * (Niu_(i1, i, i3, t, n) / h2 + (ro * C_p * V_plus(i1, i, i3, t, n)) / Lamda_t_(i1, i, i3, t, n));
                                        c = 1 + (tau / C_t) * (Niu_(i1, i, i3, t, n) * (Lamda__(i1, i + 1, i3, t, n) + Lamda__(i1, i, i3, t, n)) / (h2 * h2)
                                        + ((ro * C_p) / Lamda_t_(i1, i, i3, t, n)) * (Lamda__(i1, i + 1, i3, t, n) * V_plus(i1, i, i3, t, n) - Lamda__(i1, i, i3, t, n) * V_minus(i1, i, i3, t, n)));

                                        Alpha[i] = b / (c - a * Alpha[i - 1]);
                                        Beta[i] = (a * Beta[i - 1] + T[time, i1, i, i3]) / (c - a * Alpha[i - 1]);
                                    }
                                }

                                if (i3 > m3_)
                                {
                                    for (int i = 1; i < m2 - 1; i++)
                                    {
                                        a = (tau / C_t) * (Lamda__(i1, i, i3, t, n) / h2) * (Niu_(i1, i, i3, t, n) / h2 - (ro * C_p * V_minus(i1, i, i3, t, n)) / Lamda_t_(i1, i, i3, t, n));
                                        b = (tau / C_t) * (Lamda__(i1, i, i3, t, n) / h2) * (Niu_(i1, i, i3, t, n) / h2 + (ro * C_p * V_plus(i1, i, i3, t, n)) / Lamda_t_(i1, i, i3, t, n));
                                        c = 1 + (tau / C_t) * (Niu_(i1, i, i3, t, n) * (Lamda__(i1, i + 1, i3, t, n) + Lamda__(i1, i, i3, t, n)) / (h2 * h2)
                                        + ((ro * C_p) / Lamda_t_(i1, i, i3, t, n)) * (Lamda__(i1, i + 1, i3, t, n) * V_plus(i1, i, i3, t, n) - Lamda__(i1, i, i3, t, n) * V_minus(i1, i, i3, t, n)));

                                        Alpha[i] = b / (c - a * Alpha[i - 1]);
                                        Beta[i] = (a * Beta[i - 1] + T[time, i1, i, i3]) / (c - a * Alpha[i - 1]);
                                    }
                                }

                                // zvorotnia
                                for (int i = m2 - 2; i > 0; i--)
                                    T[time + 1, i1, i, i3] = Alpha[i] * T[time + 1, i1, i + 1, i3] + Beta[i];
                            }
                        break;
                    }

                case 3:
                    {
                        //Temperatura j + 2/3 -> j + 1
                        for (int i1 = 1; i1 < m1; i1++)
                            for (int i2 = 1; i2 < m2; i2++)
                            {
                                int m2_ = m3 - 1;

                                Alpha = new double[m3];
                                Beta = new double[m3];

                                Alpha3 = (tau * (Lamda_t(i1, i2, 0, t, n) - 0.5 * h3 * ro * C_p * V_plus(i1, i2, 0, t, n)))
                                    / (tau * (Lamda_t(i1, i2, 0, t, n) - 0.5 * h3 * ro * C_p * V_plus(i1, i2, 0, t, n)) + 0.5 * (h3 * h3) * C_t);
                                Beta3 = (0.5 * (h3 * h3) * C_t * T[time, i1, i2, 0])
                                    / (tau * (Lamda_t(i1, i2, 0, t, n) - 0.5 * h3 * ro * C_p * V_plus(i1, i2, 0, t, n)) + 0.5 * (h3 * h3) * C_t);

                                Alpha[0] = Alpha3;
                                Beta[0] = Beta3;

                                double niu3 = (tau * (Lamda_t(i1, i2, m2_, t, n) - 0.5 * h3 * ro * C_p * V_minus(i1, i2, m2_, t, n)))
                                    / (tau * (Lamda_t(i1, i2, m2_, t, n) - 0.5 * h3 * ro * C_p * V_minus(i1, i2, m2_, t, n)) + 0.5 * (h3 * h3) * C_t);
                                double miu3 = (0.5 * (h3 * h3) * C_t * T[time, i1, i2, m2_])
                                    / (tau * (Lamda_t(i1, i2, m2_, t, n) - 0.5 * h3 * ro * C_p * V_minus(i1, i2, m2_, t, n)) + 0.5 * (h3 * h3) * C_t);

                                double T_m3_3 = (niu3 * Beta3 + miu3) / (1 - niu3 * Alpha3);

                                for (int n1 = 0; n1 <= 3; n1++)
                                {
                                    T[time + 1 + n1, i1, i2, m3_] = T_m3_3;
                                }

                                for (int i = 1; i < m3 - 1; i++)
                                {
                                    if (i < m2_)
                                    { 
                                        a = (tau / C_t) * (Lamda_(i1, i2, i, t, n) / h3) * (Niu_(i1, i2, i, t, n) / h3 - (ro * C_p * V_minus(i1, i2, i, t, n)) / Lamda_t(i1, i2, i, t, n));
                                        b = (tau / C_t) * (Lamda_(i1, i2, i, t, n) / h3) * (Niu_(i1, i2, i, t, n) / h3 + (ro * C_p * V_plus(i1, i2, i, t, n)) / Lamda_t(i1, i2, i, t, n));
                                        c = 1 + (tau / C_t) * (Niu_(i1, i2, i, t, n) * (Lamda_(i1, i2, i + 1, t, n) + Lamda_(i1, i2, i, t, n)) / (h3 * h3)
                                        + ((ro * C_p) / Lamda_t(i1, i2, i, t, n)) * (Lamda_(i1, i2, i + 1, t, n) * V_plus(i1, i2, i, t, n) - Lamda_(i1, i2, i, t, n) * V_minus(i1, i2, i, t, n)));

                                        Alpha[i] = b / (c - a * Alpha[i - 1]);
                                        Beta[i] = (a * Beta[i - 1] + T[time, i1, i2, i]) / (c - a * Alpha[i - 1]);
                                    }

                                    if (i == m2_)
                                    {
                                        Alpha[i] = Lamda_t_(i1, i2, i, t, n) / (Lamda_t_(i1, i2, i, t, n) + (Lamda_t(i1, i2, i, t, n) - ro * C_p * V[time, i1, i2, i]) * (1 - Alpha[i - 1]));
                                        Beta[i] = (Lamda_t(i1, i2, i, t, n) * Beta[i - 1]) / (Lamda_t_(i1, i2, i, t, n) + (Lamda_t(i1, i2, i, t, n) - ro * C_p * V[time, i1, i2, i]) * (1 - Alpha[i - 1]));
                                    }

                                    if (i > m2_)
                                    {
                                        a = (tau / C_t) * (Lamda__(i1, i2, i, t, n) / h3) * (Niu_(i1, i2, i, t, n) / h3 - (ro * C_p * V_minus(i1, i2, i, t, n)) / Lamda_t_(i1, i2, i, t, n));
                                        b = (tau / C_t) * (Lamda__(i1, i2, i, t, n) / h3) * (Niu_(i1, i2, i, t, n) / h3 + (ro * C_p * V_plus(i1, i2, i, t, n)) / Lamda_t_(i1, i2, i, t, n));
                                        c = 1 + (tau / C_t) * (Niu_(i1, i2, i, t, n) * (Lamda__(i1, i2, i + 1, t, n) + Lamda__(i1, i2, i, t, n)) / (h3 * h3)
                                        + ((ro * C_p) / Lamda_t_(i1, i2, i, t, n)) * (Lamda__(i1, i2, i + 1, t, n) * V_plus(i1, i2, i, t, n) - Lamda__(i1, i2, i, t, n) * V_minus(i1, i2, i, t, n)));

                                        Alpha[i] = b / (c - a * Alpha[i - 1]);
                                        Beta[i] = (a * Beta[i - 1] + T[time, i1, i2, i]) / (c - a * Alpha[i - 1]);
                                    }

                                }

                                // zvorotnia

                                for (int i = m3 - 2; i >= 0; i--)
                                    T[time + 1, i1, i2, i] = Alpha[i] * T[time + 1, i1, i2, i + 1] + Beta[i];

                                /*double T_0_3 = Alpha3 * T[time + 1, i1, i2, 1] + Beta3;

                                for (int n1 = 0; n1 <= 3; n1++)
                                {
                                    T[time + 1 + n1, i1, i2, 0] = T_0_3;
                                }
                                */
                            }

                        for (int i2 = 1; i2 < m2; i2++)
                        {
                            int m3_ = m3 - 1;

                            Alpha = new double[m3];
                            Beta = new double[m3];

                            Alpha3 = (tau * (Lamda_t( i1, i2, 0, t, n) - 0.5 * h3 * ro * C_p * V_plus( i1, i2, 0, t, n)))
                                / (tau * (Lamda_t(i1, i2, 0, t, n) - 0.5 * h3 * ro * C_p * V_plus(i1, i2, 0, t, n)) + 0.5 * (h3 * h3) * C_t);
                            Beta3 = (0.5 * (h3 * h3) * C_t * T[time, i1, i2, 0])
                                / (tau * (Lamda_t(i1, i2, 0, t, n) - 0.5 * h3 * ro * C_p * V_plus(i1, i2, 0, t, n)) + 0.5 * (h3 * h3) * C_t);

                            Alpha[0] = Alpha3;
                            Beta[0] = Beta3;

                            double niu3 = (tau * (Lamda_t(i1, i2, m3_, t, n) - 0.5 * h3 * ro * C_p * V_minus(i1, i2, m3_, t, n)))
                                / (tau * (Lamda_t(i1, i2, m3_, t, n) - 0.5 * h3 * ro * C_p * V_minus(i1, i2, m3_, t, n)) + 0.5 * (h3 * h3) * C_t);
                            double miu3 = (0.5 * (h3 * h3) * C_t * T[time, i1, i2, m3_])
                                / (tau * (Lamda_t(i1, i2, m3_, t, n) - 0.5 * h3 * ro * C_p * V_minus(i1, i2, m3_, t, n)) + 0.5 * (h3 * h3) * C_t);

                            double T_m3_3 = (niu3 * Beta3 + miu3) / (1 - niu3 * Alpha3);

                            for (int n1 = 0; n1 <= 3; n1++)
                            {
                                T[time + 1 + n1, i1, i2, m3_] = T_m3_3;
                            }

                            for (int i = 1; i < m3 - 1; i++)
                            {
                                if (i < m3_)
                                {
                                    a = (tau / C_t) * (Lamda_(i1, i2, i, t, n) / h3) * (Niu_(i1, i2, i, t, n) / h3 - (ro * C_p * V_minus(i1, i2, i, t, n)) / Lamda_t(i1, i2, i, t, n));
                                    b = (tau / C_t) * (Lamda_(i1, i2, i, t, n) / h3) * (Niu_(i1, i2, i, t, n) / h3 + (ro * C_p * V_plus(i1, i2, i, t, n)) / Lamda_t(i1, i2, i, t, n));
                                    c = 1 + (tau / C_t) * (Niu_(i1, i2, i, t, n) * (Lamda_(i1, i2, i + 1, t, n) + Lamda_(i1, i2, i, t, n)) / (h3 * h3)
                                    + ((ro * C_p) / Lamda_t(i1, i2, i, t, n)) * (Lamda_(i1, i2, i + 1, t, n) * V_plus(i1, i2, i, t, n) - Lamda_(i1, i2, i, t, n) * V_minus(i1, i2, i, t, n)));

                                    Alpha[i] = b / (c - a * Alpha[i - 1]);
                                    Beta[i] = (a * Beta[i - 1] + T[time, i1, i2, i]) / (c - a * Alpha[i - 1]);
                                }

                                if (i == m3_)
                                {
                                    Alpha[i] = Lamda_t_(i1, i2, i, t, n) / (Lamda_t_(i1, i2, i, t, n) + (Lamda_t(i1, i2, i, t, n) - ro * C_p * V[time, i1, i2, i]) * (1 - Alpha[i - 1]));
                                    Beta[i] = (Lamda_t(i1, i2, i, t, n) * Beta[i - 1]) / (Lamda_t_(i1, i2, i, t, n) + (Lamda_t(i1, i2, i, t, n) - ro * C_p * V[time, i1, i2, i]) * (1 - Alpha[i - 1]));
                                }

                                if (i > m3_)
                                {
                                    a = (tau / C_t) * (Lamda__(i1, i2, i, t, n) / h3) * (Niu_(i1, i2, i, t, n) / h3 - (ro * C_p * V_minus(i1, i2, i, t, n)) / Lamda_t_(i1, i2, i, t, n));
                                    b = (tau / C_t) * (Lamda__(i1, i2, i, t, n) / h3) * (Niu_(i1, i2, i, t, n) / h3 + (ro * C_p * V_plus(i1, i2, i, t, n)) / Lamda_t_(i1, i2, i, t, n));
                                    c = 1 + (tau / C_t) * (Niu_(i1, i2, i, t, n) * (Lamda__(i1, i2, i + 1, t, n) + Lamda__(i1, i2, i, t, n)) / (h3 * h3)
                                    + ((ro * C_p) / Lamda_t_(i1, i2, i, t, n)) * (Lamda__(i1, i2, i + 1, t, n) * V_plus(i1, i2, i, t, n) - Lamda__(i1, i2, i, t, n) * V_minus(i1, i2, i, t, n)));

                                    Alpha[i] = b / (c - a * Alpha[i - 1]);
                                    Beta[i] = (a * Beta[i - 1] + T[time, i1, i2, i]) / (c - a * Alpha[i - 1]);
                                }

                            }

                            // zvorotnia

                            for (int i = m3 - 2; i >= 0; i--)
                                T[time + 1, i1, i2, i] = Alpha[i] * T[time + 1, i1, i2, i + 1] + Beta[i];

                            /*double T_0_3 = Alpha3 * T[time + 1, i1, i2, 1] + Beta3;

                            for (int n1 = 0; n1 <= 3; n1++)
                            {
                                T[time + 1 + n1, i1, i2, 0] = T_0_3;
                            }
                            */
                        }
                        break;
                    }
            }

        }

        /////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////
        //Концентрація С Прогонка
        /////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////

        public void Progonca_C(int t, int n)
        {
            //Znahodimo Alpha ta Beta , a,b,c 
            double[]
                Alpha = new double[m1],
                Beta = new double[m1];
            double Alpha3 = 0, Beta3 = 0;
            double a, b, c, s;
            int time = t * 3 + n - 1;

            switch (n)
            {
                case 1:
                    {
                        for (int i2 = 1; i2 <= m2 - 1; i2++) ///////////////////////////
                            for (int i3 = 0; i3 <= m2_ - 1; i3++)
                            {
                                int m1_ = m1 - 1;

                                Alpha = new double[m1];
                                Beta = new double[m1];

                                Alpha[0] = 0;
                                Beta[0] = C[time, 0, i2, i3];

                                double niu1 = (tau * (d_i(m1_, i2, i3, t, n) - 0.5 * h3 * V_minus(m1_, i2, i3, t, n)))
                                    / (tau * (d_i(m1_, i2, i3, t, n) - 0.5 * h3 * V_minus(m1_, i2, i3, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0));
                                double miu1 = (0.5 * (h3 * h3) * (n_p * C[time, m1_, i2, i3] + tau * gamma * C_m / 3.0) - h3 * tau * d_i_t(m1_, i2, i3, t, n) * ((T[time + 1, m1_, i2, i3] - T[time + 1, m1_ - 1, i2, i3]) / h1))
                                    / (tau * (d_i(m1_, i2, i3, t, n) - 0.5 * h3 * V_minus(m1_, i2, i3, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0));

                                double C_m1_1 = niu1 * C[t * 3, m1 - 2, i2, i3] + miu1;

                                for (int n1 = 0; n1 <= 3; n1++)
                                {
                                    C[time + 1 + n1, m1 - 1, i2, i3] = C_m1_1;
                                }

                                for (int i = 1; i < m1 - 1; i++)
                                {
                                    a = (tau / n_p) * (d_i(i, i2, i3, t, n) / h1) * ((Niu_C(i, i2, i3, t, n) / h1) - (V_minus(i, i2, i3, t, n) / D_(i, i2, i3, t, n)));
                                    b = (tau / n_p) * (d_i(i + 1, i2, i3, t, n) / h1) * ((Niu_C(i, i2, i3, t, n) / h1) + (V_plus(i, i2, i3, t, n) / D_(i, i2, i3, t, n)));
                                    c = 1.0 + (tau / n_p) * ((Niu_C(i, i2, i3, t, n)
                                        * (d_i(i + 1, i2, i3, t, n) + d_i(i, i2, i3, t, n)) / (h1 * h1))
                                        + (1.0 / (h1 * D_(i, i2, i3, t, n))) * (d_i(i + 1, i2, i3, t, n) * V_plus(i, i2, i3, t, n) - d_i(i, i2, i3, t, n) * V_minus(i, i2, i3, t, n)) + gamma / 3.0);
                                    s = (tau / n_p) * ((gamma / 3.0) * C_m + (d_i_t(i + 1, i2, i3, t, n)
                                        * (T[time + 1, i + 1, i2, i3] - T[time + 1, i, i2, i3]) / h1
                                        - d_i_t(i + 1, i2, i3, t, n) * (T[time + 1, i, i2, i3]
                                        - T[time + 1, i - 1, i2, i3]) / h1) / (h1));

                                    Alpha[i] = b / (c - a * Alpha[i - 1]);
                                    Beta[i] = (a * Beta[i - 1] + C[time, i, i2, i3] + s) / (c - a * Alpha[i - 1]);
                                }

                                //zvorotnia
                                for (int i = m1 - 2; i > 0;
                                    C[time + 1, i, i2, i3] = Alpha[i] * C[time + 1, i + 1, i2, i3] + Beta[i],
                                    i--) ;
                            }

                        for (int i3 = 0; i3 <= m3_ - 1; i3++)
                        {
                            int m1_ = m1 - 1;

                            Alpha = new double[m1];
                            Beta = new double[m1];

                            Alpha[0] = 0;
                            Beta[0] = C[time, 0, i2, i3];

                            double niu1 = (tau * (d_i(m1_, i2, i3, t, n) - 0.5 * h3 * V_minus(m1_, i2, i3, t, n)))
                                / (tau * (d_i(m1_, i2, i3, t, n) - 0.5 * h3 * V_minus(m1_, i2, i3, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0));
                            double miu1 = (0.5 * (h3 * h3) * (n_p * C[time, m1_, i2, i3] + tau * gamma * C_m / 3.0) - h3 * tau * d_i_t(m1_, i2, i3, t, n) * ((T[time + 1, m1_, i2, i3] - T[time + 1, m1_ - 1, i2, i3]) / h1))
                                / (tau * (d_i(m1_, i2, i3, t, n) - 0.5 * h3 * V_minus(m1_, i2, i3, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0));

                            double C_m1_1 = niu1 * C[t * 3, m1 - 2, i2, i3] + miu1;

                            for (int n1 = 0; n1 <= 3; n1++)
                            {
                                C[time + 1 + n1, m1 - 1, i2, i3] = C_m1_1;
                            }

                            for (int i = 1; i < m1 - 1; i++)
                            {
                                a = (tau / n_p) * (d_i(i, i2, i3, t, n) / h1) * ((Niu_C(i, i2, i3, t, n) / h1) - (V_minus(i, i2, i3, t, n) / D_(i, i2, i3, t, n)));
                                b = (tau / n_p) * (d_i(i + 1, i2, i3, t, n) / h1) * ((Niu_C(i, i2, i3, t, n) / h1) + (V_plus(i, i2, i3, t, n) / D_(i, i2, i3, t, n)));
                                c = 1.0 + (tau / n_p) * ((Niu_C(i, i2, i3, t, n)
                                    * (d_i(i + 1, i2, i3, t, n) + d_i(i, i2, i3, t, n)) / (h1 * h1))
                                    + (1.0 / (h1 * D_(i, i2, i3, t, n))) * (d_i(i + 1, i2, i3, t, n) * V_plus(i, i2, i3, t, n) - d_i(i, i2, i3, t, n) * V_minus(i, i2, i3, t, n)) + gamma / 3.0);
                                s = (tau / n_p) * ((gamma / 3.0) * C_m + (d_i_t(i + 1, i2, i3, t, n)
                                    * (T[time + 1, i + 1, i2, i3] - T[time + 1, i, i2, i3]) / h1
                                    - d_i_t(i + 1, i2, i3, t, n) * (T[time + 1, i, i2, i3]
                                    - T[time + 1, i - 1, i2, i3]) / h1) / (h1));

                                Alpha[i] = b / (c - a * Alpha[i - 1]);
                                Beta[i] = (a * Beta[i - 1] + C[time, i, i2, i3] + s) / (c - a * Alpha[i - 1]);
                            }

                            //zvorotnia
                            for (int i = m1 - 2; i > 0;
                                C[time + 1, i, i2, i3] = Alpha[i] * C[time + 1, i + 1, i2, i3] + Beta[i],
                                i--) ;
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i1 = 1; i1 <= m1 - 1; i1++)   //////////////////////
                            for (int i3 = 0; i3 <= m3_ - 1; i3++)
                            {
                                Alpha = new double[m2];
                                Beta = new double[m2];
                                Alpha[0] = 0;
                                Beta[0] = C[time, i1, 0, i3];

                                int m2_ = m2 - 1;

                                double niu2 = ((tau * (d_i(i1, m2_, i3, t, n) - 0.5 * h3 * V_minus(i1, m2_, i3, t, n)))
                                    / (tau * (d_i(i1, m2_, i3, t, n) - 0.5 * h3 * V_minus(i1, m2_, i3, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0)));
                                double miu2 = ((0.5 * (h3 * h3) * (n_p * C[time, i1, m2_, i3] + tau * gamma * C_m / 3.0) - h3 * tau * d_i_t(i1, m2_, i3, t, n) * (T[time + 1, i1, m2_, i3] - T[time + 1, i1, m2_ - 1, i3]) / h2)
                                    / (tau * (d_i(i1, m2_, i3, t, n) - 0.5 * h3 * V_minus(i1, m2_, i3, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0)));

                                double C_m2_2 = niu2 * C[t * 3, i1, m3 - 2, i3] + miu2;

                                for (int n1 = 0; n1 <= 3; n1++)
                                {
                                    C[time + 1 + n1, i1, m2 - 1, i3] = C_m2_2;
                                }

                                for (int i = 1; i < m2 - 1; i++)
                                {
                                    a = (tau / n_p) * (d_i(i1, i, i3, t, n) / h2) * (Niu_C(i1, i, i3, t, n) / h2 - V_minus(i1, i, i3, t, n) / D_(i1, i, i3, t, n));
                                    b = (tau / n_p) * (d_i(i1, i + 1, i3, t, n) / h2) * (Niu_C(i1, i, i3, t, n) / h2 + V_plus(i1, i, i3, t, n) / D_(i1, i, i3, t, n));
                                    c = 1 + (tau / n_p) * (Niu_C(i1, i, i3, t, n) * (d_i(i1, i + 1, i3, t, n) + d_i(i1, i, i3, t, n)) / (h2 * h2)
                                        + (d_i(i1, i + 1, i3, t, n) * V_plus(i1, i, i3, t, n) - d_i(i1, i, i3, t, n) * V_minus(i1, i, i3, t, n)) / (h2 * D_(i1, i, i3, t, n)) + gamma / 3.0);
                                    s = (tau / n_p) * ((gamma / 3.0) * C_m + (d_i_t(i1, i + 1, i3, t, n)
                                        * (T[time + 1, i1, i + 1, i3] - T[time + 1, i1, i, i3])
                                        - d_i_t(i1, i + 1, i3, t, n) * (T[time + 1, i1, i, i3]
                                        - T[time + 1, i1, i - 1, i3])) / (h2 * h2));
                                    Alpha[i] = b / (c - a * Alpha[i - 1]);
                                    Beta[i] = (a * Beta[i - 1] + C[time, i1, i, i3] + s) / (c - a * Alpha[i - 1]);
                                }

                                //zvorotnia

                                for (int i = m2 - 2; i > 0;
                                    C[time + 1, i1, i, i3] = Alpha[i] * C[time + 1, i1, i + 1, i3] + Beta[i],
                                    i--) ;


                            }

                        for (int i3 = 0; i3 <= m2_ - 1; i3++)
                        {
                            Alpha = new double[m2];
                            Beta = new double[m2];
                            Alpha[0] = 0;
                            Beta[0] = C[time, i1, 0, i3];

                            int m2_ = m2 - 1;

                            double niu2 = ((tau * (d_i(i1, m2_, i3, t, n) - 0.5 * h3 * V_minus(i1, m2_, i3, t, n)))
                                / (tau * (d_i(i1, m2_, i3, t, n) - 0.5 * h3 * V_minus(i1, m2_, i3, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0)));
                            double miu2 = ((0.5 * (h3 * h3) * (n_p * C[time, i1, m2_, i3] + tau * gamma * C_m / 3.0) - h3 * tau * d_i_t(i1, m2_, i3, t, n) * (T[time + 1, i1, m2_, i3] - T[time + 1, i1, m2_ - 1, i3]) / h2)
                                / (tau * (d_i(i1, m2_, i3, t, n) - 0.5 * h3 * V_minus(i1, m2_, i3, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0)));

                            double C_m2_2 = niu2 * C[t * 3, i1, m3 - 2, i3] + miu2;

                            for (int n1 = 0; n1 <= 3; n1++)
                            {
                                C[time + 1 + n1, i1, m2 - 1, i3] = C_m2_2;
                            }

                            for (int i = 1; i < m2 - 1; i++)
                            {
                                a = (tau / n_p) * (d_i(i1, i, i3, t, n) / h2) * (Niu_C(i1, i, i3, t, n) / h2 - V_minus(i1, i, i3, t, n) / D_(i1, i, i3, t, n));
                                b = (tau / n_p) * (d_i(i1, i + 1, i3, t, n) / h2) * (Niu_C(i1, i, i3, t, n) / h2 + V_plus(i1, i, i3, t, n) / D_(i1, i, i3, t, n));
                                c = 1 + (tau / n_p) * (Niu_C(i1, i, i3, t, n) * (d_i(i1, i + 1, i3, t, n) + d_i(i1, i, i3, t, n)) / (h2 * h2)
                                    + (d_i(i1, i + 1, i3, t, n) * V_plus(i1, i, i3, t, n) - d_i(i1, i, i3, t, n) * V_minus(i1, i, i3, t, n)) / (h2 * D_(i1, i, i3, t, n)) + gamma / 3.0);
                                s = (tau / n_p) * ((gamma / 3.0) * C_m + (d_i_t(i1, i + 1, i3, t, n)
                                    * (T[time + 1, i1, i + 1, i3] - T[time + 1, i1, i, i3])
                                    - d_i_t(i1, i + 1, i3, t, n) * (T[time + 1, i1, i, i3]
                                    - T[time + 1, i1, i - 1, i3])) / (h2 * h2));
                                Alpha[i] = b / (c - a * Alpha[i - 1]);
                                Beta[i] = (a * Beta[i - 1] + C[time, i1, i, i3] + s) / (c - a * Alpha[i - 1]);
                            }

                            //zvorotnia

                            for (int i = m2 - 2; i > 0;
                                C[time + 1, i1, i, i3] = Alpha[i] * C[time + 1, i1, i + 1, i3] + Beta[i],
                                i--) ;


                        }
                        break;
                    }
                case 3:
                    {
                        for (int i1 = 1; i1 <= m1 - 1; i1++)
                            for (int i2 = 1; i2 <= m2 - 1; i2++)
                            {
                                Alpha = new double[m3];
                                Beta = new double[m3];

                                Alpha3 = (tau * (d_i(i1, i2, 1, t, n) - 0.5 * h3 * V_plus(i1, i2, 0, t, n)))
                                    / (tau * (d_i(i1, i2, 1, t, n) + 0.5 * h3 * V_plus(i1, i2, 0, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0));
                                Beta3 = (0.5 * (h3 * h3) * (n_p * C[time, i1, i2, 0] + tau * gamma * C_m / 3.0) - h3 * tau * d_i_t(i1, i2, 1, t, n) * (T[time + 1, i1, i2, 1] - T[time + 1, i1, i2, 0]) / h3)
                                    / (tau * (d_i(i1, i2, 1, t, n) + 0.5 * h3 * V_plus(i1, i2, 0, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0));

                                Alpha[0] = Alpha3;
                                Beta[0] = Beta3;

                                int m3_ = m3 - 1;

                                double niu3 = ((tau * (d_i(i1, i2, m3_, t, n) - 0.5 * h3 * V_minus(i1, i2, m3_, t, n)))
                                    / (tau * (d_i(i1, i2, m3_, t, n) - 0.5 * h3 * V_minus(i1, i2, m3_, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0)));
                                double miu3 = ((0.5 * (h3 * h3) * (n_p * (C[time, i1, i2, m3_]) + tau * gamma * C_m / 3.0) - h3 * tau * d_i_t(i1, i2, m3_, t, n) * ((T[time + 1, i1, i2, m3_] - T[time + 1, i1, i2, m3_ - 1]) / h3))
                                    / (tau * (d_i(i1, i2, m3_, t, n) - 0.5 * h3 * V_minus(i1, i2, m3_, t, n)) + 0.5 * (h3 * h3) * (n_p + tau * gamma / 3.0)));

                                double C_m3_3 = (niu3 * Beta3 + miu3) / (1 - niu3 * Alpha3);

                                for (int n1 = 0; n1 <= 3; n1++)
                                {
                                    C[time + 1 + n1, i1, i2, m3_] = C_m3_3;
                                }

                                for (int i = 1; i < m3_ - 1; i++) //////////////////////
                                {
                                    a = (tau / n_p) * (d_i(i1, i2, i, t, n) / h3) * (Niu_C(i1, i2, i, t, n) / h3 - V_minus(i1, i2, i, t, n) / D_(i1, i2, i, t, n));
                                    b = (tau / n_p) * (d_i(i1, i2, i + 1, t, n) / h3) * (Niu_C(i1, i2, i, t, n) / h3 + V_plus(i1, i2, i, t, n) / D_(i1, i2, i, t, n));
                                    c = 1 + (tau / n_p) * (Niu_C(i1, i2, i, t, n) * (d_i(i1, i2, i + 1, t, n) + d_i(i1, i2, i, t, n)) / (h3 * h3)
                                        + (d_i(i1, i2, i + 1, t, n) * V_plus(i1, i2, i, t, n) - d_i(i1, i2, i, t, n) * V_minus(i1, i2, i, t, n)) / (h3 * D_(i1, i2, i, t, n)) + gamma / 3.0);
                                    s = (tau / n_p) * ((gamma / 3.0) * C_m + (d_i_t(i1, i2, i + 1, t, n)
                                        * (T[time + 1, i1, i2, i + 1] - T[time + 1, i1, i2, i])
                                        - d_i_t(i1, i2, i, t, n) * (T[time + 1, i1, i2, i]
                                        - T[time + 1, i1, i2, i - 1])) / (h2 * h2));
                                    Alpha[i] = b / (c - a * Alpha[i - 1]);
                                    Beta[i] = (a * Beta[i - 1] + C[time, i1, i2, i] + s) / (c - a * Alpha[i - 1]);
                                }
                                //zvorotnia
                                for (int i = m3 - 2; i >= 0;//i > 0;// 
                                    C[time + 1, i1, i2, i] = Alpha[i] * C[time + 1, i1, i2, i + 1] + Beta[i],
                                    i--) ;

                                /*
                                double C_0_3 = Alpha3 * C[time + 1, i1, i2, 1] + Beta3;

                                for (int n1 = 0; n1 <= 3; n1++)
                                {
                                    C[time + 1 + n1, i1, i2, 0] = Math.Abs(C_0_3);
                                }*/

                            }
                        break;
                    }
            }

        }



        public double a_hn(int i1, int i2, int i3, int t, int n)
        {
            //return (1.0 / 3.0) * (K_(i1, i2, i3, t, n)- K_(i1, i2, i3, t, n));
            switch (n)
            {
                case 1:
                    {
                        return (1.0 / 3.0) * (K_(i1, i2, i3, t, n) + K_(i1 - 1, i2, i3, t, n));
                    }
                case 2:
                    {
                        return (1.0 / 3.0) * (K_(i1, i2, i3, t, n) + K_(i1, i2 - 1, i3, t, n));
                    }
                case 3:
                    {
                        return (1.0 / 3.0) * (K_(i1, i2, i3, t, n) + K_(i1, i2, i3 - 1, t, n));
                    }
                default:
                    {
                        return 0;
                    }
            }
            // Можливі й інші умови де (1/3)*(K_(i1,i2,i3,t) + K_(i1-1,i2,i3,t))
        }
        public double b_hn(int i1, int i2, int i3, int time, int n)
        {
            return (2.0 / 3.0) * V_C;
            // Можливі й інші умови де (1/3)*(V_C(i1,i2,i3,t) + V_C(i1-1,i2,i3,t)) ... ще для i2-1 та i3-1
        }

        public double z_hn(int i1, int i2, int i3, int time, int n)
        {
            return (2.0 / 3.0) * V_T;
            // Можливі й інші умови де (1/3)*(V_T(i1,i2,i3,t) + V_T(i1-1,i2,i3,t)) ... ще для i2-1 та i3-1
        }

        public double a_hn_b(int i1, int i2, int i3, int t, int n)
        {
            //return (1.0 / 3.0) * (K_(i1, i2, i3, t, n)- K_(i1, i2, i3, t, n));
            return (2.0 / 3.0) * K;

            // Можливі й інші умови де (1/3)*(K_(i1,i2,i3,t) + K_(i1-1,i2,i3,t))
        }
        public double b_hn_b(int i1, int i2, int i3, int time, int n)
        {
            return (2.0 / 3.0) * V_C;
            // Можливі й інші умови де (1/3)*(V_C(i1,i2,i3,t) + V_C(i1-1,i2,i3,t)) ... ще для i2-1 та i3-1
        }

        public double z_hn_b(int i1, int i2, int i3, int time, int n)
        {
            return (2.0 / 3.0) * V_T;
            // Можливі й інші умови де (1/3)*(V_T(i1,i2,i3,t) + V_T(i1-1,i2,i3,t)) ... ще для i2-1 та i3-1
        }



        //Напори H Прогонка
        public void Progonca_H(int t, int n)
        {
            /// VVestu (a_h)a = 1 , не зрозуміло значення????
            //Znahodimo Alpha ta Beta , a,b,c 
            double[]
                Alpha = new double[m1],
                Beta = new double[m1];
            double Alpha3 = 0, Beta3 = 0;
            double a, b, c, f;
            int time = t * 3 + n - 1;
            switch (n)
            {
                case 1:
                    {
                        for (int i2 = 1; i2 < m2; i2++)
                            for (int i3 = 0; i3 < m3_; i3++)   //////////////////////////
                            {
                                Alpha = new double[m1];
                                Beta = new double[m1];
                                Alpha[0] = 0;
                                Beta[0] = H[time, 0, i2, i3];

                                for (int i = 1; i < m1 - 1; i++)
                                {
                                    a = (3.0 * tau / (a_h * h1 * h1)) * a_hn(i, i2, i3, t, n);
                                    b = (3.0 * tau / (a_h * h1 * h1)) * a_hn(i + 1, i2, i3, t, n);
                                    c = 1.0 + (3 * tau / (a_h * h1 * h1)) * (a_hn(i, i2, i3, t, n) + a_hn(i + 1, i2, i3, t, n));
                                    f = (3.0 * tau / (a_h * h1 * h1)) * (
                                        (b_hn(i + 1, i2, i3, t, n) * (C[time + 1, i + 1, i2, i3] - C[time + 1, i, i2, i3]) / h1) -
                                        (b_hn(i, i2, i3, t, n) * (C[time + 1, i, i2, i3] - C[time + 1, i - 1, i2, i3]) / h1)
                                        +
                                        (z_hn(i + 1, i2, i3, t, n) * (T[time + 1, i + 1, i2, i3] - T[time + 1, i, i2, i3]) / h1) -
                                        (z_hn(i, i2, i3, t, n) * (T[time + 1, i, i2, i3] - T[time + 1, i - 1, i2, i3]) / h1));

                                    Alpha[i] = b / (c - a * Alpha[i - 1]);
                                    Beta[i] = (a * Beta[i - 1] + H[time, i, i2, i3] + f) / (c - a * Alpha[i - 1]);
                                }

                                for (int i = m1 - 2; i > 0; i--)
                                    H[time + 1, i, i2, i3] = Alpha[i] * H[time + 1, i + 1, i2, i3] + Beta[i];

                            }
                        break;
                    }
                case 2:
                    {
                        for (int i1 = 1; i1 < m1; i1++)
                            for (int i3 = 0; i3 < m3_; i3++)  /////////////////
                            {
                                Alpha = new double[m2];
                                Beta = new double[m2];
                                Alpha[0] = 0;
                                Beta[0] = H[time, i1, 0, i3];


                                for (int i = 1; i < m2 - 1; i++)
                                {
                                    a = (3 * tau / (a_h * h2 * h2)) * a_hn(i1, i, i3, t, n);
                                    b = (3 * tau / (a_h * h2 * h2)) * a_hn(i1, i + 1, i3, t, n);
                                    c = 1 + (3 * tau / (a_h * h2 * h2)) * (a_hn(i1, i, i3, t, n) + a_hn(i1, i + 1, i3, t, n));
                                    f = (3 * tau / (a_h * h2 * h2)) * (
                                        (b_hn(i1, i + 1, i3, t, n) * (C[time + 1, i1, i + 1, i3] - C[time + 1, i1, i, i3]) / h2) -
                                        (b_hn(i1, i, i3, t, n) * (C[time + 1, i1, i, i3] - C[time + 1, i1, i - 1, i3]) / h2)
                                        +
                                        (z_hn(i1, i + 1, i3, t, n) * (T[time + 1, i1, i + 1, i3] - T[time + 1, i1, i, i3]) / h2) -
                                        (z_hn(i1, i, i3, t, n) * (T[time + 1, i1, i, i3] - T[time + 1, i1, i - 1, i3]) / h2)
                                        );

                                    Alpha[i] = b / (c - a * Alpha[i - 1]);
                                    Beta[i] = (a * Beta[i - 1] + H[time, i1, i, i3] + f) / (c - a * Alpha[i - 1]);
                                }
                                //zvorotnia

                                for (int i = m2 - 2; i > 0; i--)
                                    H[time + 1, i1, i, i3] = Alpha[i] * H[time + 1, i1, i + 1, i3] + Beta[i];
                            }
                        break;
                    }
                case 3:
                    {
                        for (int i1 = 1; i1 < m1; i1++)
                            for (int i2 = 1; i2 < m2; i2++)
                            {
                                Alpha = new double[m3];
                                Beta = new double[m3];

                                Alpha3 = (tau * K_g(i1, i2, 1, t, n + 1))
                                    / (tau * K_g(i1, i2, 1, t, n + 1) + 0.5 * a_h * (h3 * h3));
                                Beta3 = (0.5 * (h3 * h3) * a_h * H[time, i1, i2, 1] + tau * (V_C_g(i1, i2, 1, t, n + 1) * (C[time + 1, i1, i2, 1] - C[time + 1, i1, i2, 0]) + V_T_g(i1, i2, 1, t, n + 1) * (T[time + 1, i1, i2, 1] - T[time + 1, i1, i2, 0])))
                                    / (tau * K_g(i1, i2, 1, t, n + 1) + 0.5 * a_h * (h3 * h3));

                                Alpha[0] = Alpha3;
                                Beta[0] = Beta3;

                                int m3_ = m3 - 1;

                                double niu3 = (tau * K_g(i1, i2, m3_, t, n + 1))
                                    / (tau * K_g(i1, i2, m3_, t, n + 1) + 0.5 * a_h * (h3 * h3));
                                double miu3 = (0.5 * a_h * (h3 * h3) * H[time, i1, i2, m3_] + tau * (V_C_g(i1, i2, m3_, t, n + 1) * (C[time + 1, i1, i2, m3_] - C[time + 1, i1, i2, m3_ - 1]) + V_T_g(i1, i2, m3_, t, n + 1) * (T[time + 1, i1, i2, m3_] - T[time + 1, i1, i2, m3_ - 1])))
                                    / (tau * K_g(i1, i2, m3_, t, n + 1) + 0.5 * a_h * (h3 * h3));

                                double H_m3_3 = (niu3 * Beta3 + miu3) / (1 - niu3 * Alpha3);

                                for (int n1 = 0; n1 <= 3; n1++)
                                {
                                    H[time + 1 + n1, i1, i2, m3_] = H_m3_3;
                                }

                                for (int i = 1; i < m3_ - 1; i++)   /////////////////
                                {
                                    a = (3 * tau / (a_h * h3 * h3)) * a_hn(i1, i2, i, t, n);
                                    b = (3 * tau / (a_h * h3 * h3)) * a_hn(i1, i2, i + 1, t, n);
                                    c = 1 + (3 * tau / (a_h * h3 * h3)) * (a_hn(i1, i2, i, t, n) + a_hn(i1, i2, i + 1, t, n));
                                    f = (3 * tau / (a_h * h3 * h3)) * (
                                        (b_hn(i1, i2, i + 1, t, n) * (C[time + 1, i1, i2, i + 1] - C[time + 1, i1, i2, i]) / h3) -
                                        (b_hn(i1, i2, i, t, n) * (C[time + 1, i1, i2, i] - C[time + 1, i1, i2, i - 1]) / h3)
                                        +
                                        (z_hn(i1, i2, i + 1, t, n) * (T[time + 1, i1, i2, i + 1] - T[time + 1, i1, i2, i]) / h3) -
                                        (z_hn(i1, i2, i, t, n) * (T[time + 1, i1, i2, i] - T[time + 1, i1, i2, i - 1]) / h3)
                                        );

                                    Alpha[i] = b / (c - a * Alpha[i - 1]);
                                    Beta[i] = (a * Beta[i - 1] + H[time, i1, i2, i] + f) / (c - a * Alpha[i - 1]);
                                }

                                /*  /\/\/\  /\/\/\  /\/\/\  /\/\/\  /\/\/\  /\/\/\  */

                                //zvorotnia

                                for (int i = m3 - 2; i >= 0; i--)// i > 0;
                                    H[time + 1, i1, i2, i] = Alpha[i] * H[time + 1, i1, i2, i + 1] + Beta[i];

                                /*
                                double H_0_3 = Alpha3 * H[time + 1, i1, i2, 1] + Beta3;

                                for (int n1 = 0; n1 <= 3; n1++)
                                {
                                    H[time + 1 + n1, i1, i2, 0] = H_0_3;
                                }
                                */
                            }
                        break;
                    }
            }

        }
        public void Progonca_H_b(int t, int n)
        {
            /// VVestu (a_h)a = 1 , не зрозуміло значення????
            //Znahodimo Alpha ta Beta , a,b,c 
            double[]
                Alpha = new double[m1],
                Beta = new double[m1];
            double Alpha3 = 0, Beta3 = 0;
            double a, b, c, f;
            int time = t * 3 + n - 1;
            switch (n)
            {
                case 1:
                    {
                        for (int i2 = 1; i2 < m2; i2++)
                            for (int i3 = 0; i3 < m3; i3++)
                            {
                                Alpha = new double[m1];
                                Beta = new double[m1];
                                Alpha[0] = 0;
                                Beta[0] = H_b[time, 0, i2, i3];

                                for (int i = 1; i < m1 - 1; i++)
                                {
                                    a = (3.0 * tau / (a_h * h1 * h1)) * a_hn_b(i, i2, i3, t, n);
                                    b = (3.0 * tau / (a_h * h1 * h1)) * a_hn_b(i + 1, i2, i3, t, n);
                                    c = 1.0 + (3 * tau / (a_h * h1 * h1)) * (a_hn_b(i, i2, i3, t, n) + a_hn_b(i + 1, i2, i3, t, n));
                                    f = (3.0 * tau / (a_h * h1 * h1)) * (
                                        (b_hn_b(i + 1, i2, i3, t, n) * (C_b[time + 1, i + 1, i2, i3] - C_b[time + 1, i, i2, i3]) / h1) -
                                        (b_hn_b(i, i2, i3, t, n) * (C_b[time + 1, i, i2, i3] - C_b[time + 1, i - 1, i2, i3]) / h1)
                                        +
                                        (z_hn_b(i + 1, i2, i3, t, n) * (T_b[time + 1, i + 1, i2, i3] - T_b[time + 1, i, i2, i3]) / h1) -
                                        (z_hn_b(i, i2, i3, t, n) * (T_b[time + 1, i, i2, i3] - T_b[time + 1, i - 1, i2, i3]) / h1));

                                    Alpha[i] = b / (c - a * Alpha[i - 1]);
                                    Beta[i] = (a * Beta[i - 1] + H_b[time, i, i2, i3] + f) / (c - a * Alpha[i - 1]);
                                }

                                for (int i = m1 - 2; i > 0; i--)
                                    H_b[time + 1, i, i2, i3] = Alpha[i] * H_b[time + 1, i + 1, i2, i3] + Beta[i];

                            }
                        break;
                    }
                case 2:
                    {
                        for (int i1 = 1; i1 < m1; i1++)
                            for (int i3 = 0; i3 < m3; i3++)
                            {
                                Alpha = new double[m2];
                                Beta = new double[m2];
                                Alpha[0] = 0;
                                Beta[0] = H_b[time, i1, 0, i3];


                                for (int i = 1; i < m2 - 1; i++)
                                {
                                    a = (3 * tau / (a_h * h2 * h2)) * a_hn_b(i1, i, i3, t, n);
                                    b = (3 * tau / (a_h * h2 * h2)) * a_hn_b(i1, i + 1, i3, t, n);
                                    c = 1 + (3 * tau / (a_h * h2 * h2)) * (a_hn_b(i1, i, i3, t, n) + a_hn_b(i1, i + 1, i3, t, n));
                                    f = (3 * tau / (a_h * h2 * h2)) * (
                                        (b_hn_b(i1, i + 1, i3, t, n) * (C_b[time + 1, i1, i + 1, i3] - C_b[time + 1, i1, i, i3]) / h2) -
                                        (b_hn_b(i1, i, i3, t, n) * (C_b[time + 1, i1, i, i3] - C_b[time + 1, i1, i - 1, i3]) / h2)
                                        +
                                        (z_hn_b(i1, i + 1, i3, t, n) * (T_b[time + 1, i1, i + 1, i3] - T_b[time + 1, i1, i, i3]) / h2) -
                                        (z_hn_b(i1, i, i3, t, n) * (T_b[time + 1, i1, i, i3] - T_b[time + 1, i1, i - 1, i3]) / h2)
                                        );

                                    Alpha[i] = b / (c - a * Alpha[i - 1]);
                                    Beta[i] = (a * Beta[i - 1] + H_b[time, i1, i, i3] + f) / (c - a * Alpha[i - 1]);
                                }
                                //zvorotnia

                                for (int i = m2 - 2; i > 0; i--)
                                    H_b[time + 1, i1, i, i3] = Alpha[i] * H_b[time + 1, i1, i + 1, i3] + Beta[i];
                            }
                        break;
                    }
                case 3:
                    {
                        for (int i1 = 1; i1 < m1; i1++)
                            for (int i2 = 1; i2 < m2; i2++)
                            {
                                Alpha = new double[m3];
                                Beta = new double[m3];

                                Alpha3 = (tau * K_g_b(i1, i2, 1, t, n + 1))
                                    / (tau * K_g_b(i1, i2, 1, t, n + 1) + 0.5 * a_h * (h3 * h3));
                                Beta3 = (0.5 * (h3 * h3) * a_h * H_b[time, i1, i2, 1] + tau * (V_C_g(i1, i2, 1, t, n + 1) * (C_b[time + 1, i1, i2, 1] - C_b[time + 1, i1, i2, 0]) + V_T_g(i1, i2, 1, t, n + 1) * (T_b[time + 1, i1, i2, 1] - T_b[time + 1, i1, i2, 0])))
                                    / (tau * K_g_b(i1, i2, 1, t, n + 1) + 0.5 * a_h * (h3 * h3));

                                Alpha[0] = Alpha3;
                                Beta[0] = Beta3;

                                int m3_ = m3 - 1;

                                double niu3 = (tau * K_g_b(i1, i2, m3_, t, n + 1))
                                    / (tau * K_g_b(i1, i2, m3_, t, n + 1) + 0.5 * a_h * (h3 * h3));
                                double miu3 = (0.5 * a_h * (h3 * h3) * H_b[time, i1, i2, m3_] + tau * (V_C_g(i1, i2, m3_, t, n + 1) * (C_b[time + 1, i1, i2, m3_] - C_b[time + 1, i1, i2, m3_ - 1]) + V_T_g(i1, i2, m3_, t, n + 1) * (T_b[time + 1, i1, i2, m3_] - T_b[time + 1, i1, i2, m3_ - 1])))
                                    / (tau * K_g_b(i1, i2, m3_, t, n + 1) + 0.5 * a_h * (h3 * h3));

                                double H_m3_3 = (niu3 * Beta3 + miu3) / (1 - niu3 * Alpha3);

                                for (int n1 = 0; n1 <= 3; n1++)
                                {
                                    H_b[time + 1 + n1, i1, i2, m3_] = H_m3_3;
                                }

                                for (int i = 1; i < m3 - 1; i++)
                                {
                                    a = (3 * tau / (a_h * h3 * h3)) * a_hn_b(i1, i2, i, t, n);
                                    b = (3 * tau / (a_h * h3 * h3)) * a_hn_b(i1, i2, i + 1, t, n);
                                    c = 1 + (3 * tau / (a_h * h3 * h3)) * (a_hn_b(i1, i2, i, t, n) + a_hn_b(i1, i2, i + 1, t, n));
                                    f = (3 * tau / (a_h * h3 * h3)) * (
                                        (b_hn_b(i1, i2, i + 1, t, n) * (C_b[time + 1, i1, i2, i + 1] - C_b[time + 1, i1, i2, i]) / h3) -
                                        (b_hn_b(i1, i2, i, t, n) * (C_b[time + 1, i1, i2, i] - C_b[time + 1, i1, i2, i - 1]) / h3)
                                        +
                                        (z_hn_b(i1, i2, i + 1, t, n) * (T_b[time + 1, i1, i2, i + 1] - T_b[time + 1, i1, i2, i]) / h3) -
                                        (z_hn_b(i1, i2, i, t, n) * (T_b[time + 1, i1, i2, i] - T_b[time + 1, i1, i2, i - 1]) / h3)
                                        );

                                    Alpha[i] = b / (c - a * Alpha[i - 1]);
                                    Beta[i] = (a * Beta[i - 1] + H_b[time, i1, i2, i] + f) / (c - a * Alpha[i - 1]);
                                }

                                //zvorotnia

                                for (int i = m3 - 2; i >= 0; i--)// i > 0;
                                    H_b[time + 1, i1, i2, i] = Alpha[i] * H_b[time + 1, i1, i2, i + 1] + Beta[i];

                                /*
                                double H_0_3 = Alpha3 * H[time + 1, i1, i2, 1] + Beta3;

                                for (int n1 = 0; n1 <= 3; n1++)
                                {
                                    H[time + 1 + n1, i1, i2, 0] = H_0_3;
                                }
                                */
                            }
                        break;
                    }
            }

        }

        /*
        private double lamda_z(int i1, int i2, int i3, int n)
        {
            return Lamda2;
        }

        private double miu_z(int i1, int i2, int i3, int n)
        {
            return Miu2;// La
        }
        */
        private double L_wave(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return ((lam_[t, i1 + 1, i2, i3] + lam_[t, i1, i2, i3]) +
                          2 * (mju_[t, i1 + 1, i2, i3] + mju_[t, i1, i2, i3])) / (h1 * h1)
                          + (mju_[t, i1, i2 + 1, i3] + mju_[t, i1, i2, i3]) / (h2 * h2)
                          + (mju_[t, i1, i2, i3 + 1] + mju_[t, i1, i2, i3]) / (h3 * h3);
                    }
                case 2:
                    {
                        return ((lam_[t, i1, i2 + 1, i3] + lam_[t, i1, i2, i3]) +
                          2 * (mju_[t, i1, i2 + 1, i3] + mju_[t, i1, i2, i3])) / (h2 * h2)
                          + (mju_[t, i1 + 1, i2, i3] + mju_[t, i1, i2, i3]) / (h1 * h1)
                          + (mju_[t, i1, i2, i3 + 1] + mju_[t, i1, i2, i3]) / (h3 * h3);
                    }
                case 3:
                    {
                        return ((lam_[t, i1, i2, i3 + 1] + lam_[t, i1, i2, i3]) +
                          2 * (mju_[t, i1, i2, i3 + 1] + mju_[t, i1, i2, i3])) / (h3 * h3)
                          + (mju_[t, i1 + 1, i2, i3] + mju_[t, i1, i2, i3]) / (h1 * h1)
                          + (mju_[t, i1, i2 + 1, i3] + mju_[t, i1, i2, i3]) / (h2 * h2);
                    }
                default: { return 0; }
            }
        }

        /*private double P_(int i1, int i2, int i3, int t, int n)
        {
            switch (n) {

            }
        }*/

        // зміщення X, Y, Z, Додати f(с)
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        

        private double AdhesionForcesKuzlo(double c)
        {
            double[] a_ = new double[11] { 0.44569412, -0.2390127, 0.09845744, -0.1414456, 0.0972468, -0.0929422, -0.0222066, 0.07174023, -0.079025, -0.0198, 0.14988672 };

            double concentration = 0;

            for (int i = 0; i < 11; i++)
            {
                concentration += a_[i] * Math.Sqrt(1 + Math.Pow((conc - c), 2));
            }
            
            return concentration;
        }

        private double f(double c)
        {
            switch (f_choise)
            {
                case 0:
                    return (a * c + b);

                case 1:
                    return Math.Sqrt(a * c + b);

                case 2:
                    return a * Math.Log(b * c);

                case 3:
                    return AdhesionForcesKuzlo(c);

                default:
                    return 0;
            }
        }

        // t3+n-1
        //t*3

        private double X_(int i1, int i2, int i3, int t, int n)
        {
            return  ((p_(i1 + 1, i2, i3, t, n) - p_(i1 - 1, i2, i3, t, n)) / (2 * h1)) + f(C[t * 3, i1, i2, i3]);//0;//
        }

        private double Y_(int i1, int i2, int i3, int t, int n)
        {
            return ((p_(i1, i2 + 1, i3, t, n) - p_(i1, i2 - 1, i3, t, n)) / (2 * h2)) + f(C[t * 3, i1, i2, i3]);//0;//
        }

        private double Z_(int i1, int i2, int i3, int t, int n)
        {
            return (gamma_zv2 + (p_(i1, i2 + 1, i3, t, n) - p_(i1, i2 - 1, i3, t, n)) / (2 * h2)) + f(C[t * 3, i1, i2, i3]);//0;//
        }

        // гама перевірити на формі

        private double p_(int i1, int i2, int i3, int t, int n)
        {
            int time = t * 3 + n - 1;
            switch (n)
            {
                case 1:
                    {
                        return gamma_r * (H[time, i1, i2, i3] - h1 * (i1 + 1));
                    }
                case 2:
                    {
                        return gamma_r * (H[time, i1, i2, i3] - h2 * (i2 + 1));
                    }
                case 3:
                    {
                        return gamma_r * (H[time, i1, i2, i3] - h3 * (i3 + 1));
                    }
                default:
                    {
                        return 0;
                    }
            }

        }


        // зміщення main

        private double f_(int i1, int i2, int i3, int t, int n)
        {
            //return 0;
            /////////
            int time = t * 3;
            switch (n)
            {
                case 1:
                    {
                        return X_(i1, i2, i3, t, n) - (((lam_[t,i1 + 1, i2, i3] - lam_[t,i1, i2, i3]) / h1)
                            * (((V_z[t, i1, i2 + 1, i3] - V_z[t, i1, i2, i3]) / (h2)) + ((W_z[t, i1, i2, i3 + 1] - W_z[t, i1, i2, i3]) / (h3))))
                            - (((mju_[t,i1, i2 + 1, i3] - mju_[t,i1, i2, i3]) / h2)
                            * ((V_z[t, i1, i2 + 1, i3] - V_z[t, i1, i2, i3]) / (h1)))
                             - (((mju_[t,i1, i2, i3 + 1] - mju_[t,i1, i2, i3]) / h3)
                            * ((W_z[t, i1, i2 + 1, i3] - W_z[t, i1, i2, i3]) / (h1)))
                            - (lam_[t,i1, i2, i3] + mju_[t,i1, i2, i3]) *
                            (((V_z[t, i1 + 1, i2 + 1, i3] - V_z[t, i1 + 1, i2 - 1, i3] - V_z[t, i1 - 1, i2 + 1, i3] + V_z[t, i1 - 1, i2 - 1, i3]) / (4 * h1 * h2))
                            + ((W_z[t, i1 + 1, i2, i3 + 1] - W_z[t, i1 + 1, i2, i3 - 1] - W_z[t, i1 - 1, i2, i3 + 1] + W_z[t, i1 - 1, i2, i3 - 1]) / (4 * h1 * h3)))
                            + ((3 * (lam_[t, i1 + 1, i2, i3] - lam_[t, i1, i2, i3]) / h1 + 2 * (mju_[t, i1 + 1, i2, i3] - mju_[t, i1, i2, i3]) / h1) * T[time, i1, i2, i3]
                            + (3 * lam_[t,i1, i2, i3] + 2 * mju_[t,i1, i2, i3])  * (T[time, i1 + 1, i2, i3] - T[time, i1 - 1, i2, i3]) / (2 * h1))* Alpha_T;
                    }
                case 2:
                    {
                        return Y_(i1, i2, i3, t, n) - (((lam_[t,i1, i2 + 1, i3] - lam_[t,i1, i2, i3]) / h2)
                            * (((U_z[t, i1 + 1, i2, i3] - U_z[t, i1, i2, i3]) / (h1)) + ((W_z[t, i1, i2 + 1, i3] - W_z[t, i1, i2, i3]) / (h3))))
                            - (((mju_[t,i1 + 1, i2, i3] - mju_[t,i1, i2, i3]) / h1)
                            * ((U_z[t, i1, i2 + 1, i3] - U_z[t, i1, i2, i3]) / (h2)))
                             - (((mju_[t,i1, i2, i3 + 1] - mju_[t,i1, i2, i3]) / h3)
                            * ((W_z[t, i1, i2 + 1, i3] - W_z[t, i1, i2, i3]) / (h2)))
                            - (lam_[t,i1, i2, i3] + mju_[t,i1, i2, i3]) *
                            (((U_z[t, i1 + 1, i2 + 1, i3] - U_z[t, i1 + 1, i2 - 1, i3] - U_z[t, i1 - 1, i2 + 1, i3] + U_z[t, i1 - 1, i2 - 1, i3]) / (4 * h1 * h2))
                            + ((W_z[t, i1, i2 + 1, i3 + 1] - W_z[t, i1, i2 + 1, i3 - 1] - W_z[t, i1, i2 - 1, i3 + 1] + W_z[t, i1, i2 - 1, i3 - 1]) / (4 * h2 * h3)))
                            + (
                            (3 * (lam_[t, i1, i2 + 1, i3] - lam_[t, i1, i2, i3]) / h2 + 2 * (mju_[t, i1, i2 + 1, i3] - mju_[t, i1, i2, i3]) / h2) * T[time, i1, i2, i3]
                            + (3 * lam_[t,i1, i2, i3] + 2 * mju_[t,i1, i2, i3])  * (T[time, i1, i2 + 1, i3] - T[time, i1, i2 - 1, i3]) / (2 * h2)
                            )* Alpha_T;
                    }
                case 3:
                    {
                        return Z_(i1, i2, i3, t, n) - (((lam_[t,i1, i2, i3 + 1] - lam_[t,i1, i2, i3]) / h3)
                            * (((U_z[t, i1 + 1, i2, i3] - U_z[t, i1, i2, i3]) / (h1)) + ((V_z[t, i1, i2 + 1, i3] - V_z[t, i1, i2, i3]) / (h2))))
                            - (((mju_[t,i1 + 1, i2, i3] - mju_[t,i1, i2, i3]) / h1)
                            * ((U_z[t, i1, i2, i3 + 1] - U_z[t, i1, i2, i3]) / (h3)))
                             - (((mju_[t,i1, i2 + 1, i3] - mju_[t,i1, i2, i3]) / h2)
                            * ((V_z[t, i1, i2, i3 + 1] - V_z[t, i1, i2, i3]) / (h3)))
                            - (lam_[t,i1, i2, i3] + mju_[t,i1, i2, i3]) *
                            (((U_z[t, i1 + 1, i2, i3 + 1] - U_z[t, i1 + 1, i2, i3 - 1] - U_z[t, i1 - 1, i2, i3 + 1] + U_z[t, i1 - 1, i2, i3 - 1]) / (4 * h1 * h3))
                            + ((V_z[t, i1, i2 + 1, i3 + 1] - V_z[t, i1, i2 + 1, i3 - 1] - V_z[t, i1, i2 - 1, i3 + 1] + V_z[t, i1, i2 - 1, i3 - 1]) / (4 * h2 * h3)))
                            + (
                            (3 * (lam_[t, i1, i2, i3 + 1] - lam_[t, i1, i2, i3]) / h3 + 2 * (mju_[t, i1, i2, i3 + 1] - mju_[t, i1, i2, i3]) / h3) * T[time, i1, i2, i3]
                            + (3 * lam_[t, i1, i2, i3] + 2 * mju_[t, i1, i2, i3]) * (T[time, i1, i2, i3 + 1] - T[time, i1, i2, i3 - 1]) / (2 * h3)
                            ) * Alpha_T; ;
                    }

                default: { return 0; }
            }
        }

        private double A_wave(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return (lam_[t,i1 + 1, i2, i3] + 2 * mju_[t,i1 + 1, i2, i3]) / (L_wave(i1, i2, i3, t,n) * (h1 * h1));
                    }
                case 2:
                    {
                        return (mju_[t,i1 + 1, i2, i3]) / (L_wave(i1, i2, i3, t, n) * (h1 * h1));
                    }
                case 3:
                    {
                        return (mju_[t,i1 + 1, i2, i3]) / (L_wave(i1, i2, i3,t, n) * (h1 * h1));
                    }
                default:
                    {
                        return 0;
                    }
            }

        }

        private double B_wave(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return (lam_[t,i1, i2, i3] + 2 * mju_[t,i1, i2, i3]) / (L_wave(i1, i2, i3, t, n) * (h1 * h1));
                    }
                case 2:
                    {
                        return (mju_[t,i1, i2, i3]) / (L_wave(i1, i2, i3, t, n) * (h1 * h1));
                    }
                case 3:
                    {
                        return (mju_[t,i1, i2, i3]) / (L_wave(i1, i2, i3, t, n) * (h1 * h1));
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private double C_wave(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return (mju_[t,i1, i2 + 1, i3]) / (L_wave(i1, i2, i3, t, n) * (h2 * h2));
                    }
                case 2:
                    {
                        return (lam_[t,i1, i2 + 1, i3] + 2 * mju_[t,i1, i2 + 1, i3]) / (L_wave(i1, i2, i3, t, n) * (h2 * h2));
                    }
                case 3:
                    {
                        return (mju_[t,i1, i2 + 1, i3]) / (L_wave(i1, i2, i3, t, n) * (h2 * h2));
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private double D_wave(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return (mju_[t,i1, i2, i3]) / (L_wave(i1, i2, i3, t, n) * (h2 * h2));
                    }
                case 2:
                    {
                        return (lam_[t,i1, i2, i3] + 2 * mju_[t,i1, i2, i3]) / (L_wave(i1, i2, i3, t, n) * (h2 * h2));
                    }
                case 3:
                    {
                        return (mju_[t,i1, i2, i3]) / (L_wave(i1, i2, i3, t, n) * (h2 * h2));
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private double E_wave(int i1, int i2, int i3,int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return (mju_[t,i1, i2, i3 + 1]) / (L_wave(i1, i2, i3, t, n) * (h3 * h3));
                    }
                case 2:
                    {
                        return (mju_[t, i1, i2, i3 + 1]) / (L_wave(i1, i2, i3, t, n) * (h3 * h3));
                    }
                case 3:
                    {
                        return (lam_[t,i1, i2, i3 + 1] + 2 * mju_[t,i1, i2, i3 + 1]) / (L_wave(i1, i2, i3, t, n) * (h3 * h3));
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private double G_wave(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return ( mju_[t, i1, i2, i3]) / (L_wave(i1, i2, i3, t, n) * (h3 * h3));
                    }
                case 2:
                    {
                        return (mju_[t, i1, i2, i3]) / (L_wave(i1, i2, i3, t, n) * (h3 * h3));
                    }
                case 3:
                    {
                        return (lam_[t, i1, i2, i3] + 2 * mju_[t, i1, i2, i3]) / (L_wave(i1, i2, i3, t, n) * (h3 * h3));
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private void Gaus_Zeidel_U_V_W(int t, int n)
        {
            if (coeff_choise == 0)
            {
                for (int i1 = 0; i1 <= m1 - 1; i1++)
                    for (int i2 = 0; i2 <= m2 - 1; i2++)
                        for (int i3 = 0; i3 <= m3 - 1; i3++)
                        {
                            mju_[t, i1, i2, i3] = 1000 * (MjuCoeff[2] * Math.Pow((C[t * 3, i1, i2, i3] / C_m), 3) + MjuCoeff[3] * Math.Pow((C[t * 3, i1, i2, i3] / C_m), 2) + MjuCoeff[4] * C[t * 3, i1, i2, i3] / C_m + MjuCoeff[5]);
                            lam_[t, i1, i2, i3] = 1000 * (LamCoeff[2] * Math.Pow((C[t * 3, i1, i2, i3] / C_m), 3) + LamCoeff[3] * Math.Pow((C[t * 3, i1, i2, i3] / C_m), 2) + LamCoeff[4] * C[t * 3, i1, i2, i3] / C_m + LamCoeff[5]);
                            E_[t, i1, i2, i3] = 1000 * (ECoeff[2] * Math.Pow((C[t * 3, i1, i2, i3] / C_m), 3) + ECoeff[3] * Math.Pow((C[t * 3, i1, i2, i3] / C_m), 2) + ECoeff[4] * C[t * 3, i1, i2, i3] / C_m + ECoeff[5]);
                        }
            }
            else
            {
                for (int i1 = 0; i1 <= m1 - 1; i1++)
                    for (int i2 = 0; i2 <= m2 - 1; i2++)
                        for (int i3 = 0; i3 <= m3 - 1; i3++)
                        {
                            mju_[t, i1, i2, i3] = 1000 * (MjuCoeff[0] * Math.Pow((C[t * 3, i1, i2, i3] / C_m), 2) + MjuCoeff[1] * (C[t * 3, i1, i2, i3] / C_m) + MjuCoeff[2] * (C[t * 3, i1, i2, i3] / C_m) * T[t * 3, i1, i2, i3] + MjuCoeff[3] * Math.Pow(T[t * 3, i1, i2, i3], 2) + MjuCoeff[4] * T[t * 3, i1, i2, i3] + MjuCoeff[5]);
                            lam_[t, i1, i2, i3] = 1000 * (LamCoeff[0] * Math.Pow((C[t * 3, i1, i2, i3] / C_m), 2) + LamCoeff[1] * (C[t * 3, i1, i2, i3] / C_m) + LamCoeff[2] * (C[t * 3, i1, i2, i3] / C_m) * T[t * 3, i1, i2, i3] + LamCoeff[3] * Math.Pow(T[t * 3, i1, i2, i3], 2) + LamCoeff[4] * T[t * 3, i1, i2, i3] + LamCoeff[5]);
                            E_[t, i1, i2, i3] = 1000 * (ECoeff[0] * Math.Pow((C[t * 3, i1, i2, i3] / C_m), 2) + ECoeff[1] * (C[t * 3, i1, i2, i3] / C_m) + ECoeff[2] * (C[t * 3, i1, i2, i3] / C_m) * T[t * 3, i1, i2, i3] + ECoeff[3] * Math.Pow(T[t * 3, i1, i2, i3], 2) + ECoeff[4] * T[t * 3, i1, i2, i3] + ECoeff[5]);
                        }
            }

            // Передивитися формули
            bool k = false;

            double val = 0;
            int i = 1;

            double[,,] val_m = new double[m1, m2, m3];

            for (int i1 = 0; i1 < m1; i1++)
                for (int i2 = 0; i2 < m2; i2++)
                    for (int i3 = 0; i3 < m3; i3++)
                        val_m[i1, i2, i3] = 0;
            
                switch (n)
                {
                    case 1:
                        {
                            do
                            { 
                                k = false;
                                i++; 
                                for (int i1 = 1; i1 < m1 - 1; i1++)
                                    for (int i2 = 1; i2 < m2 - 1; i2++)
                                        for (int i3 = 1; i3 < m3 - 1; i3++)
                                        {
                                            val_m[i1, i2, i3] = U_z[t, i1, i2, i3];

                                            U_z[t, i1, i2, i3] = (A_wave(i1, i2, i3, t, n) * U_z[t, i1 + 1, i2, i3]
                                            + B_wave(i1, i2, i3, t, n) * U_z[t, i1 - 1, i2, i3]
                                            + C_wave(i1, i2, i3, t, n) * U_z[t, i1, i2 + 1, i3]
                                            + D_wave(i1, i2, i3, t, n) * U_z[t, i1, i2 - 1, i3]
                                            + E_wave(i1, i2, i3, t, n) * U_z[t, i1, i2, i3 + 1]
                                            + G_wave(i1, i2, i3, t, n) * U_z[t, i1, i2, i3 - 1]
                                            - f_(i1, i2, i3, t, n)/L_wave(i1, i2, i3, t, n) )/*0*/;

                                            if ((Math.Abs(val_m[i1, i2, i3] - U_z[t, i1, i2, i3]) > eps))
                                            {
                                                k = true;
                                            }
                                        }
                            } while ((i < 150) && k );

                            break;
                        }
                    case 2:
                        {
                            do
                            {
                                k = false;
                                i++;
                                for (int i1 = 1; i1 < m1 - 1; i1++)
                                    for (int i2 = 1; i2 < m2 - 1; i2++)
                                        for (int i3 = 1; i3 < m3 - 1; i3++)
                                        {
                                            val_m[i1, i2, i3] = V_z[t, i1, i2, i3];
                                        
                                        V_z[t, i1, i2, i3] =  (A_wave(i1, i2, i3, t, n) * V_z[t, i1 + 1, i2, i3]
                                + B_wave(i1, i2, i3, t, n) * V_z[t, i1 - 1, i2, i3]
                                + C_wave(i1, i2, i3, t, n) * V_z[t, i1, i2 + 1, i3]
                                + D_wave(i1, i2, i3, t, n) * V_z[t, i1, i2 - 1, i3]
                                + E_wave(i1, i2, i3, t, n) * V_z[t, i1, i2, i3 + 1]
                                + G_wave(i1, i2, i3, t, n) * V_z[t, i1, i2, i3 - 1]
                                - f_(i1, i2, i3, t, n) / L_wave(i1, i2, i3, t, n))/*0*/;

                                            if (Math.Abs(val_m[i1, i2, i3] - V_z[t, i1, i2, i3]) > eps)
                                            {
                                                k = true;
                                            }
                                        }
                            }
                            while ((i < 150) && k);
                            break;
                        }
                    case 3:
                        {
                            do
                            {
                                k = false;
                                i++;
                                for (int i1 = 1; i1 < m1 - 1; i1++)
                                    for (int i2 = 1; i2 < m2 - 1; i2++)
                                        for (int i3 = 1; i3 < m3 - 1; i3++)
                                        {
                                        val_m[i1, i2, i3]=W_z[t, i1, i2, i3] ;
                                        W_z[t, i1, i2, i3] = (A_wave(i1, i2, i3, t, n) * W_z[t, i1 + 1, i2, i3]
                                    + B_wave(i1, i2, i3, t, n) * W_z[t, i1 - 1, i2, i3]
                                    + C_wave(i1, i2, i3, t, n) * W_z[t, i1, i2 + 1, i3]
                                    + D_wave(i1, i2, i3, t, n) * W_z[t, i1, i2 - 1, i3]
                                    + E_wave(i1, i2, i3, t, n) * W_z[t, i1, i2, i3 + 1]
                                    + G_wave(i1, i2, i3, t, n) * W_z[t, i1, i2, i3 - 1]
                                    - f_(i1, i2, i3, t, n) / L_wave(i1, i2, i3, t, n)) ;

                                            if (Math.Abs(val_m[i1, i2, i3] - W_z[t, i1, i2, i3]) > eps)
                                            {
                                                k = true;
                                            }
                                        }
                            }
                            while ((i < 150) && k);

                            break;
                        }
            }

        }

        private double E_omega(int i1, int i2, int i3, int t)
        {
            return (E_x[t, i1, i2, i3] + E_y[t, i1, i2, i3] + E_z[t, i1, i2, i3]);
        }


        private void Deform(int t, int n)
        {
            for (int i1 = 1; i1 < m1 - 1; i1++)
                for (int i2 = 1; i2 < m2 - 1; i2++)
                    for (int i3 = 1; i3 < m3 - 1; i3++)
                    {
                        E_x[t, i1, i2, i3] = (U_z[t, i1 + 1, i2, i3] - U_z[t, i1 - 1, i2, i3]) / (2 * h1);
                        E_y[t, i1, i2, i3] = (U_z[t, i1, i2 + 1, i3] - U_z[t, i1, i2 - 1, i3]) / (2 * h2);
                        E_z[t, i1, i2, i3] = (U_z[t, i1, i2, i3 + 1] - U_z[t, i1, i2, i3 - 1]) / (2 * h3);
                    }

            for (int i1 = 1; i1 < m1 - 1; i1++)
                for (int i2 = 1; i2 < m2 - 1; i2++)
                    for (int i3 = 1; i3 < m3 - 1; i3++)
                    {
                        E_xy[t, i1, i2, i3] = (1.0 / 4.0) * ((U_z[t, i1, i2 + 1, i3] - U_z[t, i1, i2 - 1, i3]) / (h2) + (V_z[t, i1 + 1, i2, i3] - V_z[t, i1 - 1, i2, i3]) / (h1));
                        E_xz[t, i1, i2, i3] = (1.0 / 4.0) * ((U_z[t, i1, i2, i3 + 1] - U_z[t, i1, i2, i3 - 1]) / (h3) + (W_z[t, i1 + 1, i2, i3] - W_z[t, i1 - 1, i2, i3]) / (h1));
                        E_yz[t, i1, i2, i3] = (1.0 / 4.0) * ((V_z[t, i1, i2, i3 + 1] - V_z[t, i1, i2, i3 - 1]) / (h3) + (W_z[t, i1, i2 + 1, i3] - W_z[t, i1, i2 - 1, i3]) / (h2));
                    }
        }

        private void Naprug(int t, int n)
        {
            for (int i1 = 1; i1 < m1 - 1; i1++)
                for (int i2 = 1; i2 < m2 - 1; i2++)
                    for (int i3 = 1; i3 < m3 - 1; i3++)
                    {
                        sigma_x[t, i1, i2, i3] = lam_[t, i1, i2, i3] * E_Teta(i1, i2, i3, t, n) + 2 * mju_[t, i1, i2, i3] * E_x[t, i1, i2, i3] - (3 * lam_[t, i1, i2, i3] + 2 * mju_[t, i1, i2, i3]) * Alpha_T * (T[t * 3, i1 - 1, i2, i3] - 2 * T[t * 3, i1, i2, i3]  + T[t * 3, i1 + 1, i2, i3]) / (h1 * h1);
                        sigma_y[t, i1, i2, i3] = lam_[t, i1, i2, i3] * E_Teta(i1, i2, i3, t, n) + 2 * mju_[t, i1, i2, i3] * E_y[t, i1, i2, i3] - (3 * lam_[t, i1, i2, i3] + 2 * mju_[t, i1, i2, i3]) * Alpha_T * (T[t * 3, i1 , i2 - 1, i3] -2 * T[t * 3, i1, i2, i3] + T[t * 3, i1, i2 + 1, i3]) / (h2 * h2);
                        sigma_z[t, i1, i2, i3] = lam_[t, i1, i2, i3] * E_Teta(i1, i2, i3, t, n) + 2 * mju_[t, i1, i2, i3] * E_z[t, i1, i2, i3] - (3 * lam_[t, i1, i2, i3] + 2 * mju_[t, i1, i2, i3]) * Alpha_T * (T[t * 3, i1 , i2, i3 - 1] - T[t * 3, i1, i2, i3] + T[t * 3, i1, i2, i3 + 1]) / (h3 * h3); ;
                        }

            for (int i1 = 1; i1 < m1 - 1; i1++)
                for (int i2 = 1; i2 < m2 - 1; i2++)
                    for (int i3 = 1; i3 < m3 - 1; i3++)
                    {
                        tau_xy[t, i1, i2, i3] =  2 * mju_[t, i1, i2, i3] * E_xy[t, i1, i2, i3] ;
                        tau_xz[t, i1, i2, i3] =  2 * mju_[t, i1, i2, i3] * E_xz[t, i1, i2, i3] ;
                        tau_yz[t, i1, i2, i3] =  2 * mju_[t, i1, i2, i3] * E_yz[t, i1, i2, i3] ;
                    }
        }
        

        private double E_Teta(int  i1, int i2, int i3,int t , int n)
        {
            return E_x[t,i1,i2,i3] + E_y[t, i1, i2, i3] + E_z[t, i1, i2, i3];
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Зміщення без тепло-масопереносу
        /// 

        private double L_wave_b(int i1, int i2, int i3, int t, int n)
        {
                        return ((lam_b + lam_b) +
                          2 * (mju_b + mju_b)) / (h3 * h3)
                          + (mju_b + mju_b) / (h1 * h1)
                          + (mju_b + mju_b) / (h2 * h2);
        }

        /*private double P_(int i1, int i2, int i3, int t, int n)
        {
            switch (n) {

            }
        }*/

        private double X_b(int i1, int i2, int i3, int t, int n)
        {
            return (p_b(i1 + 1, i2, i3, t, n) - p_b(i1 - 1, i2, i3, t, n)) / (2 * h1);//0;//
        }

        private double Y_b(int i1, int i2, int i3, int t, int n)
        {
            return (p_b(i1, i2 + 1, i3, t, n) - p_b(i1, i2 - 1, i3, t, n)) / (2 * h2);//0;//
        }

        private double Z_b(int i1, int i2, int i3, int t, int n)
        {
            return gamma_zv2 + (p_b(i1, i2 + 1, i3, t, n) - p_b(i1, i2 - 1, i3, t, n)) / (2 * h2);//0;//
        }
        private double p_b(int i1, int i2, int i3, int t, int n)
        {
            int time = t * 3 + n - 1;
            switch (n)
            {
                case 1:
                    {
                        return (H_b[time, i1, i2, i3] - h1 * (i1 + 1));
                    }
                case 2:
                    {
                        return (H_b[time, i1, i2, i3] - h2 * (i2 + 1));
                    }
                case 3:
                    {
                        return (H_b[time, i1, i2, i3] - h3 * (i3 + 1));
                    }
                default:
                    {
                        return 0;
                    }
            }

        }
        private double f_b(int i1, int i2, int i3, int t, int n)
        {
            //return 0;
            /////////
            int time = t * 3;
            switch (n)
            {
                case 1:
                    {
                        return X_b(i1, i2, i3, t, n) 
                            - (lam_b + mju_b) *
                            (((V_z_b[t, i1 + 1, i2 + 1, i3] - V_z_b[t, i1 + 1, i2 - 1, i3] - V_z_b[t, i1 - 1, i2 + 1, i3] + V_z_b[t, i1 - 1, i2 - 1, i3]) / (4 * h1 * h2))
                            + ((W_z_b[t, i1 + 1, i2, i3 + 1] - W_z_b[t, i1 + 1, i2, i3 - 1] - W_z_b[t, i1 - 1, i2, i3 + 1] + W_z_b[t, i1 - 1, i2, i3 - 1]) / (4 * h1 * h3)));
                    }
                case 2:
                    {
                        return Y_b(i1, i2, i3, t, n) 
                            - (lam_b + mju_b) *
                            (((U_z_b[t, i1 + 1, i2 + 1, i3] - U_z_b[t, i1 + 1, i2 - 1, i3] - U_z_b[t, i1 - 1, i2 + 1, i3] + U_z_b[t, i1 - 1, i2 - 1, i3]) / (4 * h1 * h2))
                            + ((W_z_b[t, i1, i2 + 1, i3 + 1] - W_z_b[t, i1, i2 + 1, i3 - 1] - W_z_b[t, i1, i2 - 1, i3 + 1] + W_z_b[t, i1, i2 - 1, i3 - 1]) / (4 * h2 * h3)))
                            ;
                    }
                case 3:
                    {
                        return Z_b(i1, i2, i3, t, n) 
                            - (lam_b + mju_b) *
                            (((U_z_b[t, i1 + 1, i2, i3 + 1] - U_z_b[t, i1 + 1, i2, i3 - 1] - U_z_b[t, i1 - 1, i2, i3 + 1] + U_z_b[t, i1 - 1, i2, i3 - 1]) / (4 * h1 * h3))
                            + ((V_z_b[t, i1, i2 + 1, i3 + 1] - V_z_b[t, i1, i2 + 1, i3 - 1] - V_z_b[t, i1, i2 - 1, i3 + 1] + V_z_b[t, i1, i2 - 1, i3 - 1]) / (4 * h2 * h3)))
                             ;
                    }

                default: { return 0; }
            }
        }

        private double A_wave_b(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return (lam_b + 2 * mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h1 * h1));
                    }
                case 2:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h1 * h1));
                    }
                case 3:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h1 * h1));
                    }
                default:
                    {
                        return 0;
                    }
            }

        }

        private double B_wave_b(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return (lam_b + 2 * mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h1 * h1));
                    }
                case 2:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h1 * h1));
                    }
                case 3:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h1 * h1));
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private double C_wave_b(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h2 * h2));
                    }
                case 2:
                    {
                        return (lam_b + 2 * mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h2 * h2));
                    }
                case 3:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h2 * h2));
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private double D_wave_b(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h2 * h2));
                    }
                case 2:
                    {
                        return (lam_b + 2 * mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h2 * h2));
                    }
                case 3:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h2 * h2));
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private double E_wave_b(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h3 * h3));
                    }
                case 2:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h3 * h3));
                    }
                case 3:
                    {
                        return (lam_b + 2 * mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h3 * h3));
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private double G_wave_b(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h3 * h3));
                    }
                case 2:
                    {
                        return (mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h3 * h3));
                    }
                case 3:
                    {
                        return (lam_b + 2 * mju_b) / (L_wave_b(i1, i2, i3, t, n) * (h3 * h3));
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        private void Gaus_Zeidel_U_V_W_b(int t, int n)
        {
            
                        mju_b = Miu2;
                        lam_b = Lamda2;


            // Передивитися формули
            bool k = false;

            double val = 0;
            int i = 1;

            double[,,] val_m = new double[m1, m2, m3];

            for (int i1 = 0; i1 < m1; i1++)
                for (int i2 = 0; i2 < m2; i2++)
                    for (int i3 = 0; i3 < m3; i3++)
                        val_m[i1, i2, i3] = 0;

            switch (n)
            {
                case 1:
                    {
                        do
                        {
                            k = false;
                            i++;
                            for (int i1 = 1; i1 < m1 - 1; i1++)
                                for (int i2 = 1; i2 < m2 - 1; i2++)
                                    for (int i3 = 1; i3 < m3 - 1; i3++)
                                    {
                                        val_m[i1, i2, i3] = U_z_b[t, i1, i2, i3];

                                        U_z_b[t, i1, i2, i3] = (A_wave_b(i1, i2, i3, t, n) * U_z_b[t, i1 + 1, i2, i3]
                                        + B_wave_b(i1, i2, i3, t, n) * U_z_b[t, i1 - 1, i2, i3]
                                        + C_wave_b(i1, i2, i3, t, n) * U_z_b[t, i1, i2 + 1, i3]
                                        + D_wave_b(i1, i2, i3, t, n) * U_z_b[t, i1, i2 - 1, i3]
                                        + E_wave_b(i1, i2, i3, t, n) * U_z_b[t, i1, i2, i3 + 1]
                                        + G_wave_b(i1, i2, i3, t, n) * U_z_b[t, i1, i2, i3 - 1]
                                        - f_b(i1, i2, i3, t, n) / L_wave(i1, i2, i3, t, n))/*0*/;

                                        if ((Math.Abs(val_m[i1, i2, i3] - U_z_b[t, i1, i2, i3]) > eps))
                                        {
                                            k = true;
                                        }
                                    }
                        } while ((i < 150) && k);

                        break;
                    }
                case 2:
                    {
                        do
                        {
                            k = false;
                            i++;
                            for (int i1 = 1; i1 < m1 - 1; i1++)
                                for (int i2 = 1; i2 < m2 - 1; i2++)
                                    for (int i3 = 1; i3 < m3 - 1; i3++)
                                    {
                                        val_m[i1, i2, i3] = V_z_b[t, i1, i2, i3];

                                        V_z_b[t, i1, i2, i3] = (A_wave_b(i1, i2, i3, t, n) * V_z_b[t, i1 + 1, i2, i3]
                                + B_wave_b(i1, i2, i3, t, n) * V_z_b[t, i1 - 1, i2, i3]
                                + C_wave_b(i1, i2, i3, t, n) * V_z_b[t, i1, i2 + 1, i3]
                                + D_wave_b(i1, i2, i3, t, n) * V_z_b[t, i1, i2 - 1, i3]
                                + E_wave_b(i1, i2, i3, t, n) * V_z_b[t, i1, i2, i3 + 1]
                                + G_wave_b(i1, i2, i3, t, n) * V_z_b[t, i1, i2, i3 - 1]
                                - f_b(i1, i2, i3, t, n) / L_wave_b(i1, i2, i3, t, n))/*0*/;

                                        if (Math.Abs(val_m[i1, i2, i3] - V_z_b[t, i1, i2, i3]) > eps)
                                        {
                                            k = true;
                                        }
                                    }
                        }
                        while ((i < 150) && k);
                        break;
                    }
                case 3:
                    {
                        do
                        {
                            k = false;
                            i++;
                            for (int i1 = 1; i1 < m1 - 1; i1++)
                                for (int i2 = 1; i2 < m2 - 1; i2++)
                                    for (int i3 = 1; i3 < m3 - 1; i3++)
                                    {
                                        val_m[i1, i2, i3] = W_z_b[t, i1, i2, i3];
                                        W_z_b[t, i1, i2, i3] = (A_wave_b(i1, i2, i3, t, n) * W_z_b[t, i1 + 1, i2, i3]
                                    + B_wave_b(i1, i2, i3, t, n) * W_z_b[t, i1 - 1, i2, i3]
                                    + C_wave_b(i1, i2, i3, t, n) * W_z_b[t, i1, i2 + 1, i3]
                                    + D_wave_b(i1, i2, i3, t, n) * W_z_b[t, i1, i2 - 1, i3]
                                    + E_wave_b(i1, i2, i3, t, n) * W_z_b[t, i1, i2, i3 + 1]
                                    + G_wave_b(i1, i2, i3, t, n) * W_z_b[t, i1, i2, i3 - 1]
                                    - f_b(i1, i2, i3, t, n) / L_wave_b(i1, i2, i3, t, n));

                                        if (Math.Abs(val_m[i1, i2, i3] - W_z_b[t, i1, i2, i3]) > eps)
                                        {
                                            k = true;
                                        }
                                    }
                        }
                        while ((i < 150) && k);

                        break;
                    }
            }

        }

        private double E_omega_b(int i1, int i2, int i3, int t)
        {
            return (E_x_b[t, i1, i2, i3] + E_y_b[t, i1, i2, i3] + E_z_b[t, i1, i2, i3]);
        }


        private void Deform_b(int t, int n)
        {
            for (int i1 = 1; i1 < m1 - 1; i1++)
                for (int i2 = 1; i2 < m2 - 1; i2++)
                    for (int i3 = 1; i3 < m3 - 1; i3++)
                    {
                        E_x_b[t, i1, i2, i3] = (U_z_b[t, i1 + 1, i2, i3] - U_z_b[t, i1 - 1, i2, i3]) / (2 * h1);
                        E_y_b[t, i1, i2, i3] = (U_z_b[t, i1, i2 + 1, i3] - U_z_b[t, i1, i2 - 1, i3]) / (2 * h2);
                        E_z_b[t, i1, i2, i3] = (U_z_b[t, i1, i2, i3 + 1] - U_z_b[t, i1, i2, i3 - 1]) / (2 * h3);
                    }

            for (int i1 = 1; i1 < m1 - 1; i1++)
                for (int i2 = 1; i2 < m2 - 1; i2++)
                    for (int i3 = 1; i3 < m3 - 1; i3++)
                    {
                        E_xy_b[t, i1, i2, i3] = (1.0 / 4.0) * ((U_z_b[t, i1, i2 + 1, i3] - U_z_b[t, i1, i2 - 1, i3]) / (h2) + (V_z_b[t, i1 + 1, i2, i3] - V_z_b[t, i1 - 1, i2, i3]) / (h1));
                        E_xz_b[t, i1, i2, i3] = (1.0 / 4.0) * ((U_z_b[t, i1, i2, i3 + 1] - U_z_b[t, i1, i2, i3 - 1]) / (h3) + (W_z_b[t, i1 + 1, i2, i3] - W_z_b[t, i1 - 1, i2, i3]) / (h1));
                        E_yz_b[t, i1, i2, i3] = (1.0 / 4.0) * ((V_z_b[t, i1, i2, i3 + 1] - V_z_b[t, i1, i2, i3 - 1]) / (h3) + (W_z_b[t, i1, i2 + 1, i3] - W_z_b[t, i1, i2 - 1, i3]) / (h2));
                    }
        }

        private void Naprug_b(int t, int n)
        {
            for (int i1 = 1; i1 < m1 - 1; i1++)
                for (int i2 = 1; i2 < m2 - 1; i2++)
                    for (int i3 = 1; i3 < m3 - 1; i3++)
                    {
                        sigma_x_b[t, i1, i2, i3] = lam_b * E_Teta_b(i1, i2, i3, t, n) + 2 * mju_b * E_x_b[t, i1, i2, i3] - (3 * lam_b + 2 * mju_b) * Alpha_Tb * (T_b[t * 3, i1 - 1, i2, i3] - 2 * T_b[t * 3, i1, i2, i3] + T_b[t * 3, i1 + 1, i2, i3]) / (h1 * h1);
                        sigma_y_b[t, i1, i2, i3] = lam_b * E_Teta_b(i1, i2, i3, t, n) + 2 * mju_b * E_y_b[t, i1, i2, i3] - (3 * lam_b + 2 * mju_b) * Alpha_Tb * (T_b[t * 3, i1, i2 - 1, i3] - 2 * T_b[t * 3, i1, i2, i3] + T_b[t * 3, i1, i2 + 1, i3]) / (h2 * h2);
                        sigma_z_b[t, i1, i2, i3] = lam_b * E_Teta_b(i1, i2, i3, t, n) + 2 * mju_b * E_z_b[t, i1, i2, i3] - (3 * lam_b + 2 * mju_b) * Alpha_Tb * (T_b[t * 3, i1, i2, i3 - 1] - T_b[t * 3, i1, i2, i3] + T_b[t * 3, i1, i2, i3 + 1]) / (h3 * h3); ;
                    }

            for (int i1 = 1; i1 < m1 - 1; i1++)
                for (int i2 = 1; i2 < m2 - 1; i2++)
                    for (int i3 = 1; i3 < m3 - 1; i3++)
                    {
                        tau_xy_b[t, i1, i2, i3] = 2 * mju_b * E_xy_b[t, i1, i2, i3];
                        tau_xz_b[t, i1, i2, i3] = 2 * mju_b * E_xz_b[t, i1, i2, i3];
                        tau_yz_b[t, i1, i2, i3] = 2 * mju_b * E_yz_b[t, i1, i2, i3];
                    }
        }


        private double E_Teta_b(int i1, int i2, int i3, int t, int n)
        {
            return E_x_b[t, i1, i2, i3] + E_y_b[t, i1, i2, i3] + E_z_b[t, i1, i2, i3];
        }
    }
}
