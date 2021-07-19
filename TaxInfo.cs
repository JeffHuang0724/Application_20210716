using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_20210716
{
    class TaxInfo
    {
        public decimal GetTaxInfo(string carType, string displacement)
        {
            decimal baseTax = new decimal();
            switch (carType)
            {
                case "機車":
                    switch (displacement)
                    {
                        case "150以下 / 12HP以下(12.2PS以下)":
                            baseTax = 0;
                            break;
                        case "151-250 / 12.1-20HP(12.3-20.3PS)":
                            baseTax = 800;
                            break;
                        case "251-500 / 20.1HP以上(20.4PS以上)":
                            baseTax = 1620;
                            break;
                        case "501-600":
                            baseTax = 2160;
                            break;
                        case "601-1200":
                            baseTax = 4320;
                            break;
                        case "1201-1800":
                            baseTax = 7120;
                            break;
                        case "1801或以上":
                            baseTax = 11230;
                            break;
                    }
                    break;
                case "貨車":
                    switch (displacement)
                    {
                        case "500以下":
                            baseTax = 900;
                            break;
                        case "501-600":
                            baseTax = 1080;
                            break;
                        case "601-1200":
                            baseTax = 1800;
                            break;
                        case "1201-1800":
                            baseTax = 2700;
                            break;
                        case "1801-2400":
                            baseTax = 3600;
                            break;
                        case "2401-3000 / 138HP以下(140.1PS以下)":
                            baseTax = 4500;
                            break;
                        case "3001-3600":
                            baseTax = 5400;
                            break;
                        case "3601-4200 / 138.1-200HP(140.2-203.0PS)":
                            baseTax = 6300;
                            break;
                        case "4201-4800":
                            baseTax = 7200;
                            break;
                        case "4801-5400 / 200.1-247HP(203.1-250.7PS)":
                            baseTax = 8100;
                            break;
                        case "5401-6000":
                            baseTax = 9000;
                            break;
                        case "6001-6600 / 247.1-286HP(250.8-290.3PS)":
                            baseTax = 9900;
                            break;
                        case "6601-7200":
                            baseTax = 10800;
                            break;
                        case "7201-7800 / 286.1-336HP(290.4-341.0PS)":
                            baseTax = 11700;
                            break;
                        case "7801-8400":
                            baseTax = 12600;
                            break;
                        case "8401-9000 / 336.1-361HP(341.1-366.4PS)":
                            baseTax = 13500;
                            break;
                        case "9001-9600":
                            baseTax = 14400;
                            break;
                        case "9601-10200 / 361.1HP以上(366.5PS以上)":
                            baseTax = 15300;
                            break;
                        case "10201以上":
                            baseTax = 16200;
                            break;
                    }
                    break;
                case "大客車":
                    switch (displacement)
                    {
                        case "600以下":
                            baseTax = 1080;
                            break;
                        case "601-1200":
                            baseTax = 1800;
                            break;
                        case "1201-1800":
                            baseTax = 2700;
                            break;
                        case "1801-2400":
                            baseTax = 3600;
                            break;
                        case "2401-3000 / 138HP以下(140.1PS以下)":
                            baseTax = 4500;
                            break;
                        case "3001-3600":
                            baseTax = 5400;
                            break;
                        case "3601-4200 / 138.1-200HP(140.2-203.0PS)":
                            baseTax = 6300;
                            break;
                        case "4201-4800":
                            baseTax = 7200;
                            break;
                        case "4801-5400 / 200.1-247HP(203.1-250.7PS)":
                            baseTax = 8100;
                            break;
                        case "5401-6000":
                            baseTax = 9000;
                            break;
                        case "6001-6600 / 247.1-286HP(250.8-290.3PS)":
                            baseTax = 9900;
                            break;
                        case "6601-7200":
                            baseTax = 10800;
                            break;
                        case "7201-7800 / 286.1-336HP(290.4-341.0PS)":
                            baseTax = 11700;
                            break;
                        case "7801-8400":
                            baseTax = 12600;
                            break;
                        case "8401-9000 / 336.1-361HP(341.1-366.4PS)":
                            baseTax = 13500;
                            break;
                        case "9001-9600":
                            baseTax = 14400;
                            break;
                        case "9601-10200 / 361.1HP以上(366.5PS以上)":
                            baseTax = 15300;
                            break;
                        case "10201以上":
                            baseTax = 16200;
                            break;
                    }
                    break;
                case "自用小客車":
                    switch (displacement)
                    {
                        case "500以下 / 38HP以下(38.6PS以下)":
                            baseTax = 1620;
                            break;
                        case "501~600 / 38.1-56HP(38.7-56.8PS)":
                            baseTax = 2160;
                            break;
                        case "601~1200 / 56.1-83HP(56.9-84.2PS)":
                            baseTax = 4320;
                            break;
                        case "1201~1800 / 83.1-182HP(84.3-184.7PS)":
                            baseTax = 7120;
                            break;
                        case "1801~2400 / 182.1-262HP(184.8-265.9PS)":
                            baseTax = 11230;
                            break;
                        case "2401~3000 / 262.1-322HP(266-326.8PS)":
                            baseTax = 15210;
                            break;
                        case "3001-4200 / 322.1-414HP(326.9-420.2PS":
                            baseTax = 28220;
                            break;
                        case "4201-5400 / 414.1-469HP(420.3-476.0PS)":
                            baseTax = 46170;
                            break;
                        case "5401-6600 / 469.1-509HP(476.1-516.6PS)":
                            baseTax = 69690;
                            break;
                        case "6601-7800 / 509.1HP以上(516.7PS以上)":
                            baseTax = 117000;
                            break;
                        case "7801以上":
                            baseTax = 151200;
                            break;
                    }
                    break;
                case "營業用小客車":
                    switch (displacement)
                    {
                        case "500以下 / 38HP以下(38.6PS以下)":
                            baseTax = 900;
                            break;
                        case "501~600 / 38.1-56HP(38.7-56.8PS)":
                            baseTax = 1260;
                            break;
                        case "601~1200 / 56.1-83HP(56.9-84.2PS)":
                            baseTax = 2160;
                            break;
                        case "1201~1800 / 83.1-182HP(84.3-184.7PS)":
                            baseTax = 3060;
                            break;
                        case "1801~2400 / 182.1-262HP(184.8-265.9PS)":
                            baseTax = 6480;
                            break;
                        case "2401~3000 / 262.1-322HP(266-326.8PS)":
                            baseTax = 9900;
                            break;
                        case "3001-4200 / 322.1-414HP(326.9-420.2PS":
                            baseTax = 16380;
                            break;
                        case "4201-5400 / 414.1-469HP(420.3-476.0PS)":
                            baseTax = 24300;
                            break;
                        case "5401-6600 / 469.1-509HP(476.1-516.6PS)":
                            baseTax = 33660;
                            break;
                        case "6601-7800 / 509.1HP以上(516.7PS以上)":
                            baseTax = 44460;
                            break;
                        case "7801以上":
                            baseTax = 56700;
                            break;
                    }
                    break;
            }
            return baseTax;
        }
    }
}
