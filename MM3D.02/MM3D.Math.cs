using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM3D._02
{
    class MM3D
    {
        public int
           m1 = 10,
           m2 = 10,
           m3 = 10;
        public static double
            C_m,
            C_t,
            n_p,
            ro,
            C_p,
            tau,
            h1,
            h2,
            h3,
            Lamda = 108 * 10,
            gamma;

        public double[,,,]
            C, H1, H2, H3, T,
            D1, D2, D3,
            Niu1, Niu2, Niu3,
            LamdaT1, LamdaT2, LamdaT3,
            V1, V2, V3,
            V_T1, V_T2, V_T3,
            
            V_C1, V_C2, V_C3,
            K1, K2, K3;

        // Lamda для температури
        public double Lamda_(int i1, int i2, int i3, int t, int n)
        {
            return (2.0/3.0 * Lamda);
            switch (n)
            {
                case 1: { return (double)(1.0 / 3) * (LamdaT1[t, i1, i2, i3] + LamdaT1[t, i1 - 1, i2, i3]); }
                case 2: { return (double)(1.0 / 3) * (LamdaT2[t, i1, i2, i3] + LamdaT2[t, i1, i2 - 1, i3]); }
                case 3: { return (double)(1.0 / 3) * (LamdaT3[t, i1, i2, i3] + LamdaT3[t, i1, i2, i3 - 1]); }
                default: return 0;
            }
        }

        // d_i для концентрації
        public double d_i(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1: { return (double)(1.0 / 3) * (D1[t, i1, i2, i3] + D1[t, i1 - 1, i2, i3]); }
                case 2: { return (double)(1.0 / 3) * (D2[t, i1, i2, i3] + D2[t, i1, i2 - 1, i3]); }
                case 3: { return (double)(1.0 / 3) * (D3[t, i1, i2, i3] + D3[t, i1, i2, i3 - 1]); }
                default: return 0;
            }
        }

        // Niu для температури
        public double Niu_(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1: return (1.0 / ((1.0 + h1 * ro * C_p * Math.Abs(V1[t, i1, i2, i3])) / (3 * LamdaT1[t, i1, i2, i3])));
                case 2: return (1.0 / ((1.0 + h2 * ro * C_p * Math.Abs(V2[t, i1, i2, i3])) / (3 * LamdaT2[t, i1, i2, i3])));
                case 3: return (1.0 / ((1.0 + h3 * ro * C_p * Math.Abs(V3[t, i1, i2, i3])) / (3 * LamdaT3[t, i1, i2, i3])));
                default: return 0;
            }
        }

        // Niu для концентрації
        public double Niu_C(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1: return (1.0 / ((1.0 + h1 * ro * C_p * Math.Abs(V1[t, i1, i2, i3])) / (3 * D1[t, i1, i2, i3])));
                case 2: return (1.0 / ((1.0 + h2 * ro * C_p * Math.Abs(V2[t, i1, i2, i3])) / (3 * D2[t, i1, i2, i3])));
                case 3: return (1.0 / ((1.0 + h3 * ro * C_p * Math.Abs(V3[t, i1, i2, i3])) / (3 * D3[t, i1, i2, i3])));
                default: return 0;
            }
        }

        //Швидкість Vi
        public void V_i(int i1, int i2, int i3, int t, int n)
        {
            switch (n)
            {
                case 1:
                    {
                        V1[t, i1, i2, i3] = -K1[t, i1, i2, i3] * (H1[t, i1 + 1, i2, i3] - H1[t, i1 - 1, i2, i3]) / (2 * h1) +
                          V_C1[t, i1, i2, i3] * (C[t, i1 + 1, i2, i3] - C[t, i1 - 1, i2, i3]) / (2 * h1) +
                          V_C1[t, i1, i2, i3] * (T[t, i1 + 1, i2, i3] - T[t, i1 - 1, i2, i3]) / (2 * h1); break;
                    }
                case 2:
                    {
                        V2[t, i1, i2, i3] = -K2[t, i1, i2, i3] * (H2[t, i1, i2 + 1, i3] - H2[t, i1, i2 - 1, i3]) / (2 * h2) +
                          V_C2[t, i1, i2, i3] * (C[t, i1, i2 + 1, i3] - C[t, i1, i2 - 1, i3]) / (2 * h2) +
                          V_C2[t, i1, i2, i3] * (T[t, i1, i2 + 1, i3] - T[t, i1, i2 - 1, i3]) / (2 * h2); break;
                    }
                case 3:
                    {
                        V3[t, i1, i2, i3] = -K3[t, i1, i2, i3] * (H3[t, i1, i2, i3 + 1] - H2[t, i1, i2, i3 - 1]) / (2 * h3) +
                          V_C3[t, i1, i2, i3] * (C[t, i1, i2, i3 + 1] - C[t, i1, i2, i3 - 1]) / (2 * h3) +
                          V_C3[t, i1, i2, i3] * (T[t, i1, i2, i3 + 1] - T[t, i1, i2, i3 - 1]) / (2 * h3); break;
                    }
            }
        }

        /// V(j,i1,i2,i3)_plus
        public double V_plus(int i1, int i2, int i3, int t, int n)
        {
            V_i(i1,i2,i3,t,n);

            switch (n)
            {
                case 1:
                    {
                        return (-V1[t,i1,i2,i3]-Math.Abs(V1[t, i1, i2, i3]))/3.0;
                    }
                case 2:
                    {
                        return (-V2[t, i1, i2, i3] - Math.Abs(V2[t, i1, i2, i3])) / 3.0;
                    }
                case 3:
                    {
                        return (-V3[t, i1, i2, i3] - Math.Abs(V3[t, i1, i2, i3])) / 3.0;
                    }
            }
        }

        /// V(j,i1,i2,i3)_minus
        public double V_minus(int i1, int i2, int i3, int t, int n)
        {
            V_i(i1, i2, i3, t, n);

            switch (n)
            {
                case 1:
                    {
                        return (-V1[t, i1, i2, i3] + Math.Abs(V1[t, i1, i2, i3])) / 3.0;
                    }
                case 2:
                    {
                        return (-V2[t, i1, i2, i3] + Math.Abs(V2[t, i1, i2, i3])) / 3.0;
                    }
                case 3:
                    {
                        return (-V3[t, i1, i2, i3] + Math.Abs(V3[t, i1, i2, i3])) / 3.0;
                    }
            }
        }
        public double K_1(double K_C, double K_T)
        {
            return (double)1;
        }
        public double K_2(double K_C, double K_T)
        {
            return (double)1;
        }
        public double K_3(double K_C, double K_T)
        {
            return (double)1;
        }


        public void Progonca_T(int i1, int i2, int i3, int time, int n)
        {
            
            //Znahodimo Alpha ta Beta , a,b,c 

            double[]
                Alpha = new double[m1],
                Beta = new double[m1];
            double a, b, c;
            int t = time + n - 1;
            switch (n)
            {
                case 1:
                    {
                        Alpha = new double[m1];
                        Beta = new double[m1];
                        Alpha[0] = 0;
                        Beta[0] = T[ t , 0, i2, i3];
                        V_i(i1, i2, i3, t, n);// Рахує V_i(i1, i2, i3, t, n)

                        a = (tau / C_t) * (Lamda_(i1, i2, i3, t, n) / h1) * (Niu_(i1, i2, i3, t, n) / h1 - (ro * C_p * V1[t, i1, i2, i3]) / LamdaT1[t, i1, i2, i3]);
                        b = (tau / C_t) * (Lamda_(i1, i2, i3, t, n) / h1) * (Niu_(i1, i2, i3, t, n) / h1 - (ro * C_p * V1[t, i1, i2, i3]) / LamdaT1[t, i1, i2, i3]);
                        c = 1 + (tau / C_t) * (Niu_(i1, i2, i3, t, n) * (Lamda_(i1 + 1, i2, i3, t, n) + Lamda_(i1, i2, i3, t, n)) / (h1 * h1) 
                            + ((ro * C_p) / LamdaT1[t, i1, i2, i3]) * (Lamda_(i1 + 1, i2, i3, t, n) * V1[t, i1, i2, i3] - Lamda_(i1, i2, i3, t, n) * V1[t, i1, i2, i3]));

                        for (int i = 1; i < m1;
                            Alpha[i] = b / (c - a * Alpha[i - 1]),
                            Beta[i] = (a * Beta[i - 1] + T[t, i, i2, i3]) / (c - a * Alpha[i - 1]),
                            i++) ;
                        break;
                    }
                case 2:
                    {
                        Alpha = new double[m2];
                        Beta = new double[m2];
                        Alpha[0] = 0;
                        Beta[0] = T[t, i1, 0, i3];
                        V_i(i1, i2, i3, t, n);// Рахує V_i(i1, i2, i3, t, n)

                        a = (tau / C_t) * (Lamda_(i1, i2, i3, t, n) / h2) * (Niu_(i1, i2, i3, t, n) / h2 - (ro * C_p * V2[t, i1, i2, i3]) / LamdaT2[t, i1, i2, i3]);
                        b = (tau / C_t) * (Lamda_(i1, i2, i3, t, n) / h2) * (Niu_(i1, i2, i3, t, n) / h2 - (ro * C_p * V2[t, i1, i2, i3]) / LamdaT2[t, i1, i2, i3]);
                        c = 1 + (tau / C_t) * (Niu_(i1, i2, i3, t, n) * (Lamda_(i1, i2 + 1, i3, t, n) + Lamda_(i1, i2, i3, t, n)) / (h2 * h2)
                            + ((ro * C_p) / LamdaT2[t, i1, i2, i3]) * (Lamda_(i1, i2 + 1, i3, t, n) * V2[t, i1, i2, i3] - Lamda_(i1, i2, i3, t, n) * V2[t, i1, i2, i3]));

                        for (int i = 1; i < m2;
                            Alpha[i] = b / (c - a * Alpha[i - 1]),
                            Beta[i] = (a * Beta[i - 1] + T[t, i1, i, i3]) / (c - a * Alpha[i - 1]),
                            i++) ;
                        break;
                    }
                case 3:
                    {
                        Alpha = new double[m3];
                        Beta = new double[m3];
                        Alpha[0] = 0;
                        Beta[0] = T[t, i1, i2, 0];
                        V_i(i1, i2, i3, t, n);// Рахує Vi[t,i1, i2, i3]

                        a = (tau / C_t) * (Lamda_(i1, i2, i3, t, n) / h3) * (Niu_(i1, i2, i3, t, n) / h3 - (ro * Cp * V3[t, i1, i2, i3]) / LamdaT3[t, i1, i2, i3]);
                        b = (tau / C_t) * (Lamda_(i1, i2, i3, t, n) / h3) * (Niu_(i1, i2, i3, t, n) / h3 - (ro * Cp * V3[t, i1, i2, i3]) / LamdaT3[t, i1, i2, i3]);
                        c = 1 + (tau / C_t) * (Niu_(i1, i2, i3, t, n) * (Lamda_(i1, i2, i3 + 1, t, n) + Lamda_(i1, i2, i3, t, n)) / (h3 * h3)
                            + ((ro * C_p) / LamdaT3[i1, i2, i3, t]) * (Lamda_(i1, i2, i3 + 1, t, n) * V3[t,i1, i2, i3] - Lamda_(i1, i2, i3, t, n) * V3[t,i1, i2, i3]));

                        for (int i = 1; i < m3;
                            Alpha[i] = b / (c - a * Alpha[i - 1]),
                            Beta[i] = (a * Beta[i - 1] + T[t, i1, i2, i]) / (c - a * Alpha[i - 1]),
                            i++) ;
                        break;
                    }
            }

            switch (n)
            {
                case 1:
                    {
                        for (int i = m1 - 2; i > 0;
                            T[t+1 ,i, i2, i3] = Alpha[i] * T[t+1,i + 1, i2, i3] + Beta[i],
                            i--) ;
                        break;
                    }
                case 2:
                    {
                        for (int i = m2 - 2; i > 0;
                            T[t+1, i1, i, i3] = Alpha[i] * T[t+1, i1, i + 1, i3] + Beta[i],
                            i--) ;
                        break;
                    }
                case 3:
                    {
                        for (int i = m3 - 2; i > 0;
                            T[t+1, i1, i2, i] = Alpha[i] * T[t+1, i1, i2, i + 1] + Beta[i],
                            i--) ;
                        break;
                    }
            }
        }

        //Концентрація С Прогонка
        public void Progonca_C(int i1, int i2, int i3, int time, int n)
        {

            //Znahodimo Alpha ta Beta , a,b,c 

            double[]
                Alpha = new double[m1],
                Beta = new double[m1];
            double a, b, c, s;
            int t = time + n - 1;
            switch (n)
            {
                case 1:
                    {
                        Alpha = new double[m1];
                        Beta = new double[m1];
                        Alpha[0] = 0;
                        Beta[0] = C[t, 0, i2, i3];

                        a = (tau / n_p) * (d_i(i1,i2,i3,t,n) / h1) * (Niu_C(i1,i2,i3,t,n) / h1 - V_minus(i1, i2, i3, t, n) / D1[t,i1, i2, i3] );
                        b = (tau / n_p) * (d_i(i1+1, i2, i3, t, n) / h1) * (Niu_C(i1, i2, i3, t, n) / h1 + V_plus(i1, i2, i3, t, n) / D1[t, i1, i2, i3]);
                        c = 1 + (tau / n_p) * (Niu_C(i1, i2, i3, t, n)*(d_i(i1+1,i2,i3,t,n) +d_i(i1,i2,i3,t,n))/(h1*h1) 
                            + (d_i(i1+1,i2,i3,t,n)*V_plus(i1, i2, i3, t, n) - d_i(i1, i2, i3, t, n) * V_minus(i1, i2, i3, t, n)) /(h1 * D1[t,i1,i2,i3]) + gamma/3.0) ;

                        for (int i = 1; i < m1-1;
                            ///
                            /// Яка буде формула якщо і виходить за границю m1 або рывне їй що недопустимо
                            /// чи робити границю m1+1
                            /// 
                            s = (tau / n_p) * ((gamma/3.0)*C_m + (d_i(i+1, i2, i3, t, n)*(T[t+1,i+1,i2,i3]- T[t + 1, i, i2, i3]) - d_i(i + 1, i2, i3, t, n) * (T[t+1, i, i2, i3] - T[t + 1, i-1, i2, i3])) / (h1*h1) ),
                            Alpha[i] = b / (c - a * Alpha[i - 1]),
                            Beta[i] = (a * Beta[i - 1] + s ) / (c - a * Alpha[i - 1]),
                            i++) ;
                        break;
                    }
                case 2:
                    {
                        Alpha = new double[m2];
                        Beta = new double[m2];
                        Alpha[0] = 0;
                        Beta[0] = C[t, i1, 0, i3];

                        a = (tau / n_p) * (d_i(i1, i2, i3, t, n) / h2) * (Niu_C(i1, i2, i3, t, n) / h2 - V_minus(i1, i2, i3, t, n) / D2[t, i1, i2, i3]);
                        b = (tau / n_p) * (d_i(i1, i2 + 1, i3, t, n) / h2) * (Niu_C(i1, i2, i3, t, n) / h2 + V_plus(i1, i2, i3, t, n) / D2[t, i1, i2, i3]);
                        c = 1 + (tau / n_p) * (Niu_C(i1, i2, i3, t, n) * (d_i(i1 , i2 + 1, i3, t, n) + d_i(i1, i2, i3, t, n)) / (h2 * h2)
                            + (d_i(i1, i2 + 1, i3, t, n) * V_plus(i1, i2, i3, t, n) - d_i(i1, i2, i3, t, n) * V_minus(i1, i2, i3, t, n)) / (h2 * D2[t, i1, i2, i3]) + gamma / 3.0);

                        for (int i = 1; i < m2-1;
                            s = (tau / n_p) * ((gamma / 3.0) * C_m + (d_i(i1, i + 1, i3, t, n) * (T[t + 1, i1 , i + 1, i3] - T[t + 1, i1, i, i3]) - d_i(i1, i + 1, i3, t, n) * (T[t + 1, i1, i, i3] - T[t + 1, i1, i-1, i3])) / (h2 * h2)),
                            Alpha[i] = b / (c - a * Alpha[i - 1]),
                            Beta[i] = (a * Beta[i - 1] + s) / (c - a * Alpha[i - 1]),
                            i++) ;
                        break;
                    }
                case 3:
                    {
                        Alpha = new double[m3];
                        Beta = new double[m3];
                        Alpha[0] = 0;
                        Beta[0] = C[t, i1, i2, 0];

                        a = (tau / n_p) * (d_i(i1, i2, i3, t, n) / h3) * ( Niu_C(i1, i2, i3, t, n) / h3 - V_minus(i1, i2, i3, t, n) / D3[t, i1, i2, i3]);
                        b = (tau / n_p) * (d_i(i1, i2, i3+1, t, n) / h3) * (Niu_C(i1, i2, i3, t, n) / h3 + V_plus(i1, i2, i3, t, n) / D3[t, i1, i2, i3]);
                        c = 1 + (tau / n_p) * (Niu_C(i1, i2, i3, t, n) * (d_i(i1, i2, i3 + 1, t, n) + d_i(i1, i2, i3, t, n)) / (h3 * h3)
                            + (d_i(i1, i2, i3 + 1, t, n) * V_plus(i1, i2, i3, t, n) - d_i(i1, i2, i3, t, n) * V_minus(i1, i2, i3, t, n)) / (h3 * D3[t, i1, i2, i3]) + gamma / 3.0);

                        for (int i = 1; i < m3-1;
                            s = (tau / n_p) * ((gamma / 3.0) * C_m + (d_i(i1, i2, i + 1, t, n) * (T[t + 1, i1, i2, i + 1] - T[t + 1, i1, i2, i]) - d_i(i1, i2, i, t, n) * (T[t + 1, i1, i, i3] - T[t + 1, i1, i - 1, i3])) / (h2 * h2)),
                            Alpha[i] = b / (c - a * Alpha[i - 1]),
                            Beta[i] = (a * Beta[i - 1] + T[t, i1, i2, i]) / (c - a * Alpha[i - 1]),
                            i++) ;
                        break;
                    }
            }

            switch (n)
            {
                case 1:
                    {
                        for (int i = m1 - 2; i > 0;
                            C[t+1, i, i2, i3] = Alpha[i + 1] * C[t+1, i + 1, i2, i3] + Beta[i + 1],
                            i--) ;
                        break;
                    }
                case 2:
                    {
                        for (int i = m2 - 2; i > 0;
                            C[t+1, i1, i, i3] = Alpha[i + 1] * C[t+1, i1, i + 1, i3] + Beta[i + 1],
                            i--) ;
                        break;
                    }
                case 3:
                    {
                        for (int i = m3 - 2; i > 0;
                            C[t+1, i1, i2, i] = Alpha[i + 1] * C[t+1, i1, i2, i + 1] + Beta[i + 1],
                            i--) ;
                        break;
                    }
            }
        }





    }
}
